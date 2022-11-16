using System;
using System.Collections.Generic;

using Wytn.Sys.Model.Payload;
using Wytn.Sys.Service.Interface;
using Wytn.Util;

using Microsoft.Extensions.Configuration;

namespace Wytn.Sys.Service
{
    /// <inheritdoc/>
    public class FeedbackService : IFeedbackService
    {
        /// <summary>
        /// config 物件
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Principal Accessor (使用者物件)
        /// </summary>
        private readonly PrincipalAccessor principalAccessor;

        /// <summary>
        /// 郵件 Helper
        /// </summary>
        private readonly MailHelper mailHelper;

        public FeedbackService(
            IConfiguration configuration,
            PrincipalAccessor principalAccessor,
            MailHelper mailHelper)
        {
            this.configuration = configuration;
            this.principalAccessor = principalAccessor;
            this.mailHelper = mailHelper;
        }

        public bool mailToManager(FeedbackPayload feedbackPayload)
        {
            string base64 = feedbackPayload.img;
            string base64Image = base64.Split(',')[1];
            byte[] imageBytes = Convert.FromBase64String(base64Image);
            string to = configuration["App:Feedback"];
            string from = configuration["App:Mail"];

            Dictionary<string, byte[]> attachments = new Dictionary<string, byte[]>();
            attachments.Add("feedback.png", imageBytes);

            var data = new { name = principalAccessor.cname, note = feedbackPayload.note };
            string content = mailHelper.parseBody("feedback", data);
            mailHelper.send("問題回報", content, from, to, attachments);
            return true;
        }
    }
}
