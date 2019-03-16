using System;
using System.Collections.Generic;
using System.Text;

namespace PortalCore.Models.Internal.Attributes
{
    public class ViewModelAttribute : Attribute
    {
        public string ModelGuid { get; set; }

        public ViewModelAttribute(string modelGuid)
        {
            ModelGuid = modelGuid;
        }
    }
}
