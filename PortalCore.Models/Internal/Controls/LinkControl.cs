using PortalCore.Models.Internal.Types;
using System;
using System.Text;

namespace PortalCore.Models.Internal.Controls
{
    public class LinkControl : BaseControl
    {
        public string Text { get; set; }
        public bool OpenNewPage { get; set; }
        public string ExternalUrl { get; set; }

        public ViewModelServiceType ViewModelService { get; set; }
        public string Method { get; set; }
        public string View { get; set; }

        public string PrimaryId { get; set; }
        public string SecondaryId { get; set; }
        public string PrimaryKey { get; set; }
        public string SecondaryKey { get; set; }
        public string PrimaryOption { get; set; }
        public string SecondaryOption { get; set; }

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
            else if (ViewModelService == ViewModelServiceType.None)
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
            query.Append($"~/{ViewModelService}/{Method}?view={View}");
            query.Append(GetQueryParameter("primaryId", PrimaryId));
            query.Append(GetQueryParameter("secondaryId", SecondaryId));
            query.Append(GetQueryParameter("primaryKey", PrimaryKey));
            query.Append(GetQueryParameter("secondaryKey", SecondaryKey));
            query.Append(GetQueryParameter("primaryOption", PrimaryOption));
            query.Append(GetQueryParameter("secondaryOption", SecondaryOption));
            return query.ToString();
        }

        private string GetQueryParameter(string parameterName, string parameter)
        {
            if (!string.IsNullOrEmpty(parameter))
            {
                return $"&{parameterName}=@{Model}.{parameter}";
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
