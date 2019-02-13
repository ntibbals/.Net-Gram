using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Gram.Models.Interfaces
{
    public interface IPosts
    {

        Task<Post> FindPost(int id);
        Task<List<Post>> GetPosts();
        Task SaveAsync(Post post);
        Task DeleteAsync(int id);
    }
}
