using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackgingAPI.Models.ViewModels
{
    public class ProductPlaceGridViewModel
    {
        public int WarehousesTypeId { get; set; }
        public string Sku { get; set; }
        public string PlaceName { get; set; }
        public string Instruction { get; set; }
    }
}
