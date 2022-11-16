using System.Collections.Generic;

using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Payload;
using Wytn.Sys.Service.Interface;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Wytn.Sys.Controller
{
    /// <summary>
    /// 登入相關API
    /// </summary>
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="loginPayload">LoginPayload</param>
        /// <returns>UserInfo</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<UserInfo> login(LoginPayload loginPayload)
        {
            UserInfo obj = authenticationService.login(loginPayload);
            return Ok(obj);
        }

        /// <summary>
        /// 取得驗證碼
        /// </summary>
        /// <returns>ImageCode</returns>
        [AllowAnonymous]
        [HttpGet("imageCode")]
        public ActionResult<ImageCode> imageCode()
        {
            ImageCode imageCode = authenticationService.createImageCode();
            return Ok(imageCode);
        }

        /// <summary>
        /// 取選單資料
        /// </summary>
        /// <returns>List FuncDto</returns>
        [Authorize]
        [HttpGet("funcs")]
        public ActionResult<List<FuncDto>> getFunc()
        {
            List<FuncDto> obj = authenticationService.getFunc();
            return Ok(obj);
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPut("logout")]
        public IActionResult logout()
        {
            authenticationService.logout();
            return Ok();
        }

        /// <summary>
        /// 重新取得Token
        /// </summary>
        /// <returns>UserInfo</returns>
        [Authorize]
        [HttpPut("refresh")]
        public ActionResult<UserInfo> refresh()
        {
            UserInfo obj = authenticationService.refresh();
            return Ok(obj);
        }

        /// <summary>
        /// 取線上人員資料
        /// </summary>
        /// <returns>List LoginRecordDto</returns>
        [Authorize]
        [HttpGet]
        public ActionResult<List<LoginRecordDto>> getOnlineUsers()
        {
            List<LoginRecordDto> obj = authenticationService.getOnlineUsers();
            return Ok(obj);
        }

        /// <summary>
        /// 中斷人員
        /// </summary>
        /// <param name="id">uuid</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult suspendUser(string id)
        {
            authenticationService.susppend(id);
            return Ok();
        }

        /// <summary>
        /// 發送忘記密碼郵件
        /// </summary>
        /// <param name="loginPayload">LoginPayload</param>
        /// <returns>bool</returns>
        [HttpPost("pwd")]
        public IActionResult sendRestPwd(LoginPayload loginPayload)
        {
            bool reset = authenticationService.sendRestPwd(loginPayload.userId);
            return Ok(reset);
        }
        /// <summary>
        /// 取路徑權限
        /// </summary>
        /// <param name="pathPayload"></param>
        /// <returns></returns>
        [HttpPost("permissions")]
        public IActionResult getPermission(PathPayload pathPayload)
        {
            PermissionDto permissionDto = authenticationService.getPermission(pathPayload);
            return Ok(permissionDto);
        }
    }
}
