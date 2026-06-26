using NZWalks.Models.Domain;

namespace NZWalks.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllAsync(string? filterName, string? filterQuery, string? sortBy, int pageNumber = 1, int pageSize = 10);
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk> AddAsync(Walk walk);
        Task<Walk?> UpdateAsync(Guid id, Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}