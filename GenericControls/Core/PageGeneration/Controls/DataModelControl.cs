using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Models.Internal.Controls
{
    public class DataModelControl : BaseControl
    {
        /// <summary>
        /// Used to identify the service for retieving the components data
        /// </summary>
        public ViewModelServiceType ViewModelServiceType { get; set; }

        /// <summary>
        /// Used to identify the method for retieving the components data
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// The Namespace of the model for the control
        /// </summary>
        public string NameSpace { get; set; }

        public string PartialName { get; set; }

        public override string Render()
        {
            return $"<data-partial  name=\"{PartialName}\" service-type=\"{ViewModelServiceType}\" action=\"{Method}\" />";
        }
    }
}
