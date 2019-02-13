using ASP.Gram.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Gram.Data
{
    public class GramDbContext : DbContext
    {
        public GramDbContext (DbContextOptions<GramDbContext> options): base(options)
        {

        }

        public DbSet<Posts> Posts { get; set; }
    }
}
