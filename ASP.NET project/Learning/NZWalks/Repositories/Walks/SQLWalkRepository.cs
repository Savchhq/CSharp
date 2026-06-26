using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;

namespace NZWalks.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;
        public SQLWalkRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }   
        public async Task<List<Walk>> GetAllAsync(string? filterName = null, string? filterQuery = null, string? sortBy = null, int pageNumber = 1, int pageSize = 10)
        {
            var walks = dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();
            if(string.IsNullOrWhiteSpace(filterName) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if(filterName.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
                else if (filterName.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    if (double.TryParse(filterQuery, out var lengthValue))
                    {
                        walks = walks.Where(x => x.LengthInKM == lengthValue);
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if(sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {

                    walks = walks.OrderBy(x => x.LengthInKM);
                }
                else if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.OrderBy(x => x.Name);
                }
            }

            var skipResults = (pageNumber - 1) * pageSize;

    
            return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
        }
        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Walk> AddAsync(Walk walk)
        {
            await dbContext.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }
        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await dbContext.Walks.FindAsync(id);
            if(existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKM = walk.LengthInKM;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await dbContext.SaveChangesAsync();
            return existingWalk;
        }
        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await dbContext.Walks.FindAsync(id);
            if(existingWalk == null)
            {
                return null;
            } 
            dbContext.Walks.Remove(existingWalk);
            await dbContext.SaveChangesAsync();
            return existingWalk;
        }

    }
}