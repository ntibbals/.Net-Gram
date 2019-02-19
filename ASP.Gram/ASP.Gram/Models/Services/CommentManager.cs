using ASP.Gram.Data;
using ASP.Gram.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Gram.Models.Services
{
    public class CommentManager : IComment
    {
        private readonly GramDbContext _context;

        public CommentManager(GramDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Delete Comment
        /// </summary>
        /// <param name="id">Comment ID</param>
        /// <returns>saved changes</returns>
        public async Task DeleteCoAsync(int id)
        {
            Comments comment = await _context.Comments.FindAsync(id);
            if(comment !=null)
            {
                _context.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Find a comment by id
        /// </summary>
        /// <param name="id">comment id</param>
        /// <returns>found comment</returns>
        public async Task<Comments> FindComment(int id)
        {
            Comments comment = await _context.Comments.FirstOrDefaultAsync(c => c.ID == id);

            return comment;
        }

        /// <summary>
        /// Get all comments
        /// </summary>
        /// <returns>all comments</returns>
        public async Task<List<Comments>> GetComments()
        {
            return await _context.Comments.ToListAsync();
        }

        /// <summary>
        /// Save comments
        /// </summary>
        /// <param name="comment">Comment object</param>
        /// <returns>view</returns>
        public async Task SaveCoAsync(Comments comment)
        {
            Comments co = await _context.Comments.FirstOrDefaultAsync(c => c.ID == comment.ID);
            if (comment == null)
            {
                _context.Comments.Add(comment);
            }

            else
            {
                co = comment;
                _context.Comments.Update(co);
            }

            await _context.SaveChangesAsync();
        }
    }
}
