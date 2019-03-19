using PortalCore.Models.Internal.Entites;
using PortalCore.Models.Internal.Types.Identification;
using System.Collections.Generic;

namespace PortalCore.Interfaces.Internal.DataAccess
{
    public interface IModelRepository
    {
        Model GetModel(ModelId modelId);
        Property GetProperty(PropertyId propertyId);
        Conditional GetConditional(ConditionalId conditionalId);
        Endpoint GetEndpoint(EndpointId endpointId);
        void SaveModel(Model model);
        void SaveProperties(IEnumerable<Property> parameters);
        void SaveConditionals(IEnumerable<Conditional> enumerable);
        void SaveEndpoint(Endpoint endpoint);
        void SaveParameters(List<Parameter> parameters);
    }
}
