using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackgingAPI.Models.ViewModels
{
    public class ProductToEditViewModel
    {
        public int ProductId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public int Sorting { get; set; }
    }
}
