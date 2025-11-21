using System.ComponentModel.DataAnnotations;

namespace TODO_list_tracker.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string UserId { get; set; }

        public ICollection<TaskItem> Tasks { get; set; }
    }
}
