using PortalCore.Models.Internal.Types.Identification;
using System;

namespace PortalCore.Models.Internal.Attributes
{
    public class EndpointAttribute : Attribute
    {
        public EndpointId EndpointId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Does this endpoint return a list of the object
        /// </summary>
        public bool IsList { get; set; }

        public EndpointAttribute(EndpointId endpointId, string displayName, string description, bool isList = false)
        {
            EndpointId = endpointId;
            DisplayName = displayName;
            Description = description;
            IsList = isList;
        }
    }
}
