using System.ComponentModel.DataAnnotations;

namespace TODO_list_tracker.DTOs
{
    public class UpdateCategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}