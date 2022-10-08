using ECommerce.HOST.Modals.Request;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.HOST.Modals.Common
{
    public class ProductBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        public DateTimeOffset? ExpiryDate { get; set; }
    }
}
