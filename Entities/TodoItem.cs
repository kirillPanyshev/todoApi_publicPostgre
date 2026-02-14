using System.ComponentModel.DataAnnotations;
using todoApi.Enums;

namespace todoApi.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Title { get; set; } = null!;
        [MaxLength(1000)]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; }

        public Priority Priority { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? CompletedAt { get; set; }
    }
}
