namespace PortalCore.Models.Internal.Controls
{
    public class FunctionControl : BaseControl
    {
        public string HtmlElement { get; set; }
        public string Function { get; set; }

        public override string Render()
        {
            return $"<{HtmlElement} onclick=\"{Function}()\">{RenderChildControls()}</{HtmlElement}>";
        }
    }
}
