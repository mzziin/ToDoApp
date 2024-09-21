using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
    public class Task
    {
        [Key]
        int Id { get; set; }
        [Required]
        [MaxLength(50)]

        public string? Title { get; set; }
        [MaxLength(250)]
        public string? Description { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
    }
}
