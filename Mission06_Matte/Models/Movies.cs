using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Matte.Models
{
    // Movie entity class representing the data structure for movies
    public class Movies
    {
        // Primary key for the Movie entity
        [Key]
        [Required]
        public int MovieId { get; set; }

        // Foreign key to link the movie with a category
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }

        // Navigation property representing the associated category
        public Category? Category { get; set; }

        // Required property for the movie title
        [Required(ErrorMessage = "Sorry, the Title Field is Required.")]
        public string? Title { get; set; }

        // Required property for the movie release year with a range constraint
        [Required(ErrorMessage = "Sorry, the Year Field is Required.")]
        [Range(minimum: 1888, maximum: double.MaxValue, ErrorMessage = "Year must be at least 1888")]
        public int? Year { get; set; }

        // Property for the movie director
        public string? Director { get; set; }

        // Property for the movie rating
        public string? Rating { get; set; }

        // Required property indicating whether the movie is edited
        [Required(ErrorMessage = "Sorry, the Edited Field is Required.")]
        public bool? Edited { get; set; }

        // Property indicating to whom the movie is lent
        public string? LentTo { get; set; }

        // Required property indicating whether the movie is copied to Plex
        [Required(ErrorMessage = "Sorry, the CopiedToPlex Field is Required.")]
        public bool? CopiedToPlex { get; set; }

        // Property for additional notes about the movie
        public string? Notes { get; set; }
    }
}
