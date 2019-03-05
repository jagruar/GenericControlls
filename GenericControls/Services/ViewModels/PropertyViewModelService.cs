using GenericControls.Models.Properties;
using System.Collections.Generic;

namespace GenericControls.Services.ViewModels
{
    public class PropertyViewModelService : IViewModelService
    {
        public House GetHouse()
        {
            return new House()
            {
                Rooms = new List<Room>()
                {
                    new Room(){Name = "Kitchen"},
                    new Room(){Name = "Bathroom"}
                },
                Address = new Address()
                {
                    Street = "Goddard Place",
                    Number = 127
                }
            };
        }
    }
}
