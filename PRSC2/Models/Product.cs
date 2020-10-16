using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRSC2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string PartNbr { get; set; }
        public string Name { get; set; }
        [Column(TypeName= "decimal(11,2)")]
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public string PhotoPath { get; set; }
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }

    }
}
