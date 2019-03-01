using GenericControls.Models.Cars;
using GenericControls.Models.Properties;
using System.Collections.Generic;

namespace GenericControls.ViewModels
{
    //[DataModel(controllerName, actionName)]
    //[Parameter(parametertype, displayName)]
    public class CarsViewModel
    {
        // All properties in ViewModel Folder are accessible
        // installer could scan through this folder and add to database
        // maybe have to do with post deployment.
        // will make static data for now.
        // For lists can get the innner name from the type within the list
        public List<Car> Cars {get;set;}
    }
}
