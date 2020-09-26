using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PackgingAPI.Models
{
    public class History
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public string Instruction { get; set; }

        public string Place { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Sku { get; set; }

        public int Sorting { get; set; }
    }
}
