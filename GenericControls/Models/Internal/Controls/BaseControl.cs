using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericControls.Models.Internal.Controls
{
    public abstract class BaseControl : IControl
    {
        // public string Container { get; set; }
        public ControlType ControlType { get; set; }
        public string Classes { get; set; }
        public string PreceedingTypes { get; set; }
        public List<IControl> ChildControls { get; set; }
        public abstract string Render();

        public string RenderChildControls()
        {
            var output = new StringBuilder();
            foreach (var control in ChildControls)
            { 
                output.Append(control.Render());
            }
            return output.ToString();
        }
        //public string RenderContainer()
        //{
        //    string output = $"<{Container} class=\"{Classes}\">{Render()}</{Container}>";
        //    return output;
        //}
    }
}
