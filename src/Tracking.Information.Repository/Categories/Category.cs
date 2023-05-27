using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Tracking.Information.Repository.Products;

namespace Tracking.Information.Repository.Categories
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Creation { get; set; }
        public ICollection<Product> ListProducts { get; set; }
    }
}
