using System.ComponentModel.DataAnnotations;

namespace UndoExample.Models
{
    public class TodoItem
    {
        [Required]
        public string Title { get; set; }
        public bool IsDone { get; set; }

    }
}
