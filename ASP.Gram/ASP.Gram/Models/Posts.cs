using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Gram.Models
{
    public class Posts
    {
        public int ID { get; set; }
        public string Author { get; set; }
        public string ImageURL { get; set; }
        public string Details { get; set; }
        public string Comment { get; set; }
    }
}
