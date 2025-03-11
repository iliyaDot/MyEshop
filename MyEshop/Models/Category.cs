using System.ComponentModel.DataAnnotations;

namespace MyEshop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }



        public ICollection<CategoryToProduct> categoryToProducts { get; set; }
    }
}
