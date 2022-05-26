using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebTest.Models;
using WebTestApplication.Models;

namespace WebTestApplication.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        

        public DbSet<Category> Categories {get; set;}

        public DbSet<Test> Tests { get; set; }

        public DbSet<TestCart> TestCarts { get; set; }

        public DbSet<Questions> Questions { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<PupilSession> PupilSessions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>()
           .HasMany(b => b.TestCarts)
           .WithOne(a => a.Test)
           //.IsRequired()
           .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }

    }
}
