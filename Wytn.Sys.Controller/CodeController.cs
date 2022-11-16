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
    /// 代碼相關API
    /// </summary>
    [Route("api/codes")]
    [Authorize]
    [ApiController]
    public class CodeController : ControllerBase
    {
        ICodeService codeService;
        public CodeController(ICodeService codeService)
        {
            this.codeService = codeService;
        }

        /// <summary>
        /// 取代碼資料
        /// </summary>
        /// <param name="pno">父代碼</param>
        /// <returns>List CodeDto</returns>
        [HttpGet("like")]
        public ActionResult<List<CodeDto>> findInCodePno([FromQuery(Name = "pno")] string pno)
        {
            List<CodeDto> obj = codeService.findLikeCodePno(pno);
            return Ok(obj);
        }

        /// <summary>
        /// 取代碼資料
        /// </summary>
        /// <param name="pno">List 父代碼</param>
        /// <returns>List CodeDto</returns>
        [HttpGet("list")]
        public ActionResult<List<CodeDto>> findInCodePno(List<string> pno)
        {
            List<CodeDto> obj = codeService.findInCodePno(pno);
            return Ok(obj);
        }

        /// <summary>
        /// 取代碼資料
        /// </summary>
        /// <param name="pno">父代碼</param>
        /// <returns>List Code</returns>
        [HttpGet]
        public ActionResult<List<Code>> findByCodePno(string pno)
        {
            List<Code> obj = codeService.findByCodePno(pno);
            return Ok(obj);
        }

        /// <summary>
        /// 儲存代碼資料
        /// </summary>
        /// <param name="payload">CodePayload</param>
        /// <returns>Code</returns>
        [HttpPost]
        public ActionResult<Code> save([FromBody] CodePayload payload)
        {
            Code obj = codeService.save(payload);
            return Ok(obj);
        }

        /// <summary>
        /// 取一筆代碼資料
        /// </summary>
        /// <param name="id">uuid</param>
        /// <returns>Code</returns>
        [HttpGet("{id}")]
        public ActionResult<Code> findById(string id)
        {
            Code obj = codeService.findById(id);
            return Ok(obj);
        }

        /// <summary>
        /// 刪除代碼資料
        /// </summary>
        /// <param name="id">uuid</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult deleteById(string id)
        {
            codeService.deleteById(id);
            return Ok();
        }
    }
}
