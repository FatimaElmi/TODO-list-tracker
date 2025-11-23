using System;
using System.ComponentModel.DataAnnotations;

namespace TODO_list_tracker.DTOs
{
    public class UpdateTaskItemDto
    {
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public int Priority { get; set; }
        public int? CategoryId { get; set; }
    }
}