using PortalCore.Models.Internal.Types.Identification;
using System.Collections.Generic;

namespace PortalCore.Models.Internal.Entites
{
    public class Endpoint
    {
        public EndpointId EndpointId { get; set; }
        public string Method { get; set; }
        public bool IsList { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public IEnumerable<Parameter> Parameters { get; set; }

        public ModelId ModelId { get; set; }
        public Model Model { get; set; }
    }
}
