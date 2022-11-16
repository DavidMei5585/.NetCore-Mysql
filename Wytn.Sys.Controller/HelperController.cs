using System.Collections.Generic;

using Wytn.Sys.Model.Entity;
using Wytn.Sys.Service.Interface;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wytn.Sys.Controller
{
    /// <summary>
    /// 操作教學相關API
    /// </summary>
    [Route("api/helpers")]
    [Authorize]
    [ApiController]
    public class HelperController : ControllerBase
    {
        IHelperService helperService;
        public HelperController(IHelperService helperService)
        {
            this.helperService = helperService;
        }

        /// <summary>
        /// 刪除操作教學
        /// </summary>
        /// <param name="id">uuid</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult delete(string id)
        {
            helperService.delete(id);
            return Ok();
        }

        /// <summary>
        /// 取操作教學
        /// </summary>
        /// <returns>List Helper</returns>
        [HttpGet]
        public ActionResult<List<Helper>> findAll()
        {
            List<Helper> obj = helperService.findAll();
            return Ok(obj);
        }

        /// <summary>
        /// 取操作教學檔案
        /// </summary>
        /// <param name="name">操作教學網址</param>
        /// <param name="id">操作教學uuid</param>
        /// <returns>byte[] 操作教學檔案</returns>
        [HttpGet("pdf")]
        public ActionResult<byte[]> getPdfByUrl(string name, string id)
        {
            byte[] bytes = null;
            if (!string.IsNullOrEmpty(name))
                bytes = helperService.getPdfByName(name);
            else if (!string.IsNullOrEmpty(id))
                bytes = helperService.getPdfById(id);
            return File(bytes, "application/octet-stream");
        }


        /// <summary>
        /// 儲存操作教學
        /// </summary>
        /// <param name="fields">Form</param>
        /// <param name="file">操作教學PDF檔</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Helper> save([FromForm] Dictionary<string, string> fields, IFormFileCollection file)
        {
            string id = fields["id"];
            string url = fields["name"];

            Helper obj = helperService.save(id, url, file[0]);
            return Ok(obj);
        }

    }
}
