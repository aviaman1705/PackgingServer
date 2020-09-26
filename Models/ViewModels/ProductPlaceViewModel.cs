using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackgingAPI.Models.ViewModels
{
    public class ProductPlaceViewModel
    {
        public int ProductPlaceId { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public int PlaceId { get; set; }
        public PlaceViewModel Place { get; set; }
        public int Count { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Instruction { get; set; }
        public int WarehousesTypeId { get; set; }
        public WarehousesType WarehousesType { get; set; }
    }
}
