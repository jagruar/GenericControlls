using GenericControls.Data.Entities;
using GenericControls.Models.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Services.Repositories
{
    public interface IPageRepository
    {
        Page GetPage(string url);
        Page SavePage(Page page);
    }
}
