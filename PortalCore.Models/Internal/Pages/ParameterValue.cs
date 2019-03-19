using PortalCore.Models.Internal.Types.Identification;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalCore.Models.Internal.Pages
{
    public class ParameterValue
    {
        public PropertyId? PropertyId { get; set; }
        public int? IntValue { get; set; }
        public string StringValue { get; set; }
        public bool? BoolValue { get; set; }
        public DateTime? DateTimeValue { get; set; }
    }
}
