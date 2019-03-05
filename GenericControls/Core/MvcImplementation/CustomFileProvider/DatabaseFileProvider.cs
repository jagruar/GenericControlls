using GenericControls.Services.Repositories;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Services.ViewEngine
{
    public class DatabaseFileProvider : IFileProvider
    {
        private readonly IPageRepository _pageRepository;

        public DatabaseFileProvider(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            return new NotFoundDirectoryContents();
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            var result = new DatabaseFileInfo(_pageRepository, subpath);
            return result.Exists ? (IFileInfo)result : new NotFoundFileInfo(subpath);
        }

        public IChangeToken Watch(string filter)
        {
            return new DatabaseChangeToken();
        }
    }
}
