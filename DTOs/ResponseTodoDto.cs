using todoApi.Enums;

namespace todoApi.DTOs
{
    public class ResponseTodoDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public Priority Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
