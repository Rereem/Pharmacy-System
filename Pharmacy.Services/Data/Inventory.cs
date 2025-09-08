using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Services.Data
{
    public class Inventory
    {
        public int id { get; set; }
        public int ItemId { get; set; }
        public int? UnitId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
       
        // Navigation properties
        public Item? Item { get; set; }
        public Unit? Unit { get; set; }
    }
}
