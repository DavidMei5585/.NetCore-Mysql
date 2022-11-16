using System.Collections.Generic;

using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Entity;

namespace Wytn.Sys.Repository.Interface
{
    /// <summary>
    /// 選單Repository
    /// </summary>
    public interface IFuncRepository : IGenericRepository<Func>
    {
        /// <summary>
        /// 依人員Id取選單資料
        /// </summary>
        /// <param name="userId">人員Id</param>
        /// <returns>List FuncDto</returns>
        List<FuncDto> getByUserId(string userId);

        /// <summary>
        /// 依父選單Id取最大的排序值
        /// </summary>
        /// <param name="parentFuncId">父選單Id</param>
        /// <returns>排序值</returns>
        int getMaxSortByParentId(string parentId);

        /// <summary>
        /// 取選單資料
        /// </summary>
        /// <param name="sorts">排序欄位</param>
        /// <returns>List Func</returns>
        List<Func> findAll(string[] sorts);

        /// <summary>
        /// 依角色取選單資料
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns>List Func</returns>
        List<Func> getByRoleId(string roleId);
    }
}
