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
                    ImageURL = "http://1.bp.blogspot.com/-rbBG3L514tQ/UD9eJuVrH1I/AAAAAAAAIo0/RKOGYNs0WwM/s400/Outer+Space+Wallpapers+6.jpg",
                    Details = "Check out the orcas!"
                },
                  new Post
                {
                    ID = 3,
                    Author = "Captain Kirk",
                    ImageURL = "http://1.bp.blogspot.com/-rbBG3L514tQ/UD9eJuVrH1I/AAAAAAAAIo0/RKOGYNs0WwM/s400/Outer+Space+Wallpapers+6.jpg",
                    Details = "Captains log: We, have, found intelligent life on neptar."
                },
                  new Post
                {
                    ID = 4,
                    Author = "Legolas",
                    ImageURL = "http://1.bp.blogspot.com/-rbBG3L514tQ/UD9eJuVrH1I/AAAAAAAAIo0/RKOGYNs0WwM/s400/Outer+Space+Wallpapers+6.jpg",
                    Details = "1 million orcs killed. Time to break out the champagne!"
                },
                  new Post
                {
                    ID = 5,
                    Author = "John Snow",
                    ImageURL = "http://1.bp.blogspot.com/-rbBG3L514tQ/UD9eJuVrH1I/AAAAAAAAIo0/RKOGYNs0WwM/s400/Outer+Space+Wallpapers+6.jpg",
                    Details = "I may not know much but I know how to kill white walkes!"
                },
                new Post
                {
                    ID = 2,
                    Author = "Miss Jackson",
                    ImageURL = "http://1.bp.blogspot.com/-rbBG3L514tQ/UD9eJuVrH1I/AAAAAAAAIo0/RKOGYNs0WwM/s400/Outer+Space+Wallpapers+6.jpg",
                    Details = "I am for real!"
                }

            );
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comments> Comments { get; set; }
    }
}
