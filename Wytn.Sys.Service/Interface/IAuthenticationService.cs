using System.Collections.Generic;

using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Entity;
using Wytn.Sys.Model.Payload;

namespace Wytn.Sys.Service.Interface
{
    /// <summary>
    /// 驗證 Service
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// 一般登入
        /// </summary>
        /// <param name="loginPayload">LoginPayload</param>
        /// <returns>UserInfo</returns>
        UserInfo login(LoginPayload loginPayload);

        /// <summary>
        /// 建立驗證碼
        /// </summary>
        /// <returns>ImageCode</returns>
        ImageCode createImageCode();

        /// <summary>
        /// 取選單資料
        /// </summary>
        /// <returns>List FuncDto</returns>
        List<FuncDto> getFunc();

        /// <summary>
        /// 登出
        /// </summary>
        void logout();

        /// <summary>
        /// 重設Token
        /// </summary>
        /// <returns></returns>
        UserInfo refresh();

        /// <summary>
        /// 取登入紀錄
        /// </summary>
        /// <param name="userId">人員Id</param>
        /// <returns>LoginRecord</returns>
        LoginRecord getActiveByUserId(string userId);

        /// <summary>
        /// 取得線上人員名單
        /// </summary>
        /// <returns>List LoginRecordDto</returns>
        List<LoginRecordDto> getOnlineUsers();

        /// <summary>
        /// 發送重設密碼MAIL
        /// </summary>
        /// <param name="userId">人員Id</param>
        /// <returns></returns>
        bool sendRestPwd(string userId);

        /// <summary>
        /// 中斷人員
        /// </summary>
        /// <param name="id">uuid</param>
        void susppend(string id);
        /// <summary>
        /// 取路徑權限
        /// </summary>
        /// <param name="pathPayload">路徑url</param>
        /// <returns></returns>
        PermissionDto getPermission(PathPayload pathPayload);
    }
}
