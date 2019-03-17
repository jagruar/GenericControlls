using PortalCore.Models.Internal.Attributes;
using PortalCore.Models.Internal.Types.Identification;

namespace PortalCore.Models.ViewModels.Vehicles
{
    [Model(ModelId.Driver, "Driver")]
    public class DriverViewModel : IViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
