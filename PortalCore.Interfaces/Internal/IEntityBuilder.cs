using PortalCore.Models.Internal.Attributes;
using PortalCore.Models.Internal.Entites;
using PortalCore.Models.Internal.Types.Identification;
using System;

namespace PortalCore.Interfaces.Internal
{
    public interface IEntityBuilder
    {
        Model BuildModel(Type type, ModelAttribute attribute);
        Conditional BuildConditional(string methodName, ModelId modelId, ConditionalAttribute attribute);
        Property BuildProperty(ModelId modelId, PropertyAttribute attribute, string propertyName);
        Endpoint BuildEndpoint(string methodName, EndpointAttribute attribute);
        Parameter BuildParameter(EndpointId endpointId, ParameterAttribute attribute);
    }
}
