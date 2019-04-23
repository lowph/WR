using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WR.Models.Base;

namespace WR.DB
{
    public class WRDbContext : DbContext
    {
        public WRDbContext() : base("name=DefaultConnection")
        {
                        
        }
        public DbSet<User> Users { get; set; }
    }
}
