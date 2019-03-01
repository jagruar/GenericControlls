using GenericControls.Models.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Services.Repositories
{
    public interface IPageRepository
    {
        int SavePage(Page page);
        int SavePartialPage(string razor);
    }
}
