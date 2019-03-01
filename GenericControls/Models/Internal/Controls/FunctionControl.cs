using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Models.Internal.Controls
{
    public class FunctionControl : BaseControl
    {
        public string Container { get; set; }
        public string Function { get; set; }

        public override string Render()
        {
            return $"<{Container} onclick=\"{Function}\">{RenderChildControls()}</{Container}>";
        }
    }
}
