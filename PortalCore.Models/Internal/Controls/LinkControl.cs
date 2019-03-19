using PortalCore.Models.Internal.Pages;
using PortalCore.Models.Internal.Types;
using PortalCore.Models.Internal.Types.Identification;
using System;
using System.Text;

namespace PortalCore.Models.Internal.Controls
{
    public class LinkControl : BaseControl
    {
        public string Text { get; set; }
        public bool OpenNewPage { get; set; }
        public string ExternalUrl { get; set; }

        public ModelId ModelId { get; set; }
        public string Method { get; set; }
        public string View { get; set; }

        public ParameterString PrimaryInt { get; set; }
        public ParameterString SecondaryInt { get; set; }
        public ParameterString PrimaryString { get; set; }
        public ParameterString SecondaryString { get; set; }
        public ParameterString PrimaryBool { get; set; }
        public ParameterString SecondaryBool { get; set; }
        public ParameterString PrimaryDateTime { get; set; }
        public ParameterString SecondaryDateTime { get; set; }
        // needs datetime

        public override string Render()
        {
            return $"<a href=\"{GetUrl()}\" {GetTarget()} >{Text}</a>";
            throw new NotImplementedException();
        }

        private string GetUrl()
        {
            if (!string.IsNullOrEmpty(ExternalUrl))
            {
                return ExternalUrl;
            }
            else if (ModelId == ModelId.None)
            {
                return $"~/{View}";
            }
            else
            {
                return GetQueryString();
            }
        }

        private string GetQueryString()
        {
            var query = new StringBuilder();
            query.Append($"~/{ModelId}/{Method}?view={View}");
            query.Append(GetQueryParameter("primaryId", PrimaryInt));
            query.Append(GetQueryParameter("secondaryId", SecondaryInt));
            query.Append(GetQueryParameter("primaryKey", PrimaryString));
            query.Append(GetQueryParameter("secondaryKey", SecondaryString));
            query.Append(GetQueryParameter("primaryOption", PrimaryBool));
            query.Append(GetQueryParameter("secondaryOption", SecondaryBool));
            query.Append(GetQueryParameter("primaryDateTime", PrimaryDateTime));
            query.Append(GetQueryParameter("secondaryDateTime", SecondaryDateTime));
            return query.ToString();
        }

        private string GetQueryParameter(string parameterName, ParameterString parameter)
        {
            if (parameter != null)
            {
                if (parameter.IsFromModel)
                {
                    return $"&{parameterName}=@{Model}.{parameter.Value}";
                }
                else
                {
                    return $"&{parameterName}={parameter.Value}";
                }                
            }
            else
            {
                return string.Empty;
            }
        }

        private string GetTarget()
        {
            if (OpenNewPage)
            {
                return "target=\"_blank\"";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
