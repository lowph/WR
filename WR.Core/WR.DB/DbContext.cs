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
        const string connectionString = @"Data Source=;AttachDbFilename=F:\同步文件\2016中联区位\21.其他项目\WR_PROJECT\WR\WR.WebRoot\App_Data\wrdb.mdf;Integrated Security=True;Connect Timeout=30";
        public WRDbContext() : base("name=DefaultConnection")
        {
                        
        }
        public DbSet<User> Users { get; set; }
    }
}
