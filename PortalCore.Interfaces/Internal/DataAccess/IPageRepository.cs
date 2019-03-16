using PortalCore.Models.Internal.Entites;

namespace PortalCore.Interfaces.Internal.DataAccess
{
    public interface IPageRepository
    {
        string GetPageWithMaster(string url);
        Page SavePage(Page page);
        string GetPageRazor(int pageId);
        View SaveView(View view);
    }
}
