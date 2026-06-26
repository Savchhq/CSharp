using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace NZWalks.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext<IdentityUser>
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> dbContextOptions): base( dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                  Id = "39609900-6eda-418a-9a99-8618d2a5212b",
                  ConcurrencyStamp = "39609900-6eda-418a-9a99-8618d2a5212b",
                  Name = "Reader",
                  NormalizedName = "READER"
                },
                new IdentityRole
                {
                  Id = "bda29f2d-44f5-4738-8138-f81bbcafac6e",
                  ConcurrencyStamp = "bda29f2d-44f5-4738-8138-f81bbcafac6e",
                  Name = "Writer",
                  NormalizedName = "WRITER"

                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
