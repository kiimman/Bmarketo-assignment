using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webbmvcapp.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [MinLength(10)]
        public string? Description { get; set; }
        [Required]
        public string? Category { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string? ImageURL { get; set; }
        [NotMapped]
        [Required]
        public IFormFile? File { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
