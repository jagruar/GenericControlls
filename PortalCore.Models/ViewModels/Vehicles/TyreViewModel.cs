using PortalCore.Models.Internal.Attributes;
using PortalCore.Models.Internal.Types.Identification;

namespace PortalCore.Models.ViewModels.Vehicles
{
    [Model(ModelId.Tyre, "Tyre")]
    public class TyreViewModel : IViewModel
    {
        public int Pressure { get; set; }
    }
}
