using PortalCore.Models.Internal.Attributes;
using PortalCore.Models.Internal.Types;
using PortalCore.Models.Internal.Types.Identification;

namespace PortalCore.Models.ViewModels.Vehicles
{
    [Model(ModelId.Driver, "Driver")]
    public class DriverViewModel : IViewModel
    {
        [Property(PropertyId.Driver_Name, BasicType.String)]
        public string Name { get; set; }

        [Property(PropertyId.Driver_Age, BasicType.Int)]
        public int Age { get; set; }
    }
}
