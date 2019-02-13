using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Gram.Models
{
    public class Post
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please provide a Username")]
        [Display(Name = "Username")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Please provide an image")]
        [Display(Name = "Image URL")]
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "Please provide a caption")]
        [Display(Name = "Caption")]
        public string Details { get; set; }
        public string Comment { get; set; }
    }
}
