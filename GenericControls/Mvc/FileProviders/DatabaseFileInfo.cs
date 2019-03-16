using Microsoft.Extensions.FileProviders;
using PortalCore.Interfaces.Internal.DataAccess;
using System;
using System.IO;
using System.Text;

namespace PortalCore.Portal.Mvc.FileProviders
{
    public class DatabaseFileInfo : IFileInfo
    {
        private const string GUID = "c01c3c6b-d3ec-4303-9416-394963a12f41";
        private const int PATH_LENGTH = 15;
        private const int DOT_CSHTML_LENGTH = 7;

        private readonly string _page;

        public DatabaseFileInfo(IPageRepository pageRepository, string path)
        {
            PhysicalPath = path;
            if (int.TryParse(path.Substring(1), out int pageId))
            {
                _page = pageRepository.GetPageRazor(pageId);
            }
            else
            {
                string pageName = path
                    .Substring(0, path.Length - DOT_CSHTML_LENGTH)
                    .Substring(PATH_LENGTH);
                _page = pageRepository.GetPageWithMaster(pageName);
            }
        }

        public bool Exists => _page != null;

        public long Length => long.Parse("2.0");

        public string PhysicalPath { get; }

        public string Name => PhysicalPath;

        public DateTimeOffset LastModified => DateTimeOffset.Now;

        public bool IsDirectory => false;

        public Stream CreateReadStream()
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(_page));
        }
    }
}
