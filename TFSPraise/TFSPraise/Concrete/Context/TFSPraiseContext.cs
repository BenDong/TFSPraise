using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TFSPraise.Entities;

namespace TFSPraise.Concrete
{
    public class TFSPraiseContext : DbContext
    {
        public TFSPraiseContext() : base("TFSPraiseContext")
        {
        }
        public DbSet<Praise> Praises { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Receiver> Receivers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

    }
}