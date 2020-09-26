using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackgingAPI.Models.ViewModels
{
    public class SearchProductViewModel
    {
        public int Id { get; set; }
        public string ProductPlaceId { get; set; }
        public string Instruction { get; set; }
        public string Sku { get; set; }
        public string WarehousesTypeName { get; set; }
        public string ProductName { get; set; }        
    }
}
