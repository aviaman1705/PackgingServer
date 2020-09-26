using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PackgingAPI.Models
{
    public partial class Place
    {
        [Key]
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductPlace> ProductPlaces { get; set; }
    }
}
