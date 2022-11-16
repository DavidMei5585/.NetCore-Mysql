using System.Collections.Generic;

using Wytn.Sys.Model.Entity;

namespace Wytn.Sys.Repository.Interface
{
    /// <summary>
    /// 人員角色Repository
    /// </summary>
    public interface IPersonRoleRepository : IGenericRepository<PersonRole>
    {
        /// <summary>
        /// 取人員資料
        /// </summary>
        /// <param name="userId">人員Id</param>
        /// <returns></returns>
        List<PersonRole> findByUserId(string userId);
        /// <summary>
        /// 刪除人員資料
        /// </summary>
        /// <param name="userId">人員Id</param>
        void deleteByUserId(string userId);
        /// <summary>
        /// 取角色資料
        /// </summary>
        /// <param name="userId">人員Id</param>
        /// <returns></returns>
        List<string> getRoles(string userId);
    }
}
