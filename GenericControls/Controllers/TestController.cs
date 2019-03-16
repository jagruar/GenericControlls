using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericControls.Data.Entities;
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

        public IActionResult Main()
        {
            var masterId = _pageGenerator.GeneratePage(TestMasterPage).PageId;
            _pageGenerator.GeneratePage(TestPage(masterId));
            _pageGenerator.GeneratePage(NotFoundPage(masterId));

            return new JsonResult(1);
        }

        public IActionResult Partial()
        {
            
            return new JsonResult(1);
        }

        private PageGenerationModel NotFoundPage(int masterId)
        {
            return new PageGenerationModel()
            {
                Page = new Page()
                {
                    PageType = PageType.Reserved,
                    ReservedPage = ReservedPage.NotFound,
                    MasterPageId = masterId,
                },
                Controls = new List<IControl>()
                {
                    new TextControl()
                    {
                        Text = "Fucked it m8"
                    }
                }
            };            
        }

        private PageGenerationModel TestMasterPage => new PageGenerationModel()
        {
            Page = new Page()
            {
                PageType = PageType.Master,
                MasterPageId = 0,
                Name = "MyMaster"
            },
            Controls = new List<IControl>()
            {
                new HtmlControl()
                {
                    HtmlElement = "h1",
                    ChildControls = new List<IControl>()
                    {
                        new TextControl()
                        {
                            Text = "This is from my master page"
                        }
                    }
                },
                new RenderBodyControl(),
                new HtmlControl()
                {
                    HtmlElement = "h1",
                    ChildControls = new List<IControl>()
                    {
                        new TextControl()
                        {
                            Text = "This is also from my master page"
                        }
                    }
                }
            }
        };

        private PageGenerationModel TestPage(int masterId)
        {
            return new PageGenerationModel()
            {
                Page = new Page()
                {
                    PageType = PageType.Main,
                    MasterPageId = masterId,
                    Name = "test",
                },
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
                    Name = "All_Cars",
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
}
