using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Model
{
    public class Product
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Price")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double Price { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Image_Name")]
        public string Image_Name { get; set; }

        [Display(Name = "Rating")]
        public int Rating { get; set; }
    }
}
