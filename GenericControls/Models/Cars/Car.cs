using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericControls.Models.Cars
{
    public class Car
    {
        public int CarId { get; set; }
        public List<Tyre> Tyres { get; set; }
        public string NumberPlate { get; set; }
    }
}
