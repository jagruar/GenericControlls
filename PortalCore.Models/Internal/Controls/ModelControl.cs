namespace PortalCore.Models.Internal.Controls
{
    public class ModelControl : BaseControl
    {
        public override string Render()
        {
            return $"<div class=\"{Classes}\">{RenderChildControls()}</div>";
        }
    }
}
