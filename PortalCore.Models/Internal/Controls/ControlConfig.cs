using PortalCore.Models.Internal.Pages;
using PortalCore.Models.Internal.Types;
using PortalCore.Models.Internal.Types.Identification;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalCore.Models.Internal.Controls
{
    public class ControlConfig
    {
        public ControlType ControlType { get; set; }
        public ModelId ModelId { get; set; }
        public EndpointId EndpointId { get; set; }
        public PropertyId PropertyId { get; set; }
        public ConditionalId ConditionalId { get; set; }
        public string Classes { get; set; }
        public string Model { get; set; }
        public List<ControlConfig> ChildControlConfigs { get; set; }
        public string PartialName { get; set; }
        public string HtmlElement { get; set; }

        // Conditional Control
        public bool IsTrue { get; set; }

        // Link control
        public string View { get; set; }

        // For Links
        public string Text { get; set; }
        public bool OpenNewPage { get; set; }
        public string ExternalUrl { get; set; }
        public ParameterValue PrimaryInt { get; set; }
        public ParameterValue SecondaryInt { get; set; }
        public ParameterValue PrimaryString { get; set; }
        public ParameterValue SecondaryString { get; set; }
        public ParameterValue PrimaryBool { get; set; }
        public ParameterValue SecondaryBool { get; set; }
        public ParameterValue PrimaryDateTime { get; set; }
        public ParameterValue SecondaryDateTime { get; set; }
    }
}
