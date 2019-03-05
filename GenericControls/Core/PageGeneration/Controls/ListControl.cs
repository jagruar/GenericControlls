using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericControls.Models.Internal.Controls
{
    public class ListControl : BaseControl
    {
        public string ListName { get; set; }
        public string ItemName { get; set; }

        public override string Render()
        {
            var output = new StringBuilder();
            output.AppendLine($"@foreach(var {ItemName.ToLower()} in {Model}.{ListName})");
            output.AppendLine("{");
            output.AppendLine(RenderChildControls());
            output.Append("}");
            return output.ToString();
        }
    }
}
