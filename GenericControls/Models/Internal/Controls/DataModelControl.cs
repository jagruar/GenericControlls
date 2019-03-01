using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Models.Internal.Controls
{
    public class DataModelControl : BaseControl
    {
        public string Controller { get; set; }
        public string Action { get; set; }

        public int PrimaryParameter { get; set; }
        public int SecondaryParameter { get; set; }

        public override string Render()
        {
            return $"@RenderPartial({PageId}, {Controller}, {Action}, {PrimaryParameter}, {SecondaryParameter})";
        }
    }
}
