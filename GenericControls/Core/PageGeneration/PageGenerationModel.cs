using GenericControls.Data.Entities;
using GenericControls.Models.Internal.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Models.Internal
{
    public class PageGenerationModel
    {
        public int PageId { get; set; }
        public string Url { get; set; }
        public string Razor { get; set; }
        public List<IControl> Controls { get; set; }

        public Page ToPage()
        {
            return new Page()
            {
                Url = Url,
                Razor = Razor,
            };

        }
    }
}
