using PortalCore.Interfaces.Internal;
using PortalCore.Interfaces.Internal.DataAccess;
using PortalCore.Models.Internal.Controls;
using PortalCore.Models.Internal.Entites;
using PortalCore.Models.Internal.Pages;
using PortalCore.Models.Internal.Types;
using PortalCore.Models.Internal.Types.Identification;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalCore.Services.Internal.Pages
{
    public class ControlFactory : IControlFactory
    {
        private readonly IModelRepository _modelRepository;

        public ControlFactory(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public List<IControl> BuildControls(List<ControlConfig> controlConfigs)
        {
            var controls = new List<IControl>();
            foreach(var controlConfig in controlConfigs)
            {
                IControl control = null;
                switch (controlConfig.ControlType)
                {
                    case ControlType.DataModel: 
                    case ControlType.ListDataModel:
                        control = BuildDataModelControl(controlConfig);                        
                        break;
                    case ControlType.Model:
                        control = BuildModelControl(controlConfig);
                        break;
                    case ControlType.Property:
                        control = BuildPropertyControl(controlConfig);
                        break;
                    case ControlType.List:
                        control = BuildListControl(controlConfig);
                        break;
                    case ControlType.Conditional:
                        control = BuildConditionalControl(controlConfig);
                        break;
                    case ControlType.Link:
                        control = BuildLinkControl(controlConfig);
                        break;
                    case ControlType.Html:
                        control = BuildHtmlControl(controlConfig);
                        break;
                    case ControlType.ListItem:
                        control = BuildListItemControl(controlConfig);
                        break;
                    case ControlType.RenderBody:
                        control = BuildRenderBodyControl(controlConfig);
                        break;
                    case ControlType.Text:
                        control = BuildTextControl(controlConfig);
                        break;

                }
                if (controlConfig.ChildControlConfigs != null)
                {
                    control.ChildControls = BuildControls(controlConfig.ChildControlConfigs);
                }                
                controls.Add(control);
            }
            return controls;
        }

        private IControl BuildTextControl(ControlConfig controlConfig)
        {
            return new TextControl()
            {
                ControlType = ControlType.Text,
                Text = controlConfig.Text
            };
        }

        private IControl BuildRenderBodyControl(ControlConfig controlConfig)
        {
            return new RenderBodyControl()
            {
                ControlType = ControlType.RenderBody,
            };
        }

        private IControl BuildListItemControl(ControlConfig controlConfig)
        {
            return new ListItemControl()
            {
                ControlType = ControlType.ListItem,
                Classes = controlConfig.Classes,
                HtmlElement = controlConfig.HtmlElement
            };
        }

        private IControl BuildHtmlControl(ControlConfig controlConfig)
        {
            return new HtmlControl()
            {
                ControlType = ControlType.Html,
                Classes = controlConfig.Classes,
                HtmlElement = controlConfig.HtmlElement
            };
        }

        private DataModelControl BuildDataModelControl(ControlConfig controlConfig)
        {
            Model model = _modelRepository.GetModel(controlConfig.ModelId);
            Endpoint endpoint = _modelRepository.GetEndpoint(controlConfig.EndpointId);
            return new DataModelControl()
            {
                ControlType = controlConfig.ControlType,
                Name = controlConfig.PartialName,
                ModelId = model.ModelId,
                Namespace = model.Namespace,
                Model = model.Name,
                EndpointId = endpoint.EndpointId,
                Method = endpoint.Method,
                Classes = controlConfig.Classes,
                PrimaryInt = GetParameterString(controlConfig.PrimaryInt, BasicType.Int),
                SecondaryInt = GetParameterString(controlConfig.SecondaryInt, BasicType.Int),
                PrimaryString = GetParameterString(controlConfig.PrimaryString, BasicType.String),
                SecondaryString = GetParameterString(controlConfig.SecondaryString, BasicType.String),
                PrimaryBool = GetParameterString(controlConfig.PrimaryBool, BasicType.Bool),
                SecondaryBool = GetParameterString(controlConfig.SecondaryBool, BasicType.Bool),
                PrimaryDateTime = GetParameterString(controlConfig.PrimaryDateTime, BasicType.DateTime),
                SecondaryDateTime = GetParameterString(controlConfig.SecondaryDateTime, BasicType.DateTime)
            };
        }

        private IControl BuildModelControl(ControlConfig controlConfig)
        {
            Property property = _modelRepository.GetProperty(controlConfig.PropertyId);
            return new ModelControl()
            {
                ControlType = ControlType.Model,
                Model = property.Name,
                Classes = controlConfig.Classes
            };
        }

        private IControl BuildPropertyControl(ControlConfig controlConfig)
        {
            Property property = _modelRepository.GetProperty(controlConfig.PropertyId);
            return new PropertyControl()
            {
                ControlType = ControlType.Property,
                Property = property.Name,
                Classes = controlConfig.Classes,
                HtmlElement = controlConfig.HtmlElement
            };
        }

        private IControl BuildListControl(ControlConfig controlConfig)
        {
            Property property = _modelRepository.GetProperty(controlConfig.PropertyId);
            return new ListControl()
            {
                ControlType = ControlType.List,
                ListName = property.Name,
                ItemName = property.Name.Substring(1, property.Name.Length - 1),
                Classes = controlConfig.Classes,
            };

            throw new NotImplementedException();
        }

        private IControl BuildConditionalControl(ControlConfig controlConfig)
        {
            Conditional conditional = _modelRepository.GetConditional(controlConfig.ConditionalId);
            return new ConditionalControl()
            {
                ControlType = ControlType.Conditional,
                FunctionName = conditional.Name,
                IsTrue = controlConfig.IsTrue
            };
        }

        private IControl BuildLinkControl(ControlConfig controlConfig)
        {
            var control = new LinkControl()
            {
                ControlType = ControlType.Link,
                OpenNewPage = controlConfig.OpenNewPage,
                ExternalUrl = controlConfig.ExternalUrl,
                Text = controlConfig.Text,
                View = controlConfig.View,
                ModelId = controlConfig.ModelId,
            };

            if (controlConfig.EndpointId != EndpointId.None)
            {
                control.Method = _modelRepository.GetEndpoint(controlConfig.EndpointId).Method;
                control.PrimaryInt = GetParameterString(controlConfig.PrimaryInt, BasicType.Int);
                control.SecondaryInt = GetParameterString(controlConfig.SecondaryInt, BasicType.Int);
                control.PrimaryString = GetParameterString(controlConfig.PrimaryString, BasicType.String);
                control.SecondaryString = GetParameterString(controlConfig.SecondaryString, BasicType.String);
                control.PrimaryBool = GetParameterString(controlConfig.PrimaryBool, BasicType.Bool);
                control.SecondaryBool = GetParameterString(controlConfig.SecondaryBool, BasicType.Bool);
                control.PrimaryDateTime = GetParameterString(controlConfig.PrimaryDateTime, BasicType.DateTime);
                control.SecondaryDateTime = GetParameterString(controlConfig.SecondaryDateTime, BasicType.DateTime);
            }

            return control;
        }

        private ParameterString GetParameterString(ParameterValue parameter, BasicType basicType)
        {
            if (parameter != null)
            {
                if (parameter.PropertyId.HasValue)
                {
                    return new ParameterString()
                    {
                        IsFromModel = true,
                        Value = _modelRepository.GetProperty(parameter.PropertyId.Value).Name
                    };
                }
                else
                {
                    var parameterString = new ParameterString()
                    {
                        IsFromModel = false
                    };
                    switch (basicType)
                    {
                        case (BasicType.Int):
                            if (parameter.IntValue.HasValue)
                            {
                                parameterString.Value = parameter.IntValue.Value.ToString();
                            }
                            break;
                        case (BasicType.String):
                            parameterString.Value = parameter.StringValue;
                            break;
                        case (BasicType.Bool):
                            if (parameter.BoolValue.HasValue)
                            {
                                parameterString.Value = parameter.BoolValue.Value.ToString();
                            }
                            break;
                        case (BasicType.DateTime):
                            if (parameter.DateTimeValue.HasValue)
                            {
                                parameterString.Value = parameter.DateTimeValue.Value.ToString();
                            }
                            break;
                    }
                    return parameterString;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
