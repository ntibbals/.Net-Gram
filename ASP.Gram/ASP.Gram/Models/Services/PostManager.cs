using ASP.Gram.Data;
using ASP.Gram.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Gram.Models.Services
{
    public class PostManager : IPosts
    {
        private readonly GramDbContext _context;
        public PostManager(GramDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Delete Post
        /// </summary>
        /// <param name="id">post id</param>
        /// <returns>view</returns>
        public async Task DeleteAsync(int id)
        {
            Post post = await _context.Posts.FindAsync(id);
            if(post != null)
            {
                _context.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Find post
        /// </summary>
        /// <param name="id">post id</param>
        /// <returns>found post</returns>
        public async Task<Post> FindPost(int id)
        {
            Post post = await _context.Posts.FirstOrDefaultAsync(p => p.ID == id);

            return post;
        }

        /// <summary>
        /// Get all posts
        /// </summary>
        /// <returns>all posts</returns>
        public async Task<List<Post>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        /// <summary>
        /// Save post
        /// </summary>
        /// <param name="post">post object</param>
        /// <returns>Saved Post</returns>
        public async Task SaveAsync(Post post)
        {
            Post po = await _context.Posts.FirstOrDefaultAsync(p => p.ID == post.ID);

            if (po == null)
            {
                _context.Posts.Add(post);
            }

            else
            {
                po = post;
                _context.Posts.Update(po);
            }

            await _context.SaveChangesAsync();
        }
    }
}
