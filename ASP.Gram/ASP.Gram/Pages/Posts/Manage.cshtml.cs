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
    public class ManageModel : PageModel
    {
        private readonly IPosts _post;
        [BindProperty]
        public Post Post { get; set; }
        [FromRoute]
        public int? ID { get; set; }
        public ManageModel(IPosts post)
        {
            _post = post;
        }
        public async Task OnGetAsync()
        {
            Post = await _post.FindPost(ID.GetValueOrDefault()) ?? new Post();
        }

        public async Task<IActionResult> OnPost()
        {
            var post = await _post.FindPost(ID.GetValueOrDefault()) ?? new Post();
            post.Author = Post.Author;
            post.ImageURL = Post.ImageURL;
            post.Details = Post.Details;

            await _post.SaveAsync(post);

            return RedirectToPage("/Posts/Index", new { id = post.ID });
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await _post.DeleteAsync(ID.Value);

            return RedirectToPage("/Index");
        }
    }
}