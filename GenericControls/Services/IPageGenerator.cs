using GenericControls.Models.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Services
{
    public interface IPageGenerator
    {
        /// <summary>
        /// Generates Razor from Page model
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        int GeneratePage(Page page);
    }
}
