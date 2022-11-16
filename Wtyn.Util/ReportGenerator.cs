using System.Collections.Generic;

using AspNetCore.Reporting;

using Microsoft.AspNetCore.Hosting;

namespace Wytn.Util
{
    /// <summary>
    /// 報表產生器
    /// </summary>
    public class ReportGenerator
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public ReportGenerator(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 產製PDF
        /// </summary>
        /// <param name="parameters">報表參數</param>
        /// <param name="datas">報表資料</param>
        /// <param name="rdlcName">RDLC檔案名稱</param>
        /// <returns></returns>
        public byte[] generatePdf(Dictionary<string, string> parameters, Dictionary<string, object> datas, string rdlcName)
        {
            var result = getLocalReport(parameters, datas, rdlcName, RenderType.Pdf);
            return result.MainStream;
        }

        /// <summary>
        /// 取ReportResult
        /// </summary>
        /// <param name="parameters">報表參數</param>
        /// <param name="datas">報表資料</param>
        /// <param name="rdlcName">RDLC檔案名稱</param>
        /// <param name="renderType">報表格式</param>
        /// <returns>ReportResult</returns>
        private ReportResult getLocalReport(Dictionary<string, string> parameters, Dictionary<string, object> datas, string rdlcName, RenderType renderType)
        {
            string reportPath = $"{this.hostingEnvironment.ContentRootPath}\\Report\\" + rdlcName + ".rdlc";
            LocalReport lr = new LocalReport(reportPath);
            foreach (var data in datas)
            {
                lr.AddDataSource(data.Key, data.Value);
            }
            return lr.Execute(renderType, 1, parameters, "");
        }
    }
}
