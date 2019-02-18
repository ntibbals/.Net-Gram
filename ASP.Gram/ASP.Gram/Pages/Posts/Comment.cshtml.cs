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
    public class CommentModel : PageModel
    {
        private readonly IComment _comment;

        [BindProperty]
        public Comments Comment { get; set; }

        [FromRoute]
        public int? ID { get; set; }

        public CommentModel(IComment comment)
        {
            _comment = comment;
        }

        public void OnGet()
        {
        }
    }
}