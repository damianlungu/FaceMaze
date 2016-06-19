using System.Data.Entity;
using FaceMaze.Web.Models;
using MR.AspNet.Identity.EntityFramework6;

namespace FaceMaze.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base(ConnectionString)
        {
        }
        public static string ConnectionString { get; set; } = @"Server=(localdb)\mssqllocaldb;Database=FaceMazeDatabase;Trusted_Connection=True;MultipleActiveResultSets=true";
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m => m.ToTable("Friends").MapLeftKey("UserId").MapRightKey("FriendId"));

            builder.Entity<UserScore>()
                .HasRequired(x => x.User);
            base.OnModelCreating(builder);
        }

        public DbSet<UserScore> Scores { get; set; }
    }
}
