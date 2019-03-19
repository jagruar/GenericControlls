using PortalCore.Interfaces.Internal;
using PortalCore.Interfaces.Internal.DataAccess;
using PortalCore.Models.Internal.Controls;
using PortalCore.Models.Internal.Entites;
using PortalCore.Models.Internal.Pages;
using PortalCore.Models.Internal.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalCore.Services.Internal.Pages
{
    public class PageGenerator : IPageGenerator
    {
        private readonly IPageRepository _pageRepository;
        private readonly IControlFactory _controlFactory;
        private readonly IModelRepository _modelRepository;

        public PageGenerator(IPageRepository pageRepository, IControlFactory controlFactory, IModelRepository modelRepository)
        {
            _pageRepository = pageRepository;
            _controlFactory = controlFactory;
            _modelRepository = modelRepository;
        }

        /// <summary>
        /// Generates all partial pages required then triggers rendering of
        /// the top level page and saves to the pages table
        /// </summary>
        public Page GeneratePage(PageGenerationModel page)
        {
            page.Controls = _controlFactory.BuildControls(page.ControlConfigs);
            GenerateChildPages(page.Controls);

            var razor = new StringBuilder();

            if (page.Page.PageType == PageType.Partial)
            {
                Model model = _modelRepository.GetModel(page.Page.ModelId.Value);
                razor.AppendLine($"@model {model.Namespace}.{model.Name}");
                NameModels(page.Controls, "Model");
            }

            foreach (IControl control in page.Controls)
            {
                razor.AppendLine(control.Render());
            }

            _pageRepository.SavePage(page.Page);

            View view = new View()
            {
                PageId = page.Page.PageId,
                Razor = razor.ToString()
            };
            _pageRepository.SaveView(view);

            return page.Page;
        }

        /// <summary>
        /// Generates a page with a data model and saves to the Partials table
        /// </summary>
        /// <param name="dataControl"></param>
        /// <returns></returns>
        private Page GeneratePartialPage(DataModelControl dataControl)
        {
            GenerateChildPages(dataControl.ChildControls);
            var razor = new StringBuilder();

            if (dataControl.ControlType == ControlType.ListDataModel)
            {
                razor.AppendLine($"@model List<{dataControl.Namespace}.{dataControl.Model}>");
                razor.AppendLine($"@foreach(var {dataControl.Model.ToLower()} in Model)");
                razor.AppendLine("{");
                NameModels(dataControl.ChildControls, dataControl.Model.ToLower());
                if (dataControl.ChildControls != null)
                {
                    foreach (IControl control in dataControl.ChildControls)
                    {
                        razor.AppendLine(control.Render());
                    }
                }
                razor.Append("}");
            }
            else
            {
                razor.AppendLine($"@model {dataControl.Namespace}.{dataControl.Model}");
                NameModels(dataControl.ChildControls, "Model");
                foreach (IControl control in dataControl.ChildControls)
                {
                    razor.AppendLine(control.Render());
                }
            }

            Page partial = new Page()
            {
                Name = dataControl.Name,
                PageType = PageType.Partial
            };
            _pageRepository.SavePage(partial);

            View view = new View()
            {
                PageId = partial.PageId,
                Razor = razor.ToString()
            };
            _pageRepository.SaveView(view);

            return partial;
        }

        /// <summary>
        /// Run through the controls and make sure the model name is correct
        /// </summary>
        private void NameModels(List<IControl> controls, string baseModel)
        {
            if (controls != null)
            {
                foreach (IControl control in controls)
                {
                    switch (control.ControlType)
                    {
                        case (ControlType.Model):
                            control.Model = $"{baseModel}.{control.Model}";
                            NameModels(control.ChildControls, control.Model);
                            break;
                        case (ControlType.List):
                            control.Model = baseModel;
                            NameModels(control.ChildControls, ((ListControl)control).ItemName.ToLower());
                            break;
                        default:
                            control.Model = baseModel;
                            NameModels(control.ChildControls, control.Model);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Runs through the model and generates all partial pages required
        /// </summary>
        private void GenerateChildPages(List<IControl> controls)
        {
            if (controls != null)
            {
                foreach (IControl control in controls)
                {
                    if (control.ControlType == ControlType.DataModel || control.ControlType == ControlType.ListDataModel)
                    {
                        ((DataModelControl)control).PartialId = GeneratePartialPage((DataModelControl)control).PageId;
                    }
                    else
                    {
                        GenerateChildPages(control.ChildControls);
                    }
                }
            }
        }
    }
}
