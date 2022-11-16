using System.Collections.Generic;

using Wytn.Sys.Model.Entity;
using Wytn.Sys.Model.Payload;
using Wytn.Sys.Service.Interface;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Wytn.Sys.Controller
{
    /// <summary>
    /// 選單相關API
    /// </summary>
    [Route("api/funcs")]
    [Authorize]
    [ApiController]
    public class FuncController : ControllerBase
    {
        private readonly IFuncService funcService;
        public FuncController(IFuncService funcService)
        {
            this.funcService = funcService;
        }

        /// <summary>
        /// 取選單資料
        /// </summary>
        /// <param name="sort">排序欄位</param>
        /// <returns>List Func</returns>
        [HttpGet]
        public ActionResult<List<Func>> findAll(string sort)
        {
            string[] sorts = sort.Split(',');
            List<Func> list = funcService.findAll(sorts);
            return Ok(list);
        }

        /// <summary>
        /// 取一筆選單資料
        /// </summary>
        /// <param name="id">uuid</param>
        /// <returns>Func</returns>
        [HttpGet("{id}")]
        public ActionResult<Func> findById(string id)
        {
            Func obj = funcService.findById(id);
            return Ok(obj);
        }

        /// <summary>
        /// 儲存選單資料
        /// </summary>
        /// <param name="funcPayload">FuncPayload</param>
        /// <returns>Func</returns>
        [HttpPost]
        public ActionResult<Func> save([FromBody] FuncPayload funcPayload)
        {
            Func obj = funcService.saveFunc(funcPayload);
            return Ok(obj);
        }

        /// <summary>
        /// 刪除選單資料
        /// </summary>
        /// <param name="id">uuid</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult deleteById(string id)
        {
            funcService.deleteById(id);
            return Ok();
        }

        /// <summary>
        /// 儲存多筆選單資料
        /// </summary>
        /// <param name="funcs">List Func</param>
        /// <returns>List Func</returns>
        [HttpPut("list")]
        public ActionResult<List<Func>> saveFuncs([FromBody] List<Func> funcs)
        {
            List<Func> list = funcService.saveFuncs(funcs);
            return Ok(list);
        }
    }
}
