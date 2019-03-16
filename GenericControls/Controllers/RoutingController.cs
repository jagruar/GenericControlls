using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericControls.Models.Internal;
using GenericControls.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GenericControls.Controllers
{
    [Route("")]
    public class RoutingController : Controller
    {
        private readonly Func<ViewModelServiceType, IViewModelService> _viewModelFactory;

        public RoutingController(Func<ViewModelServiceType, IViewModelService> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        [HttpGet("/{url}")]
        public IActionResult StandardView(string url)
        {
            return View(url);
        }

        [HttpGet("/{url}/{viewModelServiceType}")]
        public IActionResult DataView(string url, ViewModelServiceType? viewModelServiceType)
        {            
            // get query params in as a generic object
            return View(url);
        }
    }
}
