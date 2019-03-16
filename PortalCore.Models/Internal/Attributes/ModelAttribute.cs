using System;
using System.Collections.Generic;
using System.Text;

namespace PortalCore.Models.Internal.Attributes
{
    public class ModelAttribute : Attribute
    {
        public string ModelGuid { get; set; }

        public ModelAttribute(string modelGuid)
        {
            ModelGuid = modelGuid;
        }
    }
}
