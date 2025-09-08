using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Services.Data
{
    public class UsageCause
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string NameEn { get; set; } = null!;
        public string NameAr { get; set; } = null!;
    }
}
