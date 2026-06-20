using Microsoft.EntityFrameworkCore;
using NZWalks.Models.Domain;
namespace NZWalks.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions): base( dbContextOptions)
        {

        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Walk> Walks { get; set; } 
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            var difficulties = new List<Difficulty>
            {
                new Difficulty
                {
                    Id = Guid.Parse("9b1ac5bb-9241-47c8-9217-ac21ae9f1c88"),
                    Name = "Easy"
                },  
                new Difficulty
                {
                    Id = Guid.Parse("8e482dcb-811b-4abc-873d-8e2bcb092381"),
                    Name = "Medium"
                }, 
                new Difficulty
                {
                    Id = Guid.Parse("270c8c35-d791-4346-a0af-cf944cecc6e7"),
                    Name = "Hard"
                } 
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("0529e642-73fa-4937-b127-a8841ab27ec5"),
                    Code = "AKL",
                    Name = "Auckland",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/45/Auckland_Region_location_in_New_Zealand.svg/250px-Auckland_Region_location_in_New_Zealand.svg.png"

                },
                new Region
                {
                    Id = Guid.Parse("bba41656-6ba9-4e78-bac6-446ae3597cfc"),
                    Code = "WTC",
                    Name = "West Coast",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9f/West_Coast_Region_location_in_New_Zealand.svg/250px-West_Coast_Region_location_in_New_Zealand.svg.png"

                },
                new Region
                {
                    Id = Guid.Parse("c2cc249f-ec19-48ba-8898-e71cba88ea1f"),
                    Code = "WGN",
                    Name = "Wellington",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cd/Wellington_Region_location_in_New_Zealand.svg/250px-Wellington_Region_location_in_New_Zealand.svg.png"
                },
                new Region
                {
                    Id = Guid.Parse("8531ecb9-509a-4130-b384-56b9c97b2d56"),
                    Code = "CAN",
                    Name = "Canterbury",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/90/Canterbury_Region_location_in_New_Zealand.svg/250px-Canterbury_Region_location_in_New_Zealand.svg.png"
                },
                new Region
                {
                    Id = Guid.Parse("2bd150db-ebf5-4420-b4da-39d3ad60f1b1"),
                    Code = "OTA",
                    Name = "Otago",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/94/Otago_Region_location_in_New_Zealand.svg/250px-Otago_Region_location_in_New_Zealand.svg.png"
                },
                new Region
                {
                    Id = Guid.Parse("3b1e32dc-a9ff-4d11-b06c-82e057398b50"),
                    Code = "WKO",
                    Name = "Waikato",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ec/Waikato_Region_location_in_New_Zealand.svg/250px-Waikato_Region_location_in_New_Zealand.svg.png"
                },
                new Region
                {
                    Id = Guid.Parse("6787889d-7db0-47b0-8c20-7f5fb9c9ff45"),
                    Code = "BOP",
                    Name = "Bay Of Plenty",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d4/Bay_of_Plenty_Region_location_in_New_Zealand.svg/250px-Bay_of_Plenty_Region_location_in_New_Zealand.svg.png"
                }
            };
            modelBuilder.Entity<Region>().HasData(regions);

        }

    }
}