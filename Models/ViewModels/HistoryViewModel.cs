using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackgingAPI.Models.ViewModels
{
    public class HistoryViewModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; }
        
        public string Instruction { get; set; }

        public string Place { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Sku { get; set; }

        public int Sorting { get; set; }
    }
}
