using System.ComponentModel.DataAnnotations;

namespace GSULibrary.Models
{
    public class GSUBook
    {
        [Key]
        public int GSUBookId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Author { get; set; } = string.Empty;

        [Required]
        public string ISBN { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 1000, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 500, ErrorMessage = "Number of copies must be at least 1.")]
        public int NumberOfCopy { get; set; }
    }
}