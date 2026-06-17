using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;

namespace NZWalks.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _dbContext;
        public SQLRegionRepository(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }
        /*public async Task<Region> GetByIdAsync(Guid id)
        {
            return await _dbContext.Regions.FindAsync(id);
        }
        public async Task<Region> AddAsync(Region region)
        {
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }
        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            await _dbContext.Regions.FindAsync(id);
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }
        public async Task<Region> DeleteAsync(Guid id)
        {
            
        }*/
    }
}