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
        public async Task DeleteAsync(int id)
        {
            Posts post = await _context.Posts.FindAsync(id);
            if(post != null)
            {
                _context.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Posts> FindPost(int id)
        {
            Posts post = await _context.Posts.FirstOrDefaultAsync(p => p.ID == id);

            return post;
        }

        public async Task<List<Posts>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task SaveAsync(Posts post)
        {
            Posts po = await _context.Posts.FirstOrDefaultAsync(p => p.ID == post.ID);

            if (post == null)
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
