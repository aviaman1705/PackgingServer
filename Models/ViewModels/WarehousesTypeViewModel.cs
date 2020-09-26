using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackgingAPI.Models.ViewModels
{
    public class WarehousesTypeViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<ProductPlaceViewModel> ProductPlaces { get; set; }
    }
}
