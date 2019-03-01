using GenericControls.Models.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Services
{
    public interface IPageParser
    {
        public Page ParsePage(string json);
    }
}
