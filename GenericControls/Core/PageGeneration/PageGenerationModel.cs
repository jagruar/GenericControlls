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
        public Page Page { get; set; }
        public List<IControl> Controls { get; set; }
    }
}
