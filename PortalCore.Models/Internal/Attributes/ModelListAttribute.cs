using System;
using System.Collections.Generic;
using System.Text;

namespace PortalCore.Models.Internal.Attributes
{
    /// <summary>
    /// When placed on a list property exposes a list control
    /// </summary>
    public class ModelListAttribute : Attribute
    {
        public string ModelGuid { get; set; }

        public ModelListAttribute(string modelGuid)
        {
            ModelGuid = modelGuid;
        }
    }
}
