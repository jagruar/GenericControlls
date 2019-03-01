using GenericControls.Models.Internal.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Models.Internal
{
    public class Page
    {
        public int PageId { get; set; }
        public string Url { get; set; }
        public List<IControl> Controls { get; set; }
    }
}
