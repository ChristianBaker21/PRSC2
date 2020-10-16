using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRSC2.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Justification { get; set; }
        public string RejectionReason { get; set; }
        public string DeliveryMode { get; set; }
        public string Status { get; set; }
        [Column(TypeName = "decimal(11,2)")]
        public decimal Total { get; set; }
        public  int UserId { get; set; }
        public virtual User User { get; set; }


    }
}
