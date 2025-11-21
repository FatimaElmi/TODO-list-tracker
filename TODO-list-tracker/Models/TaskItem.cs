using System.ComponentModel.DataAnnotations;

namespace TODO_list_tracker.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public int Priority { get; set; } // low=1, medium=2 high=3

       public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public string UserId { get; set; } // link to user identity
    }
}
