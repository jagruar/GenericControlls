using PortalCore.Models.Internal.Types;

namespace PortalCore.Models.Internal.Entites
{
    public class Page
    {
        public int PageId { get; set; }
        public string Name { get; set; }
        public PageType PageType { get; set; }
        public int MasterPageId { get; set; }
        public ReservedPage? ReservedPage { get; set; }
        public string Namespace { get; set; }
        public string Model { get; set; }
    }
}
