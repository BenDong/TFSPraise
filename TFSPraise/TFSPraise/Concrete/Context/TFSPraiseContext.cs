using System.ComponentModel.DataAnnotations.Schema;
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
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Receiver> Receivers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure keys
            modelBuilder.Entity<Praise>().HasKey(p => p.ID).Property(P => P.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<UserProfile>().HasKey(u => u.ID).Property(u => u.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Blog>().HasKey(b => b.ID).Property(b => b.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Identity>().HasKey(i => i.IdentityID);

            //Configure relations
            modelBuilder.Entity<UserProfile>().HasRequired(u => u.Identity).WithRequiredPrincipal(i => i.UserProfile).WillCascadeOnDelete();
            modelBuilder.Entity<UserProfile>().HasMany(u => u.Praises).WithRequired(p => p.Praiser).HasForeignKey(p => p.OwnerID);
            modelBuilder.Entity<UserProfile>().HasMany(u => u.Blogs).WithRequired(b => b.Publisher).HasForeignKey(b => b.PublisherID);
            modelBuilder.Entity<Praise>().HasMany(p => p.Receivers).WithMany(r => r.Praises).Map(m=> {
                m.MapLeftKey("PraiseID");
                m.MapRightKey("ReceiverID");
                m.ToTable("ReceiverPraises");
            });
        }
    }
}