using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericControls.Models.Internal;
using GenericControls.Models.Internal.Controls;
using GenericControls.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GenericControls.Controllers
{
    public class TestController : Controller
    {
        private readonly IPageGenerator _pageGenerator;

        public TestController(IPageGenerator pageGenerator)
        {
            _pageGenerator = pageGenerator;
        }

        public IActionResult GeneratePage()
        {
            _pageGenerator.GeneratePage(TestPage);
            return new JsonResult(1);
        }

        private PageGenerationModel TestPage => new PageGenerationModel()
        {
            Url = "/Views/Pages/test.cshtml",
            Controls = new List<IControl>()
            {
                new HtmlControl()
                {
                    HtmlElement = "h1",
                    ChildControls = new List<IControl>()
                    {
                        new TextControl()
                        {
                            Text = "This displays a list of cars!"
                        }
                    }
                },
                new DataModelControl()
                {
                    ControlType = ControlType.ListDataModel,
                    ViewModelServiceType = ViewModelServiceType.Car,
                    Method = "GetCars",
                    PartialName = "/Views/Pages/AllCars.cshtml",
                    NameSpace = "GenericControls.Models.Cars",
                    Model = "Car",
                    ChildControls = new List<IControl>()
                    {  
                        new ModelControl()
                        {
                            ControlType = ControlType.Model,
                            Model = "Driver",
                            ChildControls = new List<IControl>()
                            {
                                new PropertyControl()
                                {
                                    HtmlElement = "p",
                                    Property = "Name"
                                },
                                new PropertyControl()
                                {
                                    HtmlElement = "p",
                                    Property = "Age"
                                }
                            }                            
                        },
                        new ConditionalControl()
                        {
                            FunctionName = "IsSafe",
                            IsTrue = true,
                            ChildControls = new List<IControl>()
                            {
                                new HtmlControl()
                                {
                                    HtmlElement = "h4",
                                    ChildControls = new List<IControl>()
                                    {
                                        new TextControl()
                                        {
                                            Text = "This geezer has safe tyres"
                                        }                                        
                                    }
                                }
                            }
                        },
                        new ConditionalControl()
                        {
                            FunctionName = "IsSafe",
                            IsTrue = false,
                            ChildControls = new List<IControl>()
                            {
                                new HtmlControl()
                                {
                                    HtmlElement = "h4",
                                    ChildControls = new List<IControl>()
                                    {
                                        new TextControl()
                                        {
                                            Text = "This geezer is Crazy!"
                                        }
                                    }
                                }
                            }
                        },
                        new ListControl()
                        {
                            ControlType = ControlType.List,
                            ListName = "Tyres",
                            ItemName = "Tyre",
                            ChildControls = new List<IControl>()
                            {
                                new PropertyControl()
                                {
                                    HtmlElement = "p",
                                    Property = "Pressure",
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}
