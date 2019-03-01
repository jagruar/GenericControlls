using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericControls.Models.Cars;
using Microsoft.AspNetCore.Mvc;

namespace GenericControls.Controllers
{
    public class CarController : Controller
    {
        public List<Car> GetCars()
        {
            return new List<Car>()
            {
                new Car()
                {
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