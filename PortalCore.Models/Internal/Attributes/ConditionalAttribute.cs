using PortalCore.Models.Internal.Types.Identification;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalCore.Models.Internal.Attributes
{
    public class ConditionalAttribute : Attribute
    {
        public ConditionalId ConditionalId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public ConditionalAttribute(ConditionalId conditionalId, string displayName, string description)
        {
            ConditionalId = conditionalId;
            DisplayName = displayName;
            Description = description;
        }
    }
}
