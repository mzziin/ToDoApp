using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]

        public string? Title { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        public TimeOnly Time { get; set; }
    }
}
