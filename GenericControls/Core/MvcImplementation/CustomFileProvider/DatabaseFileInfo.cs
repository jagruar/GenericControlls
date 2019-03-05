using GenericControls.Data.Entities;
using GenericControls.Services.Repositories;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericControls.Services.ViewEngine
{
    public class DatabaseFileInfo : IFileInfo
    {
        private Page _page;

        public DatabaseFileInfo(IPageRepository pageRepository, string path)
        {
            _page = pageRepository.GetPage(path);
        }

        public bool Exists => _page != null;

        public long Length => long.Parse("2.0");

        public string PhysicalPath => _page.Url;

        public string Name => _page.Url;

        public DateTimeOffset LastModified => DateTimeOffset.Now;

        public bool IsDirectory => false;

        public Stream CreateReadStream()
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(_page.Razor));
        }
    }
}
