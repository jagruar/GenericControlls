using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Models.Internal.Controls
{
    public class ListControl : BaseControl
    {
        public string ListName { get; set; }
        public string ItemName { get; set; }

        public override string Render()
        {
            return $"@foreach(var {ItemName} in {Model}.{ListName}) {{ {RenderChildControls()} }}";
        }
    }
}
