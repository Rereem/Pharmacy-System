using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Services.Data
{
    public class SalesDetails
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public int UnitId { get; set; }
        public int SalesId { get; set; }
        public int Quantity { get; set; }
        public double SalesPrice { get; set; }

        public  Inventory? Inventory { get; set; }
        public Sales? Sales { get; set; }
        public Unit? Unit { get; set; }

    }
}
