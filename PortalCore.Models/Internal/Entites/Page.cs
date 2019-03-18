using PortalCore.Models.Internal.Types;
using PortalCore.Models.Internal.Types.Identification;
using System.Collections.Generic;

namespace PortalCore.Models.Internal.Entites
{
    public class Page
    {
        public int PageId { get; set; }
        public string Name { get; set; }
        public PageType PageType { get; set; }
        public int MasterPageId { get; set; }
        public ReservedPage? ReservedPage { get; set; }
        public ModelId? ModelId { get; set; }

        public IEnumerable<View> Views { get; set; }
        public IEnumerable<Design> Designs { get; set; }
    }
}
