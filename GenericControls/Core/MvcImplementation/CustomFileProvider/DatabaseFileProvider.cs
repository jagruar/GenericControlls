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
        private readonly string[] _reservedPaths = {
            "/Views/Shared/_ViewImports.cshtml",
            "/Views/Routing/_ViewImports.cshtml",
            "/Pages/_ViewImports.cshtml",
            "/Pages/_ViewImports.cshtml",
            "/_ViewImports.cshtml",
            "/Views/Shared/_ViewStart.cshtml",
            "/Views/Routing/_ViewStart.cshtml",
            "/Pages/_ViewStart.cshtml",
            "/Pages/_ViewStart.cshtml",
            "/_ViewStart.cshtml",
            "/Views/Shared/_Layout.cshtml",
            "/Views/Routing/_Layout.cshtml",
            "/Pages/_Layout.cshtml",
            "/Pages/_Layout.cshtml",
            "/_Layout.cshtml",
        };

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
            if (_reservedPaths.Contains(subpath))
            {
                return new NotFoundFileInfo(subpath);
            }
            else
            {
                var result = new DatabaseFileInfo(_pageRepository, subpath);
                return result.Exists ? (IFileInfo)result : new NotFoundFileInfo(subpath);
            }            
        }

        public IChangeToken Watch(string filter)
        {
            return new DatabaseChangeToken();
        }
    }
}
