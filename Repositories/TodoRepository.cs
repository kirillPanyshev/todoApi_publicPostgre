using Microsoft.EntityFrameworkCore;
using todoApi.Data;
using todoApi.Entities;
using todoApi.Enums;

namespace todoApi.Repositories
{
    public class TodoRepository : TodoRepositoryInterface
    {
        private readonly TodoDbContext _context;

        public TodoRepository(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<List<TodoItem>> GetAllAsync(bool? isCompleted, Priority? priority)
        {
            var query = _context.Todos.AsQueryable();

            if (isCompleted.HasValue)
                query = query.Where(x => x.IsCompleted == isCompleted);

            if (priority.HasValue)
                query = query.Where(x => x.Priority == priority);

            return await query.ToListAsync();
        }

        public async Task<TodoItem?> GetByIdAsync(int id)
            => await _context.Todos.FindAsync(id);

        public async Task<TodoItem> AddAsync(TodoItem item)
        {
            _context.Todos.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task UpdateAsync(TodoItem item)
        {
            _context.Todos.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TodoItem item)
        {
            _context.Todos.Remove(item);
            await _context.SaveChangesAsync();
        }
    }

}
