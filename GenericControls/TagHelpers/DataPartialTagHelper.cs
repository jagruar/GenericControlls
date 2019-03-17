﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PortalCore.Interfaces.Internal.DataAccess;
using PortalCore.Interfaces.Portal;
using PortalCore.Models.Internal.Types;
using PortalCore.Models.Internal.Types.Identification;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PortalCore.Portal.TagHelpers
{
    public class DataPartialTagHelper : TagHelper
    {
        private readonly Func<ModelId, IViewModelService> _viewModelFactory;
        private readonly IPageRepository _pageRepository;
        private readonly ICompositeViewEngine _viewEngine;
        private readonly IViewBufferScope _viewBufferScope;

        public string PageId { get; set; }
        public ModelId ModelType { get; set; }
        public string Action { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public DataPartialTagHelper(
            Func<ModelId, IViewModelService> viewModelFactory,
            IPageRepository pageRepository,
            ICompositeViewEngine viewEngine,
            IViewBufferScope viewBufferScope)
        {
            _viewModelFactory = viewModelFactory;
            _pageRepository = pageRepository;
            _viewEngine = viewEngine;
            _viewBufferScope = viewBufferScope;

        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            ViewEngineResult result = _viewEngine.GetView(string.Empty, $"/{PageId}", isMainPage: false);
            var viewBuffer = new ViewBuffer(_viewBufferScope, result.ViewName, ViewBuffer.PartialViewPageSize);
            using (var writer = new ViewBufferTextWriter(viewBuffer, Encoding.UTF8))
            {
                await RenderPartialViewAsync(writer, GetViewModel(), result.View);
                output.Content.SetHtmlContent(viewBuffer);
            }
        }

        private object GetViewModel()
        {
            if (ModelType == ModelId.None)
            {
                return null;
            }
            IViewModelService modelService = _viewModelFactory(ModelType);
            Type serviceType = modelService.GetType();
            MethodInfo method = serviceType.GetMethod(Action);
            return method.Invoke(modelService, null);
        }

        private async Task RenderPartialViewAsync(TextWriter writer, object model, IView view)
        {
            var newViewData = new ViewDataDictionary<object>(ViewContext.ViewData, model);
            var partialViewContext = new ViewContext(ViewContext, view, newViewData, writer);
            using (view as IDisposable)
            {
                await view.RenderAsync(partialViewContext);
            }
        }
    }
}
