using PortalCore.Models.Internal.Attributes;
using PortalCore.Models.Internal.Types;
using PortalCore.Models.Internal.Types.Identification;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PortalCore.Models.ViewModels.Vehicles
{
    // This exposes a javascrip function accessible within the control
    //[Function("deleteCar", "Delete Car", "Will remove this car from the database")]
    [Model(ModelId.Car, "Car")]
    public class CarViewModel : IViewModel
    {
        public int CarId { get; set; }

        //[LoadFunction("formatTime")]
        //[LoadFunction("makeCountdown")]
        //[Paramater("Time Format", "TimeTillMot", ParameterType.String)]
        //[Paramater("Use a countdown?", "TimeTillMot", ParameterType.Bool)]
        [Property(PropertyId.Car_TimeTillMot, BasicType.DateTime, "Time till MOT is due")]
        public DateTime TimeTillMot { get; set; }

        [Property(PropertyId.Car_NumberPlate, BasicType.String, "Number Plate")]
        public string NumberPlate { get; set; }

        [Property(PropertyId.Car_Driver, ModelId.Driver)]
        public DriverViewModel Driver { get; set; }

        [Property(PropertyId.Car_Passengers, BasicType.String, IsList = true)]
        public List<string> Passengers { get; set; }

        [Property(PropertyId.Car_Tyres, ModelId.Tyre, IsList = true)]
        public List<TyreViewModel> Tyres { get; set; }

        [Conditional(ConditionalId.Car_IsSafe, "Is this car safe?", "Are all the tyres on this car at a pressure greater than 22?")]
        public bool IsSafe()
        {
            return !Tyres.Any(t => t.Pressure < 22);
        } 
    }
}
