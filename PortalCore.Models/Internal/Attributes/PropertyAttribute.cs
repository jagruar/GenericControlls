using PortalCore.Models.Internal.Types;
using PortalCore.Models.Internal.Types.Identification;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalCore.Models.Internal.Attributes
{
    /// <summary>
    /// For installation of properties.
    /// </summary>
    public class PropertyAttribute : Attribute
    {
        public PropertyId PropertyId { get; set; }

        /// <summary>
        /// Use on any property which is a complex type or a list of complex types
        /// </summary>
        public ModelId? ChildModelId { get; set; }

        public BasicType? Type { get; set; }

        public bool IsList { get; set; }

        /// <summary>
        /// Display name will be taken as the property name if omitted
        /// </summary>
        public string DisplayName { get; set; }

        public PropertyAttribute(PropertyId propertyId, ModelId childModelId, string displayName = null, bool isList = false)
        {
            PropertyId = propertyId;
            ChildModelId = childModelId;
            DisplayName = displayName;
            IsList = isList;
        }

        public PropertyAttribute(PropertyId propertyId, BasicType basicType, string displayName = null, bool isList = false)
        {
            PropertyId = propertyId;
            Type = basicType;
            DisplayName = displayName;
            IsList = isList;
        }
    }
}
