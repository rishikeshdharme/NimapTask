using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NimapTask.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Product name is required")]
        public string ProductName { get; set; }


        [Required(ErrorMessage ="Product price is required")]
        [Precision(18, 2)]
        public decimal ProductPrice { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
