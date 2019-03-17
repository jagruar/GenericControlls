using PortalCore.Interfaces.Internal;
using PortalCore.Models.Internal.Attributes;
using PortalCore.Models.Internal.Entites;
using PortalCore.Models.Internal.Types.Identification;
using System;

namespace PortalCore.Services.Internal.Installation
{
    public class EntityBuilder : IEntityBuilder
    {
        public Conditional BuildConditional(ModelId modelId,  ConditionalAttribute attribute)
        {
            return new Conditional()
            {
                ConditionalId = attribute.ConditionalId,
                ModelId = modelId,
                DisplayName = attribute.DisplayName,
                Description = attribute.Description
            };
        }

        public Endpoint BuildEndpoint(ModelId modelId, string methodName, EndpointAttribute attribute)
        {
            return new Endpoint()
            {
                EndpointId = attribute.EndpointId,
                ModelId = modelId,
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

        public Property BuildProperty(ModelId modelId, PropertyAttribute attribute)
        {
            return new Property()
            {
                PropertyId = attribute.PropertyId,
                ModelId = modelId,
                DisplayName = attribute.DisplayName,
                ChildModelId = attribute.ChildModelId,
                IsList = attribute.IsList
            };
        }
    }
}
