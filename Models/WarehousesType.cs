using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PackgingAPI.Models
{
    public class WarehousesType
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<ProductPlace> ProductPlaces { get; set; }
    }
}
