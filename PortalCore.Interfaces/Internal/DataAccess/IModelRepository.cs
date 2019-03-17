using PortalCore.Models.Internal.Entites;

namespace PortalCore.Interfaces.Internal.DataAccess
{
    public interface IModelRepository
    {
        void Save(Model model);
    }
}
