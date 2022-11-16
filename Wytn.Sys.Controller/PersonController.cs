using System.Collections.Generic;

using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Entity;
using Wytn.Sys.Model.Payload;
using Wytn.Sys.Service.Interface;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Wytn.Sys.Controller
{
    /// <summary>
    /// 人員資料相關API
    /// </summary>
    [Route("api/persons")]
    [Authorize]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;
        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        /// <summary>
        /// 取人員資料
        /// </summary>
        /// <param name="userId">人員Id</param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public ActionResult<Person> getByUserId(string userId)
        {
            Person obj = personService.getByUserId(userId);
            return Ok(obj);
        }

        /// <summary>
        /// 刪除人員資料
        /// </summary>
        /// <param name="userId">人員Id</param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        public IActionResult deleteByUserId(string userId)
        {
            personService.deleteByUserId(userId);
            return Ok("");
        }

        /// <summary>
        /// 儲存人員資料
        /// </summary>
        /// <param name="personPayload">PersonPayload</param>
        /// <returns>Person</returns>
        [HttpPost]
        public ActionResult<Person> save(PersonPayload personPayload)
        {
            Person obj = personService.save(personPayload);
            return Ok(obj);
        }

        /// <summary>
        /// 取人員角色
        /// </summary>
        /// <param name="userId">人員Id</param>
        /// <returns></returns>
        [HttpGet("role/{userId}")]
        public ActionResult<List<PersonRole>> getRole(string userId)
        {
            List<PersonRole> obj = personService.getRole(userId);
            return Ok(obj);
        }

        /// <summary>
        /// 查詢人員資料
        /// </summary>
        /// <param name="orgId">組織Id</param>
        /// <param name="deptId">單位Id</param>
        /// <param name="userId">人員Id</param>
        /// <param name="name">英文帳號</param>
        /// <param name="cname">中文姓名</param>
        /// <param name="roleId">角色Id</param>
        /// <returns>List PersonDto</returns>
        [HttpGet]
        public ActionResult<List<PersonDto>> getQuery(string orgId, string deptId, string userId, string name, string cname, string roleId)
        {
            List<PersonDto> list = personService.getQuery(orgId, deptId, userId, name, cname, roleId);
            return Ok(list);
        }

        /// <summary>
        /// 儲存人員角色
        /// </summary>
        /// <param name="personRolePayload">PersonRolePayload</param>
        /// <returns>List PersonRole</returns>
        [HttpPost("role")]
        public ActionResult<List<PersonRole>> save(PersonRolePayload personRolePayload)
        {
            List<PersonRole> list = personService.saveRoles(personRolePayload);
            return Ok(list);
        }

    }
}
