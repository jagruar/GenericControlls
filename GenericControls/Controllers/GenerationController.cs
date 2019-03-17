using Microsoft.AspNetCore.Mvc;
using PortalCore.Interfaces.Internal;
using PortalCore.Models.Internal.Controls;
using PortalCore.Models.Internal.Entites;
using PortalCore.Models.Internal.Pages;
using PortalCore.Models.Internal.Types;
using PortalCore.Models.Internal.Types.Identification;
using System.Collections.Generic;

namespace PortalCore.Portal.Controllers
{
    [Route("generate")]
    public class GenerationController : Controller
    {
        private readonly IPageGenerator _pageGenerator;

        public GenerationController(IPageGenerator pageGenerator)
        {
            _pageGenerator = pageGenerator;
        }

        public IActionResult Index()
        {
            var masterId = _pageGenerator.GeneratePage(TestMasterPage).PageId;
            _pageGenerator.GeneratePage(TestPage(masterId));
            _pageGenerator.GeneratePage(NotFoundPage(masterId));
            _pageGenerator.GeneratePage(TestDataPage(masterId));
            _pageGenerator.GeneratePage(InternalErrorPage(masterId));

            return new JsonResult(1);
        }

        private PageGenerationModel TestDataPage(int masterId)
        {
            return new PageGenerationModel()
            {
                Page = new Page()
                {
                    PageType = PageType.Partial,
                    MasterPageId = masterId,
                    Name = "mydatapage",
                    Namespace = "PortalCore.Models.ViewModels.Vehicles",
                    Model = "CarViewModel",
                },
                Controls = new List<IControl>()
                {
                    new ListControl()
                    {
                        ControlType = ControlType.List,
                        ListName = "Passengers",
                        ItemName = "Passenger",
                        ChildControls = new List<IControl>()
                        {
                            new ListItemControl()
                            {
                            HtmlElement = "p"
                            }
                        }                        
                    },
                    new PropertyControl()
                    {
                        HtmlElement = "p",
                        Property = "NumberPlate"
                    },
                    new LinkControl()
                    {
                        Text = "Backto the garage",
                        ViewModelService = ModelId.None,
                        View = "thegarage"
                    },
                }
            };            
        }

        private PageGenerationModel NotFoundPage(int masterId)
        {
            return new PageGenerationModel()
            {
                Page = new Page()
                {
                    Name = ReservedPage.NotFound.ToString(),
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

        private PageGenerationModel InternalErrorPage(int masterId)
        {
            return new PageGenerationModel()
            {
                Page = new Page()
                {
                    Name = ReservedPage.InternalError.ToString(),
                    PageType = PageType.Reserved,
                    ReservedPage = ReservedPage.InternalError,
                    MasterPageId = masterId,
                },
                Controls = new List<IControl>()
                {
                    new TextControl()
                    {
                        Text = "You fucked with the query string didn't you"
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
                    PageType = PageType.Full,
                    MasterPageId = masterId,
                    Name = "The Garage",
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
                new LinkControl()
                {
                    Text = "Gooooooogle",
                    OpenNewPage = true,
                    ExternalUrl = "https://www.google.co.uk/"
                },

                new DataModelControl()
                {
                    ControlType = ControlType.ListDataModel,
                    ModelId = ModelId.Car,
                    Method = "GetCars",
                    Name = "All Cars",
                    Namespace = "PortalCore.Models.ViewModels.Vehicles",
                    Model = "CarViewModel",
                    ChildControls = new List<IControl>()
                    {

                        new ModelControl()
                        {
                            ControlType = ControlType.Model,
                            Model = "Driver",
                            ChildControls = new List<IControl>()
                            {
                                new LinkControl()
                                {
                                    ViewModelService = ModelId.Car,
                                    Method = "Mine",
                                    PrimaryKey = "Name",
                                    View = "mydatapage",
                                    Text = "View this car"
                                },
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
