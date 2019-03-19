using PortalCore.Models.Internal.Types.Identification;
using System.Collections.Generic;

namespace PortalCore.Models.Internal.Entites
{
    public class Model
    {
        public ModelId ModelId { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Namespace { get; set; }

        public IEnumerable<Endpoint> Endpoints { get; set; }

        /// <summary>
        /// Properties on this model
        /// </summary>
        public IEnumerable<Property> ChildProperties { get; set; }

        /// <summary>
        /// Properties on other models where this is the type
        /// </summary>
        public IEnumerable<Property> ParentProperties { get; set; }
        public IEnumerable<Conditional> Conditionals { get; set; }
    }
}
