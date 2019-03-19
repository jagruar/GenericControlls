using PortalCore.Models.Internal.Types.Identification;

namespace PortalCore.Models.Internal.Controls
{
    public class ConditionalControl : BaseControl
    {
        public ConditionalId ConditionalId { get; set; }
        public string FunctionName { get; set; }
        public bool IsTrue { get; set; }

        public override string Render()
        {
            return IsTrue ?
                $"@if({Model}.{FunctionName}()) {{ {RenderChildControls()} }}" :
                $"@if(!{Model}.{FunctionName}()) {{ {RenderChildControls()} }}";
        }
    }
}
