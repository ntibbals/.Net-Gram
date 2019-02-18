using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Gram.Models
{
    public class Post
    {
        public int PostID { get; set; }

        public string Author { get; set; }

        public string ImageURL { get; set; }
        public int Likes { get; set; }
        public string Details { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}
