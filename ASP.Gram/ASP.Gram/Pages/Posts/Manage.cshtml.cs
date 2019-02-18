using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASP.Gram.Models;
using ASP.Gram.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ASP.Gram.Pages.Posts
{
    public class ManageModel : PageModel
    {
        private readonly IPosts _post;
        [BindProperty]
        public Post Post { get; set; }
        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public Models.Utilities.Blob BlobImage { get; set; }


        public ManageModel(IPosts post, IConfiguration configuration)
        {
            _post = post;
            ///Reference to blob storage account gateway to storage account
            BlobImage = new Models.Utilities.Blob(configuration);

        }
        public async Task OnGetAsync()
        {
            Post = await _post.FindPost(ID.GetValueOrDefault()) ?? new Post();
        }

        public async Task<IActionResult> OnPost()
        {
            var post = await _post.FindPost(ID.GetValueOrDefault()) ?? new Post();
            post.Author = Post.Author;
            //post.ImageURL = Post.ImageURL;
            post.Details = Post.Details;

            if(Image != null)
            {
                ///create temp file to hold image
                var filePath = Path.GetTempFileName();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream); ///copy image to file
                }

                var container = await BlobImage.GetContainer("images");

                BlobImage.UploadFile( Image.FileName, filePath, container);

                CloudBlob blob = await BlobImage.GetBlob(Image.FileName, container.Name);

                post.ImageURL = blob.Uri.ToString();


            }

            await _post.SaveAsync(post);

            return RedirectToPage("/Posts/Index", new { id = post.PostID });
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await _post.DeleteAsync(ID.Value);

            return RedirectToPage("/Index");
        }
    }
}