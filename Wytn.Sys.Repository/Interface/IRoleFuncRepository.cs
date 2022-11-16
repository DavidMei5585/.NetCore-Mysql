
using Wytn.Sys.Model.Entity;

namespace Wytn.Sys.Repository.Interface
{
    /// <summary>
    /// 角色選單Repository
    /// </summary>
    public interface IRoleFuncRepository : IGenericRepository<RoleFunc>
    {
        /// <summary>
        /// 刪除角色選單
        /// </summary>
        /// <param name="roleId">角色Id</param>
        void deletByRoleId(string roleId);
        /// <summary>
        /// 刪除角色選單
        /// </summary>
        /// <param name="funcId">選單Id</param>
        void deletByFuncId(string funcId);
    }
}
