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
        public string ProductName { get; set; }

        [Precision(18, 2)]
        public decimal ProductPrice { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
