using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Models.Internal.Controls
{
    public class ModelControl : BaseControl
    {
        public override string Render()
        {
            return $"<div class=\"{Classes}\">{RenderChildControls()}</div>";
        }
    }
}
