using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackgingAPI.Models.ViewModels
{
    public class EditInventoryBalance
    {
        public int InventoryBalanceID { get; set; }
        public string Name { get; set; }
        public string Instruction { get; set; }
        public string Place { get; set; }
        public string Warhouse { get; set; }
        public int Count { get; set; }
    }
}
