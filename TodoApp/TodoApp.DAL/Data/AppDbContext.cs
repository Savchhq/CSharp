using Microsoft.EntityFrameworkCore;
using TodoApp.Core.Models;
namespace NZWalks.Data
{
    public class TodoAppDbContext : DbContext
    {
        public TodoAppDbContext(DbContextOptions dbContextOptions): base( dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TodoTask> TodoTasks { get; set; } // need to create migration, connect db
    }
}