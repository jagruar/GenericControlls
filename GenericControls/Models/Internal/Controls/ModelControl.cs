using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Models.Internal.Controls
{
    public class ModelControl : BaseControl
    {
        public string ModelName { get; set; }
        public override string Render()
        {
            string output = $"<div class=\"{Classes}\">{Render()}</div>";
        }
    }
}
