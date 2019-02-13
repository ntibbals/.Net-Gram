using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Gram.Models;
using ASP.Gram.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.Gram.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly IPosts _post;

        public IndexModel(IPosts post)
        {
            _post = post;
        }

        [FromRoute]
        public int ID { get; set; }

        public Post Post { get; set; }

        public async Task OnGet()
        {
            Post = await _post.FindPost(ID);
        }
    }
}