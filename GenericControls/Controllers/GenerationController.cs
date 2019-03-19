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
                    ModelId = ModelId.Car
                },
                ControlConfigs = new List<ControlConfig>()
                {
                    new ControlConfig()
                    {
                        ControlType = ControlType.List,
                        PropertyId = PropertyId.Car_Passengers,
                        ChildControlConfigs = new List<ControlConfig>()
                        {
                            new ControlConfig()
                            {
                                ControlType = ControlType.ListItem,
                                HtmlElement = "p"
                            }
                        }                        
                    },
                    new ControlConfig()
                    {
                        ControlType = ControlType.Property,
                        PropertyId = PropertyId.Car_NumberPlate,
                        HtmlElement = "p"
                    },
                    new ControlConfig()
                    {
                        ControlType = ControlType.Link,
                        ModelId = ModelId.None,
                        View = "thegarage",
                        Text = "Back to the garage"
                    }
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
                ControlConfigs = new List<ControlConfig>()
                {
                    new ControlConfig()
                    {
                        ControlType = ControlType.Text,
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
                ControlConfigs = new List<ControlConfig>()
                {
                    new ControlConfig()
                    {
                        ControlType = ControlType.Text,
                        Text = "Fucked with query string"
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
            ControlConfigs = new List<ControlConfig>()
            {
                new ControlConfig()
                {
                    ControlType = ControlType.Text,
                    Text = "From master"
                },
                new ControlConfig()
                {
                    ControlType = ControlType.RenderBody
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
                ControlConfigs = new List<ControlConfig>()
                {
                    new ControlConfig()
                    {
                        ControlType = ControlType.Link,
                        OpenNewPage = true,
                        ExternalUrl = "https://www.google.co.uk/"
                    },
                    new ControlConfig()
                    {
                        ControlType = ControlType.Text,
                        Text = "List of cars below"
                    },
                    new ControlConfig()
                    {
                        ControlType = ControlType.ListDataModel,
                        ModelId = ModelId.Car,
                        EndpointId = EndpointId.Car_GetCars,
                        PartialName = "My Cars",
                        ChildControlConfigs = new List<ControlConfig>()
                        {
                            new ControlConfig()
                            {
                                ControlType = ControlType.Model,
                                PropertyId = PropertyId.Car_Driver,
                                ChildControlConfigs = new List<ControlConfig>()
                                {
                                    new ControlConfig()
                                    {
                                        ControlType = ControlType.Property,
                                        PropertyId = PropertyId.Driver_Name,
                                        HtmlElement = "p"
                                    },
                                    new ControlConfig()
                                    {
                                        ControlType = ControlType.Link,
                                        ModelId = ModelId.Car,
                                        EndpointId = EndpointId.Car_Mine,
                                        View = "mydatapage",
                                        Text = "View this car",
                                        PrimaryString = new ParameterValue()
                                        {
                                            PropertyId = PropertyId.Driver_Name
                                        }                                        
                                    }
                                }
                            },
                            new ControlConfig()
                            {
                                ControlType = ControlType.List,
                                PropertyId = PropertyId.Car_Tyres,
                                ChildControlConfigs = new List<ControlConfig>()
                                {
                                    new ControlConfig()
                                    {
                                        ControlType = ControlType.Property,
                                        PropertyId = PropertyId.Tyre_Pressure,
                                        HtmlElement = "p"
                                    }
                                }
                            },
                            new ControlConfig()
                            {
                                ControlType = ControlType.Conditional,
                                ConditionalId = ConditionalId.Car_IsSafe,
                                IsTrue = false,
                                ChildControlConfigs = new List<ControlConfig>()
                                {
                                    new ControlConfig()
                                    {
                                        ControlType = ControlType.Html,
                                        HtmlElement = "p",
                                        ChildControlConfigs = new List<ControlConfig>()
                                        {
                                            new ControlConfig()
                                            {
                                                ControlType = ControlType.Text,
                                                Text = "This car is unsafe"
                                            }
                                        }
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
