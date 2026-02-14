using todoApi.DTOs;
using todoApi.Entities;
using todoApi.Enums;
using todoApi.Repositories;

namespace todoApi.Services
{
    public class TodoService : TodoServiceInterface
    {
        private readonly TodoRepositoryInterface _repo;

        public TodoService(TodoRepositoryInterface repo)
        {
            _repo = repo;
        }

        public async Task<List<ResponseTodoDto>> GetAllAsync(bool? isCompleted, Priority? priority)
        {
            var items = await _repo.GetAllAsync(isCompleted, priority);

            return items.Select(Map).ToList();
        }

        public async Task<ResponseTodoDto?> GetByIdAsync(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            return item == null ? null : Map(item);
        }

        public async Task<ResponseTodoDto> CreateAsync(CreateTodoDto dto)
        {
            var item = new TodoItem
            {
                Title = dto.Title,
                Description = dto.Description,
                Priority = dto.Priority
            };

            await _repo.AddAsync(item);
            return Map(item);
        }

        public async Task<bool> UpdateAsync(int id, UpdateTodoDto dto)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null) return false;

            item.Title = dto.Title;
            item.Description = dto.Description;
            item.Priority = dto.Priority;
            item.IsCompleted = dto.IsCompleted;

            if (dto.IsCompleted && item.CompletedAt == null)
                item.CompletedAt = DateTime.UtcNow;

            await _repo.UpdateAsync(item);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null) return false;

            await _repo.DeleteAsync(item);
            return true;
        }

        public async Task<ResponseTodoDto?> CompleteAsync(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null) return null;

            item.IsCompleted = true;
            item.CompletedAt = DateTime.UtcNow;

            await _repo.UpdateAsync(item);
            return Map(item);
        }

        private static ResponseTodoDto Map(TodoItem x) => new()
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            IsCompleted = x.IsCompleted,
            Priority = x.Priority,
            CreatedAt = x.CreatedAt,
            CompletedAt = x.CompletedAt
        };
    }
}
