using PortalCore.Models.Internal.Types;
using PortalCore.Models.Internal.Types.Identification;
using System.Collections.Generic;

namespace PortalCore.Models.Internal.Controls
{
    public interface IControl
    {
        ControlType ControlType { get; set; }
        string Classes { get; set; }
        string Model { get; set; }
        List<IControl> ChildControls { get; set; }


        string Render();
    }
}
