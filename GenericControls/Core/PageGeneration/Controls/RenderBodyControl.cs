using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Models.Internal.Controls
{
    public class RenderBodyControl : BaseControl
    {
        private const string GUID = "c01c3c6b-d3ec-4303-9416-394963a12f41";

        public override string Render()
        {
            return GUID;
        }
    }
}
