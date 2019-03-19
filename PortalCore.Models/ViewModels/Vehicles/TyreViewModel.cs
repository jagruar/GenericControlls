using PortalCore.Models.Internal.Attributes;
using PortalCore.Models.Internal.Types;
using PortalCore.Models.Internal.Types.Identification;

namespace PortalCore.Models.ViewModels.Vehicles
{
    [Model(ModelId.Tyre, "Tyre")]
    public class TyreViewModel : IViewModel
    {
        [Property(PropertyId.Tyre_Pressure, BasicType.Int)]
        public int Pressure { get; set; }
    }
}
