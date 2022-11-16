using System.Collections.Generic;

using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Entity;
using Wytn.Sys.Model.Payload;

namespace Wytn.Sys.Service.Interface
{
    /// <summary>
    /// 人員Service
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// 取人員資料
        /// </summary>
        /// <param name="userId">人員Id</param>
        /// <returns>Person</returns>
        Person getByUserId(string userId);
        /// <summary>
        /// 刪除人員資料
        /// </summary>
        /// <param name="userId">人員Id</param>
        void deleteByUserId(string userId);
        /// <summary>
        /// 儲存人員資料
        /// </summary>
        /// <param name="personPayload">PersonPayload</param>
        /// <returns>Person</returns>
        Person save(PersonPayload personPayload);
        /// <summary>
        /// 取角色資料
        /// </summary>
        /// <param name="userId">人員Id</param>
        /// <returns>List PersonRole</returns>
        List<PersonRole> getRole(string userId);
        /// <summary>
        /// 查詢人員資料
        /// </summary>
        /// <param name="orgId">組織Id</param>
        /// <param name="deptId">單位Id</param>
        /// <param name="userId">人員Id</param>
        /// <param name="name">英文姓名 (AD 帳號)</param>
        /// <param name="cname">中文姓名</param>
        /// <param name="roleId">角色Id</param>
        /// <returns>List PersonDto</returns>
        List<PersonDto> getQuery(string orgId, string deptId, string userId, string name, string cname, string roleId);
        /// <summary>
        /// 儲存人員角色
        /// </summary>
        /// <param name="personRolePayload">PersonRolePayload</param>
        /// <returns>List PersonRole</returns>
        List<PersonRole> saveRoles(PersonRolePayload personRolePayload);
    }
}
