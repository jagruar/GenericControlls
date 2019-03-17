using PortalCore.Interfaces.Portal;
using PortalCore.Models.Internal.Types.Identification;
using PortalCore.Models.ViewModels.Buildings;
using System.Collections.Generic;

namespace PortalCore.Services.ViewModels.Buildings
{
    public class HouseViewModelService : IViewModelService
    {
        public ModelId ModelId => ModelId.House; 

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
