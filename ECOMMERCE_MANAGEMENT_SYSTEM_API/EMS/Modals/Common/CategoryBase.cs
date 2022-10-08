using System.ComponentModel.DataAnnotations;

namespace ECommerce.HOST.Modals.Common
{
    public class CategoryBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
