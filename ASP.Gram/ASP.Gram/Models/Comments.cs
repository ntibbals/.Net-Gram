using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Gram.Models
{
    public class Comments
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        [Column(TypeName = "varchar(max)")]
        [MaxLength]
        public string Comment { get; set; }
        public string Author { get; set; }
    }
}
