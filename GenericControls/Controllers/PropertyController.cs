using GenericControls.Models.Properties;
using Microsoft.AspNetCore.Mvc;

namespace GenericControls.Controllers
{
    public class PropertyController : Controller
    {
        public House GetHouse()
        {
            return new House()
            {
                Rooms = 5,
                Street = "Fortress"
            };
        }
    }
}