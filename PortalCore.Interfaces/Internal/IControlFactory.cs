using PortalCore.Models.Internal.Controls;
using System.Collections.Generic;

namespace PortalCore.Interfaces.Internal
{
    public interface IControlFactory
    {
        List<IControl> BuildControls(List<ControlConfig> controlConfigs);
    }
}
