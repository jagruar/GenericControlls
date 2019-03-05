using GenericControls.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Services.ViewModels
{
    public class CarViewModelService : IViewModelService
    {
        public Car GetCar(int carId)
        {
            return new Car();
        }

        public List<Car> GetCars()
        {
            return new List<Car>()
            {
                new Car()
                {
                    Driver = new Driver()
                    {
                        Name = "Jack",
                        Age = 25
                    },
                    CarId = 1,
                    NumberPlate = "G7UAR",
                    Tyres = new List<Tyre>()
                    {
                        new Tyre()
                        {
                            Pressure = 22
                        },
                        new Tyre()
                        {
                            Pressure = 23
                        }

                    }
                },
                new Car()
                {
                    Driver = new Driver()
                    {
                        Name = "Charlie",
                        Age = 24
                    },
                    CarId = 2,
                    NumberPlate = "B00BS",
                    Tyres = new List<Tyre>()
                    {
                        new Tyre()
                        {
                            Pressure = 21
                        },
                        new Tyre()
                        {
                            Pressure = 26
                        }

                    }
                }
            };
        }
    }
}
