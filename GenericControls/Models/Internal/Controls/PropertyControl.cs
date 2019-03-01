using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Models.Internal.Controls
{
    public class PropertyControl : BaseControl
    {
        public string Name { get; set; }
        public string Container { get; set; }

        public override string Render()
        {
            return $"<{Container} class=\"{Classes}\">@{Model}.{Name}</{Container}>";
        }
    }
}
