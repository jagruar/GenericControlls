using PortalCore.Models.Internal.Controls;
using PortalCore.Models.Internal.Entites;
using System.Collections.Generic;

namespace PortalCore.Models.Internal.Pages
{
    public class PageGenerationModel
    {
        public Page Page { get; set; }
        public List<ControlConfig> ControlConfigs { get; set; }
        public List<IControl> Controls { get; set; }
    }
}
