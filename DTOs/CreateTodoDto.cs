using System.ComponentModel.DataAnnotations;
using todoApi.Enums;

namespace todoApi.DTOs
{
    public class CreateTodoDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = null!;

        [MaxLength(1000)]
        public string? Description { get; set; }

        public Priority Priority { get; set; }
    }
}
