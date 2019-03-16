namespace PortalCore.Models.Internal.Controls
{
    public class ListItemControl : BaseControl
    {
        public string HtmlElement { get; set; }

        public override string Render()
        {
            return $"<{HtmlElement} class=\"{Classes}\" >@{Model}</{HtmlElement}>";
        }       
    }
}
