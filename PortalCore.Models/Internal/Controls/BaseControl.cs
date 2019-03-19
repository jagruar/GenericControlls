using PortalCore.Models.Internal.Types;
using System.Collections.Generic;
using System.Text;

namespace PortalCore.Models.Internal.Controls
{
    public abstract class BaseControl : IControl
    {
        // public string Container { get; set; }
        public ControlType ControlType { get; set; }
        public string Classes { get; set; }
        public string Model { get; set; }
        public List<IControl> ChildControls { get; set; }

        public abstract string Render();

        public string RenderChildControls()
        {
            var output = new StringBuilder();
            if (ChildControls != null)
            {
                foreach (var control in ChildControls)
                {
                    output.AppendLine(control.Render());
                }
            }
            return output.ToString();
        }
    }
}
