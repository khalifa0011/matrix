using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace matrixTest.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Category Partent { get; set; }
        public  ICollection<Product> Products { get; set; }
        public  ICollection<Property> properties { get; set; }
        
    }
}
