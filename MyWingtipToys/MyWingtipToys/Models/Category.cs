using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MyWingtipToys.Models
{
    public class Category
    {
        [ScaffoldColumn(false)]
        public int CategoryID { get; set; }

        [Required, StringLength(10000), Display(Name ="CAtegory Name")]
        public string CategoryName { get; set; }

        [Display(Name ="Description")]
        public string Description { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}