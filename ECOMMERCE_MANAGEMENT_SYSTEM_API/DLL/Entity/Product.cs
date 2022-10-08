using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    public class Product
    {
        public Guid ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTimeOffset? ExpiryDate { get; set; }
    }
}
