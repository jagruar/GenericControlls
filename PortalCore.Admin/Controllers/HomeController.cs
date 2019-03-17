using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortalCore.Admin.Models;
using PortalCore.Interfaces.Internal;

namespace PortalCore.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInstallService _installService;

        public HomeController(IInstallService installService)
        {
            _installService = installService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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


        public IActionResult InstallModels()
        {
            _installService.InstallModels();
            return RedirectToAction("Index");
        }
    }
}
