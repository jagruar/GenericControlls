using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericControls.Models.Internal;
using GenericControls.Models.Internal.Controls;
using GenericControls.Services.Repositories;

namespace GenericControls.Services
{
    public class PageGenerator : IPageGenerator
    {
        private readonly IPageRepository _pageRepository;

        public PageGenerator(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public int GeneratePage(Page page)
        {
            GenerateChildPages(page.Controls);

            var razor = new StringBuilder();
            foreach (IControl control in page.Controls)
            {
                razor.Append(control.Render());
            }

            page.Razor = razor.ToString();
            return _pageRepository.SavePage(page);
            throw new NotImplementedException();
        }

        private int GeneratePartialPage(DataModelControl dataControl)
        {
            var razor = new StringBuilder();
            razor.Append($"@model {dataControl.Model}");
            foreach (IControl control in dataControl.ChildControls)
            {
                razor.Append(control.Render());
            }
            return _pageRepository.SavePartialPage(razor.ToString());            
        }

        /// <summary>
        /// Run through the controls and make sure the model name is correct
        /// </summary>
        private void NameModels(List<IControl> controls)
        {
            // if list, give all child the name of itemName
            // otherwise the closest parents model name
        }

        /// <summary>
        /// Runs through the model and generates all partial pages required
        /// </summary>
        public void GenerateChildPages(List<IControl> controls)
        {
            foreach (IControl control in controls)
            {
                if (control.ControlType == ControlType.DataModel)
                {
                    control.PageId = GeneratePartialPage((DataModelControl)control);
                }
                else
                {
                    GenerateChildPages(control.ChildControls);
                }
            }
        }
    }
}
