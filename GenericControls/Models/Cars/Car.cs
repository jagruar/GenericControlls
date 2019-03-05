using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericControls.Models.Cars
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
    public class Car
    {
        // These will expose property controls
        public int CarId { get; set; }

        //[LoadFunction("formatTime")]
        //[LoadFunction("makeCountdown")]
        //[Paramater("Time Format", "TimeTillMot", ParameterType.String)]
        //[Paramater("Use a countdown?", "TimeTillMot", ParameterType.Bool)]
        public DateTime TimeTillMot { get; set; }

        public string NumberPlate { get; set; }

        // This will expose a model control
        public Driver Driver { get; set; }

        // This will expose a list control
        public List<Tyre> Tyres { get; set; }

        // This will expose a conditional control
        //[Conditional("Has Safe Tyres")]
        public bool IsSafe()
        {
            return !Tyres.Any(t => t.Pressure < 22);
        } 
    }
}
