using PortalCore.Models.Internal.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PortalCore.Models.ViewModels.Vehicles
{
    // This exposes a data control with input parameter
    //[DataControl("ViewModelServiceType.Car", ""GetCar", "Get Car for Current User")]
    //[Parameter("GetCar", "Maximum Cars",ParameterType.Int)]
    //
    // This exposes a list control
    //[ListDataControl("ViewModelServiceType.Car", ""GetCars")]
    //
    // This exposes a javascrip function accessible within the control
    //[Function("deleteCar", "Delete Car", "Will remove this car from the database")]
    [ViewModel("cf187bab-6f09-4af1-af07-e94ac56a0bf6")]
    public class CarViewModel : IViewModel
    {
        public int CarId { get; set; }

        //[LoadFunction("formatTime")]
        //[LoadFunction("makeCountdown")]
        //[Paramater("Time Format", "TimeTillMot", ParameterType.String)]
        //[Paramater("Use a countdown?", "TimeTillMot", ParameterType.Bool)]
        public DateTime TimeTillMot { get; set; }

        [Property]
        public string NumberPlate { get; set; }

        [Model("a613e646-190d-4ed5-8b9d-0a4cd719257d")]
        public DriverViewModel Driver { get; set; }

        [List]
        public List<string> Passengers { get; set; }

        [ModelList("b46f2f2c-c6d8-4952-8346-177b89e0739d")]
        public List<TyreViewModel> Tyres { get; set; }

        [Conditional("Has Safe Tyres")]
        public bool IsSafe()
        {
            return !Tyres.Any(t => t.Pressure < 22);
        } 
    }
}
