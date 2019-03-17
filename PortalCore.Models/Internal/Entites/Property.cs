using PortalCore.Models.Internal.Types.Identification;

namespace PortalCore.Models.Internal.Entites
{
    public class Property
    {
        public PropertyId PropertyId { get; set; }
        public string DisplayName { get; set; }
        public bool IsList { get; set; }

        public ModelId ModelId { get; set; }
        public Model Model { get; set; }

        public ModelId? ChildModelId { get; set; }
        public Model ChildModel { get; set; }
    }
}
