using System.Collections.Generic;

using Wytn.Sys.Model.Entity;
using Wytn.Sys.Model.Payload;
using Wytn.Sys.Service.Interface;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Wytn.Sys.Controller
{
    /// <summary>
    /// 角色相關API
    /// </summary>
    [Route("api/roles")]
    [Authorize]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;
        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        /// <summary>
        /// 取角色資料
        /// </summary>
        /// <returns>List Role</returns>
        [HttpGet]
        public ActionResult<List<Role>> findAll()
        {
            List<Role> obj = roleService.findAll();
            return Ok(obj);
        }

        /// <summary>
        /// 儲存角色資料
        /// </summary>
        /// <param name="payload">RolePayload</param>
        /// <returns>Role</returns>
        [HttpPost]
        public ActionResult<Role> save([FromBody] RolePayload payload)
        {
            Role obj = roleService.save(payload);
            return Ok(obj);
        }

        /// <summary>
        /// 取一筆角色資料
        /// </summary>
        /// <param name="id">uuid</param>
        /// <returns>Role</returns>
        [HttpGet("{id}")]
        public ActionResult<Role> findById(string id)
        {
            Role obj = roleService.findById(id);
            return Ok(obj);
        }

        /// <summary>
        /// 刪除角色資料
        /// </summary>
        /// <param name="id">uuid</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult delete(string id)
        {
            roleService.deleteById(id);
            return Ok();
        }

        /// <summary>
        /// 依角色取選單資料
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns>List Func</returns>
        [HttpGet("funcs")]
        public ActionResult<List<Func>> getFuncsByRoleId(string roleId)
        {
            List<Func> obj = roleService.getFuncsByRoleId(roleId);
            return Ok(obj);
        }

        /// <summary>
        /// 儲存角色選單資料
        /// </summary>
        /// <param name="roleFuncs">List RoleFunc</param>
        /// <returns>List RoleFunc</returns>
        [HttpPost("funcs")]
        public ActionResult<List<RoleFunc>> saveRoleFuncs([FromBody] List<RoleFunc> roleFuncs)
        {
            List<RoleFunc> obj = roleService.saveRoleFuncs(roleFuncs);
            return Ok(obj);
        }

        /// <summary>
        /// 下載角色清單PDF
        /// </summary>
        /// <returns>byte[] 角色清單PDF</returns>
        [HttpGet("download")]
        public ActionResult<byte[]> download()
        {
            byte[] bytes = roleService.export();
            return File(bytes, "application/octet-stream");
        }
    }
}
