using System.Text;

namespace PortalCore.Models.Internal.Controls
{
    public class HtmlControl : BaseControl
    {
        public string HtmlElement { get; set; }

        public override string Render()
        {
            var output = new StringBuilder();
            output.AppendLine($"<{HtmlElement} class=\"{Classes}\">");
            output.AppendLine(RenderChildControls());
            output.Append($"</{HtmlElement}>");
            return output.ToString();
        }
    }
}
