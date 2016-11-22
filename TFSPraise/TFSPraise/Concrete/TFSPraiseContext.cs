using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TFSPraise.Domains;

namespace TFSPraise.Concrete
{
    public class TFSPraiseContext:DbContext
    {
        public TFSPraiseContext():base("provideConnectionString here")
        {

        }
        public DbSet<Praise> Praises { get; set; }
        public DbSet<Blog> Blogs { get; set;}
        public DbSet<Employee> Employees { get; set; }
    }
}