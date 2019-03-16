using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Data.Entities
{
    public class Page
    {
        public int PageId { get; set; }
        public string Name { get; set; }
        public string Razor { get; set; }
        public PageType PageType { get; set; }
        public int MasterPageId { get; set; }
        public ReservedPage? ReservedPage { get; set; }
    }
}
