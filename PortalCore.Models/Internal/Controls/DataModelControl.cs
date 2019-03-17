using PortalCore.Models.Internal.Types;
using PortalCore.Models.Internal.Types.Identification;

namespace PortalCore.Models.Internal.Controls
{
    public class DataModelControl : BaseControl
    {
        /// <summary>
        /// Used to identify the service for retieving the components data
        /// </summary>
        public ModelId ModelId { get; set; }

        /// <summary>
        /// Used to identify the method for retieving the components data
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// The Namespace of the model for the control
        /// </summary>
        public string Namespace { get; set; }

        public int PartialId { get; set; }
        public string Name { get; set; }

        public override string Render()
        {
            return $"<data-partial  partial-id=\"{PartialId}\" service-type=\"{ModelId}\" action=\"{Method}\" />";
        }
    }
}
