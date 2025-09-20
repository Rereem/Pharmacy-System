using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Services.Data
{
    public class Sales
    {
        public int Id { get; set; }
        public string? ClientName { get; set; }
        public DateTime SalesDate { get; set; }

    }
}
