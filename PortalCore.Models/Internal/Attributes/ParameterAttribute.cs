using System;

namespace PortalCore.Models.Internal.Attributes
{
    public class ParameterAttribute : Attribute
    {
        public string DisplayName { get; set; }

        public ParameterAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
