using GenericControls.Data;
using GenericControls.Data.Entities;
using GenericControls.Models.Internal;
using System;
using System.Linq;

namespace GenericControls.Services.Repositories
{
    public class PageRepository : IPageRepository
    {
        private readonly Context _context;

        public PageRepository(Context context)
        {
            _context = context;
        }

        public Page GetPage(string url)
        {
            return _context.Pages.FirstOrDefault(p => p.Url == url);
        }

        public Page SavePage(Page page)
        {
            _context.Pages.Add(page);
            _context.SaveChanges();
            return page;
        }
    }
}
