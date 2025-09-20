using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy1.Data
{
    public class Company
    {
        public int Id { get; set; }
        public int? Code { get; set; }
        public string NameEn { get; set; } = "";
        public string NameAr { get; set; } = "";
        public string? Phone { get; set; } = "";
        public string? Address { get; set; } = "";

        public ICollection<Item> Items { get; set; } = new HashSet<Item>();

    }
}
