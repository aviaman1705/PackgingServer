using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackgingAPI.Models.ViewModels
{
    public class PlaceViewModel
    {
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductPlaceViewModel> ProductPlaces { get; set; }
    }
}
