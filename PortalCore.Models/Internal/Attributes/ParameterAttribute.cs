using PortalCore.Models.Internal.Types;
using PortalCore.Models.Internal.Types.Identification;
using System;

namespace PortalCore.Models.Internal.Attributes
{
    public class ParameterAttribute : Attribute
    {
        public ParameterId ParameterId { get; set; }
        public string DisplayName { get; set; }
        public BasicType Type { get; set; }

        public ParameterAttribute(ParameterId parameterId, string displayName, BasicType type)
        {
            ParameterId = parameterId;
            DisplayName = displayName;
            Type = type;
        }
    }
}
