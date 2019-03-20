using Microsoft.AspNetCore.Mvc;
using PortalCore.Helpers;
using PortalCore.Interfaces.Portal;
using PortalCore.Models.Internal.Types;
using PortalCore.Models.Internal.Types.Identification;
using System;

namespace PortalCore.Portal.Controllers
{
    [Route("")]
    public class RoutingController : Controller
    {
        private readonly IModelService _modelService;

        public RoutingController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet("")]
        public IActionResult Home()
        {
            return View("home");
        }

        [HttpGet("/{url}")]
        public IActionResult StandardView(string url)
        {
            return View(url.ToLower());
        }

        [HttpGet("async/{modelId}/{method}")]
        public object PostData(ModelId modelId, string method, [FromBody] object model)
        {
            return _modelService.ProcessModel(modelId, method, model);
        }

        [HttpGet("/{modelId}/{method}")]
        public IActionResult GetViewData(
            [FromQuery]string view, 
            ModelId modelId,
            string method,
            [FromQuery]int? primaryId,
            [FromQuery]int? secondaryId,
            [FromQuery]string primaryKey,
            [FromQuery]string secondaryKey,
            [FromQuery]bool? primaryOption,
            [FromQuery]bool? secondaryOption,
            [FromQuery]DateTime? primaryDateTime,
            [FromQuery]DateTime? secondaryDateTime)
        {
            object[] parameters = ParameterHelper.GetParameters(
                primaryId, 
                secondaryId, 
                primaryKey,
                secondaryKey,
                primaryOption,
                secondaryOption,
                primaryDateTime,
                secondaryDateTime);
            
            try
            {
                object viewModel = _modelService.GetViewModel(modelId, method, parameters);
                return View(view.ToLower(), viewModel);
            }
            catch
            {
                return View(ReservedPage.InternalError.ToString());
            }            
        }        
    }
}
