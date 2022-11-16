using System.Diagnostics;
using Wytn.Sys.Service.Interface;
using Wytn.Web.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Wytn.Sys.Model.Entity;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System;
using NPOI.XSSF.UserModel;
using System.IO;

namespace Wytn.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IConfiguration configuration;
        private readonly ICodeService codeService;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, ICodeService codeService)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.codeService = codeService;
        }

        public IActionResult Index()
        {
            ViewBag.Env = configuration["Env"];
            var list = codeService.findByCodePno("PROJECTS").OrderByDescending((c) => c.codePno)?.ToList();
            ViewBag.code = list;

            return View();
        }

        public IActionResult Privacy(string id)
        {
            if (id != null)
            {
                ViewBag.id = id;
            }
            return View();
        }
        [HttpPost]
        public IActionResult Import(IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    //xlsx
                    XSSFWorkbook workbook;
                    XSSFSheet sheet;
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        Stream stream = new MemoryStream(ms.ToArray());
                        workbook = new XSSFWorkbook(stream);
                    }
                    if (workbook != null)
                    {
                        //取得第一頁工作表 0:第一頁
                        sheet = (XSSFSheet)workbook.GetSheetAt(0);
                        //不需要被讀取的表頭行 0:第一行
                        int headerRow = 0;
                        //從第二行開始讀取 -> 最後一行
                        for (int i = (headerRow + 1); i <= sheet.LastRowNum; i++)
                        {
                            //讀取一整行
                            XSSFRow row = (XSSFRow)sheet.GetRow(i);
                            //一整行內從第一格開始讀起
                            for (int j=0; j < row.Cells.Count; j++)
                            {
                                //讀取該格內容
                                string cell = row.GetCell(j).ToString();
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
