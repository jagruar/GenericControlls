using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GenericControls.Controllers
{
    [Route("")]
    public class PagesController : Controller
    {
        [HttpGet("/{url}")]
        public IActionResult Index(string url)
        {
            return View("test");
        }
    }
}
