using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Models.Internal.Controls
{
    /// <summary>
    /// Should 
    /// </summary>
    public class DataModelControl : BaseControl
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public int PageId { get; set; }
        public string ViewModel { get; set; }
        public int PrimaryParameter { get; set; }
        public int SecondaryParameter { get; set; }

        public override string Render()
        {
            string output = $"@RenderPartial({PageId}, {Controller}, {Action}, {PrimaryParameter}, {SecondaryParameter})";
            return output;
        }
    }
}
