using PortalCore.Models.Internal.Types.Identification;

namespace PortalCore.Models.Internal.Entites
{
    public class Conditional
    {
        public ConditionalId ConditionalId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public ModelId ModelId { get; set; }
        public Model Model { get; set; }
    }
}
