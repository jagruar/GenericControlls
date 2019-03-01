using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericControls.Models.Internal;

namespace GenericControls.Services
{
    public class PageGenerator : IPageGenerator
    {
        public string GeneratePage(Page page)
        {
            // Add all the standard shit to the top of the page
            // recursively dig down to datamodels
            // generate the pages for them
            // set theur pageId to the returned page
            throw new NotImplementedException();
        }
    }
}
