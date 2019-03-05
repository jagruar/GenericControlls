﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericControls.Data.Entities;
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

        /// <summary>
        /// Generates all partial pages required then triggers rendering of
        /// the top level page and saves to the pages table
        /// </summary>
        public Page GeneratePage(PageGenerationModel page)
        {
            GenerateChildPages(page.Controls);

            var razor = new StringBuilder();
            foreach (IControl control in page.Controls)
            {
                razor.Append(control.Render());
            }

            page.Razor = razor.ToString();
            return _pageRepository.SavePage(page.ToPage());
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
                razor.AppendLine($"@model List<{dataControl.NameSpace}.{dataControl.Model}>");
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
                razor.AppendLine($"@model {dataControl.NameSpace}.{dataControl.Model}");
                NameModels(dataControl.ChildControls, "Model");
                foreach (IControl control in dataControl.ChildControls)
                {
                    razor.AppendLine(control.Render());
                }
            }

            var partial = new Page()
            {
                Url = dataControl.PartialName,
                Razor = razor.ToString()
            };

            return _pageRepository.SavePage(partial);            
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
        public void GenerateChildPages(List<IControl> controls)
        {
            if (controls != null)
            {
                foreach (IControl control in controls)
                {
                    if (control.ControlType == ControlType.DataModel || control.ControlType == ControlType.ListDataModel)
                    {
                        ((DataModelControl)control).PartialName = GeneratePartialPage((DataModelControl)control).Url;
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