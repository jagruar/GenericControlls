using PortalCore.Models.Internal.Entites;
using System.Collections.Generic;

namespace PortalCore.Interfaces.Internal.DataAccess
{
    public interface IModelRepository
    {
        void SaveModel(Model model);
        void SaveProperties(IEnumerable<Property> parameters);
        void SaveConditionals(IEnumerable<Conditional> enumerable);
        void SaveEndpoint(Endpoint endpoint);
        void SaveParameters(List<Parameter> parameters);
    }
}
