using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericControls.Models.Internal;
using GenericControls.Models.Internal.Controls;

namespace GenericControls.Services
{
    public class PageParser : IPageParser
    {
        public Page ParsePage(string json)
        {
            throw new NotImplementedException();
        }

        private IControl ParseControl(ControlType controlType, string json)
        {
            switch (controlType)
            {
                case (ControlType.DataModel):
                    // cast json to DataModelControl
                    return new DataModelControl();
            }
            return new DataModelControl();
        }
    }
}
