using PortalCore.Models.Internal.Types.Identification;
using System.Collections.Generic;

namespace PortalCore.Models.Internal.Entites
{
    public class Model
    {
        public ModelId ModelId { get; set; }
        public string DisplayName { get; set; }
        public string Namespace { get; set; }

        public IEnumerable<Endpoint> Endpoints { get; set; }
        public IEnumerable<Property> Properties { get; set; }
        public IEnumerable<Conditional> Conditionals { get; set; }
        // list endpoints, properties
    }
}
