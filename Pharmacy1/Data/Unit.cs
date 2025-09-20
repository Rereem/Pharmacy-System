using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy1.Data
{
    public class Unit
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string NameEn { get; set; } = null!;
        public string NameAr { get; set; } = null!;

        public ICollection<Inventory> inventories { get; set; } = new HashSet<Inventory>();
    }
}
