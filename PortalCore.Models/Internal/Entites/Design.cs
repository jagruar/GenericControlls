using System;
using System.Collections.Generic;
using System.Text;

namespace PortalCore.Models.Internal.Entites
{
    public class Design
    {
        public int DesignId { get; set; }
        public int PageId { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }

        public Page Page { get; set; }
    }
}