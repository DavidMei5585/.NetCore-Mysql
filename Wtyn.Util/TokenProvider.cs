using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Wytn.Util
{
    /// <summary>
    /// Token提供器
    /// </summary>
    public class TokenProvider
    {
        public IConfiguration configuration { get; }

        public TokenProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// 產生Token
        /// </summary>
        /// <param name="userId">人員Id</param>
        /// <param name="name">英文姓名(AD 帳號)</param>
        /// <param name="cname">中文姓名</param>
        /// <param name="orgId">組織Id</param>
        /// <param name="deptId">單位Id</param>
        /// <param name="subdeptId">科室Id</param>
        /// <param name="roles">角色</param>
        /// <returns></returns>
        public string generateToken(string userId, string name, string cname, string orgId, string deptId, string subdeptId, string roles)
        {
            // STEP1: 建立使用者的 Claims 聲明，這會是 JWT Payload 的一部分
            var userClaims = new ClaimsIdentity(new[] {
                new Claim(JwtRegisteredClaimNames.NameId, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("name", name ?? ""),
                new Claim("cname", cname ?? ""),
                new Claim("orgId", orgId ?? ""),
                new Claim("deptId", deptId ?? ""),
                new Claim("subdeptId", subdeptId ?? ""),
                new Claim("roles", roles ?? "")
            });

            return createToken(userClaims, 60);
        }

        /// <summary>
        /// 產生Token
        /// </summary>
        /// <param name="uuid">uuid</param>
        /// <param name="minutes">效期(分鐘)</param>
        /// <returns></returns>
        public string generateToken(string uuid, int minutes)
        {
            // STEP1: 建立使用者的 Claims 聲明，這會是 JWT Payload 的一部分
            var userClaims = new ClaimsIdentity(new[] {
                new Claim(JwtRegisteredClaimNames.NameId, uuid),
            });

            return createToken(userClaims, minutes);
        }

        /// <summary>
        /// 建立Token
        /// </summary>
        /// <param name="userClaims">ClaimsIdentity</param>
        /// <param name="minutes">效期(分鐘)</param>
        /// <returns></returns>
        private string createToken(ClaimsIdentity userClaims, int minutes)
        {
            // STEP2: 取得對稱式加密 JWT Signature 的金鑰
            // 這部分是選用，但此範例在 Startup.cs 中有設定 ValidateIssuerSigningKey = true 所以這裡必填
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SignKey"]));
            // STEP3: 建立 JWT TokenHandler 以及用於描述 JWT 的 TokenDescriptor
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Issuer"],
                Subject = userClaims,
                Expires = DateTime.Now.AddMinutes(minutes),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            };
            // 產出所需要的 JWT Token 物件
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var serializeToken = tokenHandler.WriteToken(securityToken);
            return serializeToken;
        }
    }
}
