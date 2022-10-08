using ECommerce.HOST.Modals.Common;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.HOST.Modals.Request
{
    public class UpdateProduct: ProductBase
    {
        [Required]
        public Guid ProductId { get; set; }
    }
}
