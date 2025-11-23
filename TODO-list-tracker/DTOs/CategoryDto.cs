using System.ComponentModel.DataAnnotations;

namespace TODO_list_tracker.DTOs
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; }
        public string? UserId { get; set; }
    }
}