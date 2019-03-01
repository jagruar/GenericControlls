using GenericControls.Models.Internal;
using System;

namespace GenericControls.Services.Repositories
{
    public class PageRepository : IPageRepository
    {
        public int SavePage(Page page)
        {
            // save page return Id
            return 2;
        }

        public int SavePartialPage(string razor)
        {
            //SavePage Partial Page return Id
            return 1;
        }
    }
}
