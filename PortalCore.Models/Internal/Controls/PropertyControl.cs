using PortalCore.Models.Internal.Types.Identification;
using System.Collections.Generic;
using System.Text;

namespace PortalCore.Models.Internal.Controls
{
    public class PropertyControl : BaseControl
    {
        public string Property { get; set; }
        public string HtmlElement { get; set; }
        //List<JSFunction> LoadFunctions { get; set; }
        //List<JSFunction> ClickFunctions { get; set; }

        public override string Render()
        {            
            return $"<{HtmlElement} class=\"{Classes}\" onload=\"{RenderFunctions()}\">@{Model}.{Property}</{HtmlElement}>";
        }

        private string RenderFunctions()
        {
            return string.Empty;
            //if (LoadFunctions != null)
            //{
            //    var functions = new StringBuilder();
            //    foreach (JSFunction function in LoadFunctions)
            //    {
            //        string parameters = string.Empty;
            //        foreach (var parameter in function.Parameters)
            //        {
            //            parameters += $"{parameter}, ";
            //        }
            //        functions.Append($"{function.Name}({parameters.Substring(parameters.Length - 2)}); ");
            //    }
            //    return functions.ToString();
            //}
            //else
            //{
            //    return string.Empty;
            //}
        }
    }
}
