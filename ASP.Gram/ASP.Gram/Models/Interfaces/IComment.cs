using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Gram.Models.Interfaces
{
    interface IComment
    {
        Task<Comments> FindComment(int id);
        Task<List<Comments>> GetComments();
        Task SaveCoAsync(Comments comment);
        Task DeleteCoAsync(int id);

    }
}
