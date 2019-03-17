using PortalCore.Interfaces.Portal;
using PortalCore.Models.Internal.Attributes;
using PortalCore.Models.Internal.Types.Identification;
using PortalCore.Models.ViewModels.Vehicles;
using System.Collections.Generic;

namespace PortalCore.Services.ViewModels.Vehicles
{
    public class CarViewModelService : IViewModelService
    {
        public ModelId ModelId => ModelId.Car;

        [Endpoint(EndpointId.Car_Mine, "Get all cars", "Returns every car in the database")]
        public List<CarViewModel> GetCars()
        {
            return new List<CarViewModel>()
            {
                JackCar,
                CharlieCar
            };
        }

        [Endpoint(EndpointId.Car_Mine, "Car by driver name", "Gets the car driven by the specified driver" )]
        [Parameter("Driver Name")]
        public CarViewModel Mine(string driverName)
        {
            if (driverName == "Charlie")
            {
                return CharlieCar;
            }
            else
            {
                return JackCar;
            }
        }

        private CarViewModel JackCar => new CarViewModel()
        {
            Driver = new DriverViewModel()
            {
                Name = "Jack",
                Age = 25
            },
            Passengers = new List<string>()
            {
                "Sam",
                "Haider"
            },
            CarId = 1,
            NumberPlate = "G7UAR",
            Tyres = new List<TyreViewModel>()
                    {
                        new TyreViewModel()
                        {
                            Pressure = 22
                        },
                        new TyreViewModel()
                        {
                            Pressure = 23
                        }

                    }
        };

        private CarViewModel CharlieCar => new CarViewModel()
        {
            Driver = new DriverViewModel()
            {
                Name = "Charlie",
                Age = 24
            },
            Passengers = new List<string>()
            {
                "Gabby",
                "Ollie"
            },
            CarId = 2,
            NumberPlate = "B00BS",
            Tyres = new List<TyreViewModel>()
                    {
                        new TyreViewModel()
                        {
                            Pressure = 21
                        },
                        new TyreViewModel()
                        {
                            Pressure = 26
                        }

                    }
        };
    }
}
