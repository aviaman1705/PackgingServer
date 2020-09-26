using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PackgingAPI.Models
{
    public class ProductPlace
    {
        [Key]
        public int ProductPlaceId { get; set; }

        public int ProductId { get; set; }
        
        [ForeignKey("ProductId")]        
        public Product Product { get; set; }
        
        public int PlaceId { get; set; }
        
        [ForeignKey("PlaceId")]
        public Place Place { get; set; }

        public int WarehousesTypeId { get; set; }

        [ForeignKey("WarehousesTypeId")]
        public WarehousesType WarehousesType { get; set; }

        public int Count { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public string Instruction { get; set; }
    }
}
