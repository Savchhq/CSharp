using Microsoft.EntityFrameworkCore;
using TodoApp.Core.Interfaces;
using TodoApp.Core.Models;
using TodoApp.DAL.Data;

namespace TodoApp.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TodoAppDbContext dbContext;

    public UserRepository(TodoAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> CreateAsync(User user)
    {
        await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();
        return user;
    }
}