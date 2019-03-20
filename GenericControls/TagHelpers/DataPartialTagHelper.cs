using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PortalCore.Helpers;
using PortalCore.Interfaces.Internal.DataAccess;
using PortalCore.Interfaces.Portal;
using PortalCore.Models.Internal.Types.Identification;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PortalCore.Portal.TagHelpers
{
    public class DataPartialTagHelper : TagHelper
    {
        private readonly IModelService _modelService;
        private readonly IPageRepository _pageRepository;
        private readonly ICompositeViewEngine _viewEngine;
        private readonly IViewBufferScope _viewBufferScope;

        public string PartialId { get; set; }
        public ModelId ModelType { get; set; }
        public string Action { get; set; }

        // Parameters
        public int? PrimaryId { get; set; }
        public int? SecondaryId { get; set; }
        public string PrimaryKey { get; set; }
        public string SecondaryKey { get; set; }
        public bool? PrimaryOption { get; set; }
        public bool? SecondaryOption { get; set; }
        public DateTime? PrimaryDateTime { get; set; }
        public DateTime? SecondaryDateTime { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public DataPartialTagHelper(
            IModelService modelService,
            IPageRepository pageRepository,
            ICompositeViewEngine viewEngine,
            IViewBufferScope viewBufferScope)
        {
            _modelService = modelService;
            _pageRepository = pageRepository;
            _viewEngine = viewEngine;
            _viewBufferScope = viewBufferScope;

        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            ViewEngineResult result = _viewEngine.GetView(string.Empty, $"/{PartialId}", isMainPage: false);
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

            object[] parameters = ParameterHelper.GetParameters(
                PrimaryId,
                SecondaryId,
                PrimaryKey,
                SecondaryKey,
                PrimaryOption,
                SecondaryOption,
                PrimaryDateTime,
                SecondaryDateTime);

            return _modelService.GetViewModel(ModelType, Action, parameters);
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
