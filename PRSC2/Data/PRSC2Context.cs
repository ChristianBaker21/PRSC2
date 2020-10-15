using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PRSC2.Models;

namespace PRSC2.Data
{
    public class PRSC2Context : DbContext
    {
        public PRSC2Context (DbContextOptions<PRSC2Context> options)
            : base(options)
        {
        }

        public DbSet<PRSC2.Models.User> User { get; set; }

        public DbSet<PRSC2.Models.Vendor> Vendor { get; set; }

        public DbSet<PRSC2.Models.Product> Product { get; set; }

        public DbSet<PRSC2.Models.Request> Request { get; set; }
    }
}
