using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Services.Data
{
    public class Purchase
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public string SalesPerson { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double TotalAmount { get; set; }
        public double PaidAmount { get; set; }
        public double VAT { get; set; }

        public int SupplierId { get; set; }

        public Supplier? Supplier { get; set; }
    }
}
