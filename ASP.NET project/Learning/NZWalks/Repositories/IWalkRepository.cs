using NZWalks.Models.Domain;

namespace NZWalks.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllAsync(string? FilterName, string? FilterQuery);
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk> AddAsync(Walk walk);
        Task<Walk?> UpdateAsync(Guid id, Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}