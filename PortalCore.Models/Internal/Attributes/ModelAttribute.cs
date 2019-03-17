using PortalCore.Models.Internal.Types.Identification;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalCore.Models.Internal.Attributes
{
    public class ModelAttribute : Attribute
    {
        public ModelId ModelId { get; set; }
        public string DisplayName { get; set; }

        public ModelAttribute(ModelId model, string displayName)
        {
            ModelId = model;
            DisplayName = displayName;
        }
    }
}
