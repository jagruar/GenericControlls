using PortalCore.Interfaces.Internal;
using PortalCore.Models.Internal.Attributes;
using PortalCore.Models.Internal.Entites;
using PortalCore.Models.Internal.Types.Identification;

namespace PortalCore.Services.Internal.Installation
{
    public class EntityBuilder : IEntityBuilder
    {
        public Conditional BuildConditional(ModelId modelId, ConditionalAttribute attribute)
        {
            return new Conditional()
            {
                ModelId = modelId,
                ConditionalId = attribute.ConditionalId,
                DisplayName = attribute.DisplayName,
                Description = attribute.Description
            };
        }

        public Endpoint BuildEndpoint(string methodName, EndpointAttribute attribute)
        {
            return new Endpoint()
            {
                EndpointId = attribute.EndpointId,
                DisplayName = attribute.DisplayName,
                Description = attribute.Description,
                IsList = attribute.IsList,
                Method = methodName
            };
        }

        public Model BuildModel(ModelAttribute attribute)
        {
            return new Model()
            {
                ModelId = attribute.ModelId,
                DisplayName = attribute.DisplayName
            };
        }

        public Parameter BuildParameter(EndpointId endpointId, ParameterAttribute attribute)
        {
            return new Parameter()
            {
                EndpointId = endpointId,
                ParameterId = attribute.ParameterId,
                DisplayName = attribute.DisplayName,
                Type  = attribute.Type,
            };
        }

        public Property BuildProperty(ModelId modelId, PropertyAttribute attribute, string propertyName)
        {
            return new Property()
            {
                ModelId = modelId,
                PropertyId = attribute.PropertyId,
                Type = attribute.Type,
                DisplayName = attribute.DisplayName ?? propertyName,
                ChildModelId = attribute.ChildModelId,
                IsList = attribute.IsList
            };
        }
    }
}
