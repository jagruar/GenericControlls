using GenericControls.Models.Internal;
using GenericControls.Services.Repositories;
using GenericControls.Services.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericControls.Services.CustomTagHelpers
{
    public class DataPartialTagHelper : TagHelper
    {
        private readonly Func<ViewModelServiceType, IViewModelService> _viewModelFactory;
        private readonly IPageRepository _pageRepository;
        private readonly ICompositeViewEngine _viewEngine;
        private readonly IViewBufferScope _viewBufferScope;

        public string Name { get; set; }
        public ViewModelServiceType ServiceType { get; set; }
        public string Action { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public DataPartialTagHelper(
            Func<ViewModelServiceType, IViewModelService> viewModelFactory,
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
            ViewEngineResult result = _viewEngine.GetView(string.Empty, $"/{Name}", isMainPage: false);
            var viewBuffer = new ViewBuffer(_viewBufferScope, result.ViewName, ViewBuffer.PartialViewPageSize);
            using (var writer = new ViewBufferTextWriter(viewBuffer, Encoding.UTF8))
            {
                await RenderPartialViewAsync(writer, GetViewModel(), result.View);
                output.Content.SetHtmlContent(viewBuffer);
            }
        }

        private object GetViewModel()
        {
            if (ServiceType == ViewModelServiceType.None)
            {
                return null;
            }
            IViewModelService modelService = _viewModelFactory(ServiceType);
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
