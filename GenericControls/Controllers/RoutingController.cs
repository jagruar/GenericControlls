using Microsoft.AspNetCore.Mvc;
using PortalCore.Interfaces.Portal;
using PortalCore.Models.Internal.Types;
using PortalCore.Models.Internal.Types.Identification;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PortalCore.Portal.Controllers
{
    [Route("")]
    public class RoutingController : Controller
    {
        private readonly Func<ModelId, IViewModelService> _viewModelServiceFactory;

        public RoutingController(Func<ModelId, IViewModelService> viewModelFactory)
        {
            _viewModelServiceFactory = viewModelFactory;
        }

        [HttpGet("/{url}")]
        public IActionResult StandardView(string url)
        {
            return View(url.ToLower());
        }

        [HttpGet("/{serviceType}/{method}")]
        public IActionResult DataView(
            [FromQuery]string view, 
            ModelId serviceType,
            string method,
            [FromQuery]int? primaryId,
            [FromQuery]int? secondaryId,
            [FromQuery]string primaryKey,
            [FromQuery]string secondaryKey,
            [FromQuery]bool? primaryOption,
            [FromQuery]bool? secondaryOption)
        {
            object[] parametersArray = GetParameters(
                primaryId, 
                secondaryId, 
                primaryKey,
                secondaryKey,
                primaryOption,
                secondaryOption);
            
            try
            {
                IViewModelService modelService = _viewModelServiceFactory(serviceType);
                Type typeOfService = modelService.GetType();
                MethodInfo methodInfo = typeOfService.GetMethod(method);
                object viewModel = methodInfo.Invoke(modelService, parametersArray);
                return View(view.ToLower(), viewModel);
            }
            catch
            {
                return View(ReservedPage.InternalError.ToString());
            }            
        }

        private object[] GetParameters(
            int? primaryId, 
            int? secondaryId,
            string primaryKey,
            string secondaryKey,
            bool? primaryOption,
            bool? secondaryOption)
        {
            var parameters = new List<object>();
            if (primaryId.HasValue)
            {
                parameters.Add(primaryId.Value);
            }
            if (secondaryId.HasValue)
            {
                parameters.Add(secondaryId.Value);
            }
            if (!string.IsNullOrEmpty(primaryKey))
            {
                parameters.Add(primaryKey);
            }
            if (!string.IsNullOrEmpty(secondaryKey))
            {
                parameters.Add(secondaryKey);
            }
            if (primaryOption.HasValue)
            {
                parameters.Add(primaryOption.Value);
            }
            if (secondaryOption.HasValue)
            {
                parameters.Add(secondaryOption.Value);
            }
            return parameters.ToArray();
        }
    }
}
