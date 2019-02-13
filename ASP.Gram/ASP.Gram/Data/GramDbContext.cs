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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    ID = 1,
                    Author = "JTT",
                    ImageURL = "image.jpg",
                    Details = "Check out the orcas!"
                },
                new Post
                {
                    ID = 2,
                    Author = "Miss Jackson",
                    ImageURL = "image2.jpg",
                    Details = "I am for real!"
                }

            );
        }

        public DbSet<Post> Posts { get; set; }
    }
}
