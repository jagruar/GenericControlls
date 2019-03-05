using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Models.Internal.Controls
{
    public class HtmlControl : BaseControl
    {
        public string HtmlElement { get; set; }

        public override string Render()
        {
            return $"<{HtmlElement} class=\"{Classes}\">{RenderChildControls()}</{HtmlElement}>";
        }
    }
}
