using Microsoft.Build.Framework;

namespace DAL.Entity
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
