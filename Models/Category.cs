using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NimapTask.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Name is Required")]

        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
