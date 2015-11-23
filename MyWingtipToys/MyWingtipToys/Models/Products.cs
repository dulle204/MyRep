using System.ComponentModel.DataAnnotations;

namespace MyWingtipToys.Models
{
    public class Products
    {
        [Key, ScaffoldColumn(false)]
        public int ProductID { get; set; }   

        [Required, StringLength(100), Display(Name ="Name")]
        public string ProductName { get; set; }

        [Required, StringLength(10000), Display(Name ="Product Description")]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        [Display(Name ="Price")]
        public double? UnitPrice { get; set; }

        public int? CategoryID { get; set; }

        public Category Category { get; set; }
    }
}