using PortalCore.Models.Internal.Types;
using PortalCore.Models.Internal.Types.Identification;

namespace PortalCore.Models.Internal.Entites
{
    public class Parameter
    {
        public ParameterId ParameterId { get; set; }
        public string DisplayName { get; set; }
        public BasicType Type { get; set; }

        public EndpointId EndpointId { get; set; }
        public Endpoint Endpoint { get; set; }
    }
}
