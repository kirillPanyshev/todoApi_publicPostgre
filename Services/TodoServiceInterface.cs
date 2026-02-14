using todoApi.DTOs;
using todoApi.Enums;

namespace todoApi.Services
{
    public interface TodoServiceInterface
    {
        Task<List<ResponseTodoDto>> GetAllAsync(bool? isCompleted, Priority? priority);
        Task<ResponseTodoDto?> GetByIdAsync(int id);
        Task<ResponseTodoDto> CreateAsync(CreateTodoDto dto);
        Task<bool> UpdateAsync(int id, UpdateTodoDto dto);
        Task<bool> DeleteAsync(int id);
        Task<ResponseTodoDto?> CompleteAsync(int id);

    }
}
