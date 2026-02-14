using Microsoft.EntityFrameworkCore;
using todoApi.Entities;

namespace todoApi.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
       : base(options)
        {
        }

        public DbSet<TodoItem> Todos => Set<TodoItem>();
    }
}
