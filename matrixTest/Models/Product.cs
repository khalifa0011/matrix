using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace matrixTest.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Qunatity { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
       public virtual Category Category { get; set; }
    }
}
