using GenericControls.Data;
using GenericControls.Data.Entities;
using GenericControls.Models.Internal;
using System;
using System.Linq;

namespace GenericControls.Services.Repositories
{
    public class PageRepository : IPageRepository
    {
        private const string GUID = "c01c3c6b-d3ec-4303-9416-394963a12f41";
        private readonly Context _context;

        public PageRepository(Context context)
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
            Page master = _context.Pages.FirstOrDefault(p => p.PageId == page.MasterPageId);
            return master.Razor.Replace(GUID, page.Razor);
        }

        public string GetMasterRazor(string url)
        {
            return _context.Pages
                .FirstOrDefault(m => m.PageId == _context.Pages.FirstOrDefault(p => p.Name == url).MasterPageId)
                .Razor;            
        }

        public Page GetPage(string url)
        {
            return _context.Pages.FirstOrDefault(p => p.Name == url);
        }

        public string GetPageRazor(int pageId)
        {
            return _context.Pages.FirstOrDefault(p => p.PageId == pageId).Razor;
        }

        public Page SavePage(Page page)
        {
            _context.Pages.Add(page);
            _context.SaveChanges();
            return page;
        }
    }
}
