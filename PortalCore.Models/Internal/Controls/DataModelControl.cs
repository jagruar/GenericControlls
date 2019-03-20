using PortalCore.Models.Internal.Pages;
using PortalCore.Models.Internal.Types.Identification;
using System.Text;

namespace PortalCore.Models.Internal.Controls
{
    public class DataModelControl : BaseControl
    {
        /// <summary>
        /// Used to identify the service for retieving the components data
        /// </summary>
        public ModelId ModelId { get; set; }

        /// <summary>
        /// Used during installation to get method info
        /// </summary>
        public EndpointId EndpointId { get; set; }

        /// <summary>
        /// Used to identify the method for retieving the components data
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// The Namespace of the model for the control
        /// </summary>
        public string Namespace { get; set; }

        public int PartialId { get; set; }
        public string Name { get; set; }

        // needs parameters
        public ParameterString PrimaryInt { get; set; }
        public ParameterString SecondaryInt { get; set; }
        public ParameterString PrimaryString { get; set; }
        public ParameterString SecondaryString { get; set; }
        public ParameterString PrimaryBool { get; set; }
        public ParameterString SecondaryBool { get; set; }
        public ParameterString PrimaryDateTime { get; set; }
        public ParameterString SecondaryDateTime { get; set; }

        public override string Render()
        {
            return $"<data-partial  partial-id=\"{PartialId}\" model-type=\"{ModelId}\" action=\"{Method}\" {GetParamterString()}/>";
        }

        private string GetParamterString()
        {
            var parameters = new StringBuilder();
            parameters.Append(GetParameter("primary-Id", PrimaryInt));
            parameters.Append(GetParameter("secondary-Id", SecondaryInt));
            parameters.Append(GetParameter("primary-Key", PrimaryString));
            parameters.Append(GetParameter("secondary-Key", SecondaryString));
            parameters.Append(GetParameter("primary-Option", PrimaryBool));
            parameters.Append(GetParameter("secondary-Option", SecondaryBool));
            parameters.Append(GetParameter("primary-Date-Time", PrimaryDateTime));
            parameters.Append(GetParameter("secondary-Date-Time", SecondaryDateTime));
            return parameters.ToString();
        }

        private string GetParameter(string parameterName, ParameterString parameter)
        {
            if (parameter != null)
            {
                if (parameter.IsFromModel)
                {
                    return $" {parameterName}=\"@{Model}.{parameter.Value}\"";
                }
                else
                {
                    return $" {parameterName}=\"{parameter.Value}\"";
                }
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
