using System.Collections.Generic;

using Wytn.Sys.Model.Entity;
using Wytn.Sys.Model.Payload;

namespace Wytn.Sys.Service.Interface
{
    /// <summary>
    /// 角色Service
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// 儲存角色
        /// </summary>
        /// <param name="role">RolePayload</param>
        /// <returns>Role</returns>
        Role save(RolePayload role);
        /// <summary>
        /// 取角色資料
        /// </summary>
        /// <returns>List Role</returns>
        List<Role> findAll();
        /// <summary>
        /// 取角色資料
        /// </summary>
        /// <param name="id">uuid</param>
        /// <returns>Role</returns>
        Role findById(string id);
        /// <summary>
        /// 刪除角色資料
        /// </summary>
        /// <param name="id">uuid</param>
        void deleteById(string id);
        /// <summary>
        /// 取選單資料
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns>List Func</returns>
        List<Func> getFuncsByRoleId(string roleId);
        /// <summary>
        /// 儲存角色選單
        /// </summary>
        /// <param name="roleFuncs">List RoleFunc</param>
        /// <returns>List RoleFunc</returns>
        List<RoleFunc> saveRoleFuncs(List<RoleFunc> roleFuncs);
        /// <summary>
        /// 產生角色清單PDF檔
        /// </summary>
        /// <returns>byte[]</returns>
        byte[] export();
    }
}
