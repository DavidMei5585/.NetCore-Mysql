using System.Collections.Generic;

using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Entity;

namespace Wytn.Sys.Repository.Interface
{
    /// <summary>
    /// 人員Repository
    /// </summary>
    public interface IPersonRepository : IGenericRepository<Person>
    {
        /// <summary>
        /// 取人員資料
        /// </summary>
        /// <param name="userId">人員Id</param>
        /// <param name="password">人員密碼</param>
        /// <returns></returns>
        Person getPerson(string userId, string password);
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
        /// 依人員英文姓名(AD 帳號)取人員資料
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Person</returns>
        Person getByName(string name);
        /// <summary>
        /// 依條件取人員資料
        /// </summary>
        /// <param name="orgId">組織Id</param>
        /// <param name="deptId">單位Id</param>
        /// <param name="userId">人員Id</param>
        /// <param name="name">英文姓名</param>
        /// <param name="cname">中文姓名</param>
        /// <param name="roleId">角色Id</param>
        /// <returns>List PersonDto</returns>
        List<PersonDto> getQuery(string orgId, string deptId, string userId, string name, string cname, string roleId);
    }
}
