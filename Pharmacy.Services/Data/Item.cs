using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Services.Data
{
    public class Item
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Code2 { get; set; }
        public string? IntCode { get; set; }
        public int? CompanyId { get; set; }
        public string? CompanyCode { get; set; }
        public string? NameEn { get; set; } 
        public string? NameAr { get; set; } 
        public bool? HasExpire { get; set; }
        public bool? IsMedicine { get; set; }
        public int? MinLimit { get; set; }
        public string? ScientificName { get; set; }
        public int? GroupId { get; set; }
        public int? UsageMannerId { get; set; }
        public int? Unit1Id { get; set; }
        public int? Unit2Id { get; set; }
        public int? Unit3Id { get; set; }
        public int? SellPrice { get; set; }
        public decimal? Tax { get; set; }
        public int? PurchaseUnit { get; set; }
        public int? FormatId { get; set; }
        public bool? IsShortage { get; set; }
        public string? Effective { get; set; } 
        public bool? IsPrevent { get; set; }
        public string? Origin { get; set; } 
        public int? Discount { get; set; }

        //Navigation property
        public Company? Company { get; set; }
        public Format? Format { get; set; }
        public Group? Group { get; set; }
        public Unit? Unit1 { get; set; }
        public Unit? Unit2 { get; set; }
        public Unit? Unit3 { get; set; }
       
        public UsageManner? UsageManner { get; set; }

        public ICollection<Inventory> inventories { get; set; } = new HashSet<Inventory>();

    }
}
