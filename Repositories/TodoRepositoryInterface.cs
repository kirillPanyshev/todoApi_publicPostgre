using todoApi.Entities;
using todoApi.Enums;

namespace todoApi.Repositories
{
    public interface TodoRepositoryInterface
    {
        Task<List<TodoItem>> GetAllAsync(bool? isCompleted, Priority? priority);
        Task<TodoItem?> GetByIdAsync(int id);
        Task<TodoItem> AddAsync(TodoItem item);
        Task UpdateAsync(TodoItem item);
        Task DeleteAsync(TodoItem item);
    }
}
