using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TFSPraise.Entities;
using System.ComponentModel.DataAnnotations.Schema;

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
            //Set up keys and property
            modelBuilder.Entity<Praise>().HasKey(p => p.PraiseID).Property(P => P.PraiseID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<User>().HasKey(u => u.ID);
            modelBuilder.Entity<Blog>().HasKey(b => b.BlogID).Property(b => b.BlogID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Set up relations between entities
            modelBuilder.Entity<User>().HasMany(u => u.Praises).WithRequired(p => p.Praiser).HasForeignKey(p => p.OwnerID);
            modelBuilder.Entity<User>().HasMany(u => u.Blogs).WithRequired(b => b.Publisher).HasForeignKey(b => b.PublisherID);
            modelBuilder.Entity<Praise>().HasMany(p => p.Receivers).WithMany(r => r.Praises).Map(m=> {
                m.MapLeftKey("PraiseID");
                m.MapRightKey("ReceiverID");
                m.ToTable("ReceiverPraises");
            });
        }
    }
}