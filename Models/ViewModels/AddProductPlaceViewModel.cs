using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackgingAPI.Models.ViewModels
{
    public class AddProductPlaceViewModel
    {
        public int ProductId { get; set; }
        public string Instruction { get; set; }
        public int Count { get; set; }
        public int PlaceId { get; set; }
    }
}
