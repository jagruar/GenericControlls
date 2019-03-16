using System.Collections.Generic;

namespace PortalCore.Models.ViewModels.Buildings
{
    public class House
    {
        public List<Room> Rooms { get; set; }
        public Address Address { get; set; }
    }
}
