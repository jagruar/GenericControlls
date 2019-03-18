using PortalCore.Models.Internal.Attributes;
using PortalCore.Models.Internal.Entites;
using PortalCore.Models.Internal.Types.Identification;

namespace PortalCore.Interfaces.Internal
{
    public interface IEntityBuilder
    {
        Model BuildModel(ModelAttribute attribute);
        Conditional BuildConditional(ModelId modelId, ConditionalAttribute attribute);
        Property BuildProperty(ModelId modelId, PropertyAttribute attribute, string propertyName);
        Endpoint BuildEndpoint(string methodName, EndpointAttribute attribute);
        Parameter BuildParameter(EndpointId endpointId, ParameterAttribute attribute);
    }
}
