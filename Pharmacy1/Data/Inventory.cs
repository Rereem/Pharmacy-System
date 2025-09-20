using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy1.Data
{
    public class Inventory
    {
        public int id { get; set; }
        public int ItemId { get; set; }
        public int? UnitId { get; set; }
        public int? PurchaseId { get; set; }
        public int Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public double CostPrice { get; set; }
        public double VAT { get; set; }
        public int QuantityAvail { get; set; }
       
        // Navigation properties
        public Item? Item { get; set; }
        public Unit? Unit { get; set; }
        public Purchase Purchase { get; set; }
    }
}
