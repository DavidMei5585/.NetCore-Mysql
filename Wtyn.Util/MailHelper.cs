using System.Collections.Generic;
using System.IO;

using MailKit.Net.Smtp;
using MailKit.Security;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

using MimeKit;

using RazorEngine;
using RazorEngine.Templating;

namespace Wytn.Util
{
    /// <summary>
    /// 郵件發送 Helper
    /// </summary>
    public class MailHelper
    {
        private readonly IConfiguration configuration;
        private readonly IHostingEnvironment hostingEnvironment;

        public MailHelper(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            this.configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 發送郵件
        /// </summary>
        /// <param name="subject">主旨</param>
        /// <param name="content">內容</param>
        /// <param name="from">寄件者</param>
        /// <param name="to">收件者</param>
        public void send(string subject, string content, string from, string to)
        {
            send(subject, content, from, to, null);
        }

        /// <summary>
        /// 發送郵件
        /// </summary>
        /// <param name="subject">主旨</param>
        /// <param name="content">內容</param>
        /// <param name="from">寄件者</param>
        /// <param name="to">收件者</param>
        /// <param name="attachments">附件</param>
        public void send(string subject, string content, string from, string to, Dictionary<string, byte[]> attachments)
        {
            string host = configuration["MailSettings:Host"];
            int port;
            int.TryParse(configuration["MailSettings:Port"], out port);

            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(from);
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            var builder = new BodyBuilder();

            if (attachments != null)
            {
                foreach (var file in attachments)
                {
                    builder.Attachments.Add(file.Key, file.Value);
                }
            }

            builder.HtmlBody = content;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(host, port, SecureSocketOptions.None);

            smtp.Send(email);
            smtp.Disconnect(true);
        }

        /// <summary>
        /// 套用郵件樣版
        /// </summary>
        /// <param name="templateName">razor樣版檔名</param>
        /// <param name="data">資料</param>
        /// <returns>套用資料後的郵件內容</returns>
        public string parseBody(string templateName, object data)
        {
            string rootPath = hostingEnvironment.ContentRootPath;

            //將Template存入Cache以利重複使用
            Engine.Razor.AddTemplate(
                "content", // Cache Key
                File.ReadAllText(rootPath + "\\Template\\" + templateName + ".cshtml"));

            //傳入Cache Key、Model物件型別、Model物件取得套表結果
            var result =
                Engine.Razor.RunCompile("content", null, data);

            //除了RunCompile，也可Compile一次，Run多次以提高效能
            Engine.Razor.Compile("content");
            Engine.Razor.Run("content", null, data);

            return result;
        }
    }
}
