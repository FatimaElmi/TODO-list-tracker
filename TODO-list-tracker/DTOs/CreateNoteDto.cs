using System.ComponentModel.DataAnnotations;

namespace TODO_list_tracker.DTOs
{
    public class CreateNoteDto
    {
        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }
    }
}