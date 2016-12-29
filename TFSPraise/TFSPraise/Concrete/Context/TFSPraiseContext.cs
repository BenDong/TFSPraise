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

        public DbSet<Like> Praises { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Receiver> Receivers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure keys
            modelBuilder.Entity<Like>().HasKey(p => p.LikeID).Property(P => P.LikeID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<UserProfile>().HasKey(u => u.IdentityID).Property(u => u.IdentityID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Blog>().HasKey(b => b.PostID).Property(b => b.PostID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Identity>().HasKey(i => i.IdentityID);

            //Configure relations
            modelBuilder.Entity<UserProfile>().HasRequired(u => u.Identity).WithRequiredPrincipal(i => i.UserProfile).WillCascadeOnDelete();
            modelBuilder.Entity<UserProfile>().HasMany(u => u.Likes).WithRequired(l => l.Sponsor).HasForeignKey(l => l.SponsorID);
            modelBuilder.Entity<UserProfile>().HasMany(u => u.Blogs).WithRequired(b => b.Poster).HasForeignKey(b => b.PosterID);
            modelBuilder.Entity<Like>().HasMany(p => p.Receivers).WithMany(r => r.Likes).Map(m=> {
                m.MapLeftKey("LikeID");
                m.MapRightKey("ReceiverID");
                m.ToTable("ReceiverLikeMapping");
            });
        }
    }
}