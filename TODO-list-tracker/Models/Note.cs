using System.ComponentModel.DataAnnotations;

namespace TODO_list_tracker.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        
        
        // Link note to the logged-in user
        public string UserId { get; set; }  
    }
}
