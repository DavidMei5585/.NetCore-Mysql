
using Wytn.Sys.Model.Payload;

namespace Wytn.Sys.Service.Interface
{
    /// <summary>
    /// 問題回饋Service
    /// </summary>
    public interface IFeedbackService
    {
        /// <summary>
        /// 發送管理者
        /// </summary>
        /// <param name="feedbackPayload">FeedbackPayload</param>
        /// <returns>bool</returns>
        bool mailToManager(FeedbackPayload feedbackPayload);
    }
}
