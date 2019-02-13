using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Gram.Models.Interfaces
{
    public interface IPosts
    {

        Task<Posts> FindPost(int id);
        Task<List<Posts>> GetPosts();
        Task SaveAsync(Posts post);
        Task DeleteAsync(int id);
    }
}
