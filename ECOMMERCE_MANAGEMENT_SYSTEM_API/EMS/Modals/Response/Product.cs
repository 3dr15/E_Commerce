using ECommerce.HOST.Modals.Common;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.HOST.Modals.Response
{
    public class Product: ProductBase
    {
        [Required]
        public Guid ProductId { get; set; }
        public Category Category { get; set; }
    }
}
