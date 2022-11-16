using Wytn.Sys.Model.Payload;
using Wytn.Sys.Service.Interface;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Wytn.Sys.Controller
{
    /// <summary>
    /// 問題回饋相關API
    /// </summary>
    [Route("api/feedbacks")]
    [Authorize]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        /// <summary>
        /// 儲存問題回饋
        /// </summary>
        /// <param name="payload"></param>
        /// <returns>發送MAIL成功: {}, 失敗: ""</returns>
        [HttpPost]
        public IActionResult findOne([FromBody] FeedbackPayload payload)
        {
            bool mailed = feedbackService.mailToManager(payload);
            if (mailed)
                return Ok("{}");
            return Ok();
        }
    }
}
