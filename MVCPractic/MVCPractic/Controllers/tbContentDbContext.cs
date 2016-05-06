using MVCPractic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCPractic.Controllers
{
    public class tbContentDbContext:DbContext
    {
        public tbContentDbContext() : base ("DefaultConnection")
        { }
        public DbSet<tbContent> Contents { get; set; }
    }
}