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
        private readonly IComment _comment;

        public Comments Comment { get; set; }


        public IndexModel(IPosts post, IComment comment)
        {
            _post = post;
            _comment = comment;
        }

        [FromRoute]
        public int ID { get; set; }

        public Post Post { get; set; }

        /// <summary>
        /// Get all posts and comments
        /// </summary>
        /// <returns>posts</returns>
        public async Task OnGet()
        {
            Post = await _post.FindPost(ID);
            Comment = await _comment.FindComment(ID);
        }
    }
}