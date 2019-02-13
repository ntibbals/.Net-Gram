using ASP.Gram.Data;
using ASP.Gram.Models.Interfaces;
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
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Posts> FindPost(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Posts>> GetPosts()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Posts post)
        {
            throw new NotImplementedException();
        }
    }
}
