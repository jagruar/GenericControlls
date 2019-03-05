using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Models.Internal.Controls
{
    public class TextControl : BaseControl
    {
        public string Text { get; set; }

        public override string Render()
        {
            return Text;
        }
    }
}
