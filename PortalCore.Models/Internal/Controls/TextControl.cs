namespace PortalCore.Models.Internal.Controls
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
