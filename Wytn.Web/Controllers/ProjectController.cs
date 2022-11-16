using System.Diagnostics;
using Wytn.Sys.Service.Interface;
using Wytn.Web.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Wytn.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ILogger<ProjectController> logger;
        private readonly IConfiguration configuration;
        private readonly ICodeService codeService;

        public ProjectController(ILogger<ProjectController> logger, IConfiguration configuration, ICodeService codeService)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.codeService = codeService;
        }

        public IActionResult Index()
        {
            ViewBag.Env = configuration["Env"];

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
