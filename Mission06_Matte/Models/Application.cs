using System.ComponentModel.DataAnnotations;

namespace Mission06_Matte.Models
{
    public class Application
    {   
        [Key]
        [Required] // Auto-increment for MovieId
        public int MovieId { get; set; }

        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string? Lentto { get; set; }
        [MaxLength(25)]
        public string? Notes { get; set; }




    }
}
