using EccomerceWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EccomerceWeb.DataAccess
{
    public class TrendUpProductDbContext: DbContext
    {
        public TrendUpProductDbContext() : base("TrendUpProductDatabase")
        {

        }
        public DbSet<Product> Products { get; set; }
    }

}