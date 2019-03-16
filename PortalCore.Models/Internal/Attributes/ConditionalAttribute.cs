using System;
using System.Collections.Generic;
using System.Text;

namespace PortalCore.Models.Internal.Attributes
{
    public class ConditionalAttribute : Attribute
    {
        public string DisplayName { get; set; }

        public ConditionalAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
