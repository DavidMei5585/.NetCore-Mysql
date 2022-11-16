using System;
using System.Collections.Generic;
using System.Transactions;

using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Entity;
using Wytn.Sys.Model.Payload;
using Wytn.Sys.Repository.Interface;
using Wytn.Sys.Service.Interface;
using Wytn.Util;
using Wytn.Util.Exception;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Wytn.Sys.Service
{
    /// <inheritdoc/>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IPersonRepository personReponsitory;
        private readonly IPersonRoleRepository personRoleReponsitory;
        private readonly IFuncRepository funcRepository;
        private readonly ILoginRecordRepository loginRecordRepository;
        private readonly ILinkTokenRepository linkTokenRepository;
        private readonly IPersonRepository personRepository;
        private readonly IMemoryCache cache;
        private readonly IConfiguration configuration;
        private readonly PrincipalAccessor principalAccessor;
        private readonly TokenProvider tokenProvider;
        private readonly MailHelper mailHelper;
        private readonly string key = "RrtHLKPIbiNWlrSv";
        private readonly string iv = "6wukdECC8sXp5mIs";

        public AuthenticationService(
            IPersonRepository personReponsitory,
            IPersonRoleRepository personRoleReponsitory,
            IFuncRepository funcRepository,
            ILoginRecordRepository loginRecordRepository,
            ILinkTokenRepository linkTokenRepository,
            IPersonRepository personRepository,
            IMemoryCache cache,
            IConfiguration configuration,
            PrincipalAccessor principalAccessor,
            TokenProvider tokenProvider,
            MailHelper mailHelper)
        {
            this.personReponsitory = personReponsitory;
            this.personRoleReponsitory = personRoleReponsitory;
            this.funcRepository = funcRepository;
            this.loginRecordRepository = loginRecordRepository;
            this.linkTokenRepository = linkTokenRepository;
            this.personRepository = personRepository;
            this.cache = cache;
            this.configuration = configuration;
            this.principalAccessor = principalAccessor;
            this.tokenProvider = tokenProvider;
            this.mailHelper = mailHelper;
        }

        public UserInfo login(LoginPayload loginPayload)
        {
            //check captcha
            string verifyCode = EncryptUtil.DecryptAES(loginPayload.verifyCode, key, iv);
            if (loginPayload.code != verifyCode)
                throw new BusinessException("驗證碼不符!");

            Person person = personReponsitory.getPerson(loginPayload.userId, loginPayload.password);
            if (person == null)
                throw new BusinessException("Bad Credential!");

            using (var scope = new TransactionScope())
            {
                //update login time
                person.lastLoginDate = person.loginDate;
                person.loginDate = DateTime.Now;
                person.updUser = person.userId;
                personReponsitory.Update(person);

                saveLoginRecord(person.userId);

                scope.Complete();
            }

            List<string> roles = personRoleReponsitory.getRoles(person.userId);

            string token = tokenProvider.generateToken(
                person.userId,
                person.name,
                person.cname,
                person.orgId,
                person.deptId,
                person.subdeptId,
                string.Join(',', roles));

            UserInfo userInfoDto = new UserInfo();
            userInfoDto.token = token;
            userInfoDto.userId = person.userId;
            userInfoDto.name = person.name;
            userInfoDto.cname = person.cname;
            userInfoDto.orgId = person.orgId;
            userInfoDto.deptId = person.deptId;
            userInfoDto.subdeptId = person.subdeptId;
            userInfoDto.roles = roles;

            return userInfoDto;
        }

        public void logout()
        {
            string userId = principalAccessor.userId;
            cache.Remove(userId);
            loginRecordRepository.updateFlag(userId, 1, 2);
        }

        public UserInfo refresh()
        {
            string token = tokenProvider.generateToken(
                principalAccessor.userId,
                principalAccessor.name,
                principalAccessor.cname,
                principalAccessor.orgId,
                principalAccessor.deptId,
                principalAccessor.subdeptId,
                principalAccessor.roles);

            saveLoginRecord(principalAccessor.userId);

            UserInfo userInfoDto = new UserInfo();
            userInfoDto.token = token;
            userInfoDto.userId = principalAccessor.userId;
            userInfoDto.name = principalAccessor.name;
            userInfoDto.cname = principalAccessor.cname;
            userInfoDto.orgId = principalAccessor.orgId;
            userInfoDto.deptId = principalAccessor.deptId;
            userInfoDto.subdeptId = principalAccessor.subdeptId;
            userInfoDto.roles = new List<string>(principalAccessor.roles.Split(','));

            return userInfoDto;
        }

        public ImageCode createImageCode()
        {
            int expireIn = 60;
            string code = CaptchaUtil.GenerateRandomText(4);
            string base64 = "data:image/jpeg;base64," + Convert.ToBase64String(CaptchaUtil.GenerateCaptchaImage(code));

            return new ImageCode
            {
                code = EncryptUtil.EncryptAES(code, key, iv),
                image = base64,
                expireTime = DateTime.Now.AddMinutes(expireIn)
            };
        }

        public List<FuncDto> getFunc()
        {
            return funcRepository.getByUserId(principalAccessor.userId);
        }

        public LoginRecord getActiveByUserId(string userId)
        {
            if (!cache.TryGetValue(userId, out LoginRecord loginRecord))
            {
                loginRecord = loginRecordRepository.getActiveByUserId(userId);
                cache.Set(userId, loginRecord, new MemoryCacheEntryOptions { AbsoluteExpiration = DateTime.Now.AddHours(1) });
                return loginRecord;
            }
            else
            {
                return loginRecord;
            }
        }

        public List<LoginRecordDto> getOnlineUsers()
        {
            return loginRecordRepository.getActiveRecord();
        }

        public bool sendRestPwd(string userId)
        {
            LinkToken linkToken = new LinkToken();
            linkToken.userId = userId;
            linkToken.flag = 3;
            linkTokenRepository.Insert(linkToken);

            Person person = personRepository.getByUserId(userId);
            if (person == null)
                throw new BusinessException("無法取得人員資料");

            if (string.IsNullOrEmpty(person.email))
                throw new BusinessException("無法取得人員EMAIL");

            string from = configuration["App:Mail"];
            string url = configuration["App:RestPwdUrl"];
            string token = tokenProvider.generateToken(linkToken.id.ToString(), 30);

            string content = mailHelper.parseBody("resetpwd", new { name = person.cname, url = url + token });
            mailHelper.send("重設密碼", content, from, person.email);
            return true;
        }

        public void susppend(string id)
        {
            LoginRecord loginRecord = loginRecordRepository.Query(id);
            if (loginRecord == null)
                throw new BusinessException("取使用者登入資料時發生錯誤");

            string userId = loginRecord.userId;

            // remove cache
            cache.Remove(userId);

            loginRecordRepository.updateFlag(userId, 1, 3);
        }

        private void saveLoginRecord(string userId)
        {
            // update login record
            loginRecordRepository.updateFlag(userId, 1, 3);

            // inser login record
            LoginRecord loginRecord = new LoginRecord();
            loginRecord.userId = userId;
            loginRecord.flag = 1;
            loginRecord.creUser = userId;
            loginRecordRepository.Insert(loginRecord);

            // set cache
            cache.Set(userId, loginRecord, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddHours(1)
            });
        }

        public PermissionDto getPermission(PathPayload pathPayload)
        {
            List<FuncDto> funcDtos = funcRepository.getByUserId(principalAccessor.userId);
            String path = pathPayload.name.Contains("?") ? pathPayload.name.Split("/?")[0] : pathPayload.name;
            bool permission = funcDtos.Find((d) => !String.IsNullOrEmpty(d.funcUrl) && path.IndexOf(d.funcUrl) >= 0) != null ? true : false;
            PermissionDto permissionDto = new PermissionDto();
            permissionDto.permission = permission;
            return permissionDto;
        }
    }
}
