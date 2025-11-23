using System.ComponentModel.DataAnnotations;

namespace TODO_list_tracker.DTOs
{
    public class CreateTaskItemDto
    {
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; } = 2;
        public int? CategoryId { get; set; }
    }
}
