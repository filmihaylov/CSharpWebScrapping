using Storage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class WebScrappingContext : DbContext
    {
        public WebScrappingContext()
        : base("WebScrapping")
        {

        }

        public DbSet<CasioWatch> CasioWatch { get; set; }
    }
}


