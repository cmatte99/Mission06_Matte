using System.ComponentModel.DataAnnotations;

namespace Mission06_Matte.Models
{
    // Model class representing a category for movies
    public class Category
    {
        // Primary key for the category
        [Key]
        public int CategoryId { get; set; }

        // Name of the category
        public string CategoryName { get; set; }
    }
}
