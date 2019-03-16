using PortalCore.Models.Internal.Entites;
using PortalCore.Models.Internal.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalCore.Interfaces.Internal
{
    public interface IPageGenerator
    {
        /// <summary>
        /// Generates Razor from Page model
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        Page GeneratePage(PageGenerationModel page);
    }
}
