using PortalCore.Interfaces.Internal.DataAccess;
using PortalCore.Models.Internal.Entites;
using PortalCore.Models.Internal.Types;
using System.Linq;

namespace PortalCore.DataAccess.Internal
{
    public class PageRepository : IPageRepository
    {
        private const string GUID = "c01c3c6b-d3ec-4303-9416-394963a12f41";
        private readonly PagesContext _context;

        public PageRepository(PagesContext context)
        {
            _context = context;
        }

        public string GetPageWithMaster(string url)
        {
            Page page = _context.Pages.FirstOrDefault(p => p.Name == url);
            if (page == null)
            {
                page = _context.Pages.FirstOrDefault(p => p.ReservedPage == ReservedPage.NotFound);
                if (page == null)
                {
                    return "you are totally fucked";
                }
            }

            string masterRazor = _context.Views.FirstOrDefault(v => v.PageId == page.MasterPageId).Razor;
            string pageRazor = _context.Views.FirstOrDefault(v => v.PageId == page.PageId).Razor;
            return masterRazor.Replace(GUID, pageRazor);
        }

        public string GetPageRazor(int pageId)
        {
            return _context.Views.FirstOrDefault(v => v.PageId == pageId).Razor;
        }

        public Page SavePage(Page page)
        {
            page.Name = page.Name.Replace(" ", string.Empty).ToLower();
            _context.Pages.Add(page);
            _context.SaveChanges();
            return page;
        }

        public View SaveView(View view)
        {
            _context.Views.Add(view);
            _context.SaveChanges();
            return view;
        }
    }
}
