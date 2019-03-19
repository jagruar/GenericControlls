using PortalCore.Models.Internal.Types.Identification;
using System.Text;

namespace PortalCore.Models.Internal.Controls
{
    public class ConditionalControl : BaseControl
    {
        public string FunctionName { get; set; }
        public bool IsTrue { get; set; }

        public override string Render()
        {
            string notOperator = IsTrue ? string.Empty : "!";
            var output = new StringBuilder();
            output.AppendLine($"@if({notOperator}{Model}.{FunctionName}())");
            output.AppendLine("{");
            output.AppendLine(RenderChildControls());
            output.AppendLine("}");
            return output.ToString();
        }
    }
}
