using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Models.Internal.Controls
{
    public interface IControl
    {
        ControlType ControlType { get; set; }
        int PageId { get; set; }
        string Classes { get; set; }
        string Model { get; set; }
        List<IControl> ChildControls { get; set; }
        string Render();
    }
}
