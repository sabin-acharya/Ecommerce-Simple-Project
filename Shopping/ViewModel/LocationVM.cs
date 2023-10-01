using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.Models;

namespace Shopping.ViewModel
{
    public class LocationVM
    {
        public LocationModel Location { get; set; } = new LocationModel();


        public IEnumerable<LocationModel> Locations { get; set; } = new List<LocationModel>();


    }
}
