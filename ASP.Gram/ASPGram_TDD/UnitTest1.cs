using System;
using Xunit;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ASP.Gram.Data;
using ASP.Gram.Models;
using ASP.Gram.Models.Services;

namespace ASPGram_TDD
{
    public class UnitTest1
    {
        [Fact]
        public void getID()
        {
            // can get ID
            Post testPost = new Post();
            testPost.ID = 7;
            Assert.True(testPost.ID == 7);
        }

        [Fact]
        public void setID()
        {
            // can set ID
            Post testPost = new Post();
            testPost.ID = 7;
            testPost.ID = 77;
            Assert.True(testPost.ID == 77);
        }


        [Fact]
        public async void TestSaveNewPost()
        {
            ///Test that you save
            DbContextOptions<GramDbContext> options = new DbContextOptionsBuilder<GramDbContext>().UseInMemoryDatabase("CreatePost").Options;

            using (GramDbContext context = new GramDbContext(options))
            {
                Post post = new Post();
                post.ID = 1;
                PostManager manager = new PostManager(context);
                await manager.SaveAsync(post);
                Post testPost = await context.Posts.FirstOrDefaultAsync(p => p.ID == post.ID);
                Assert.Equal(1, testPost.ID);

            }
        }

        [Fact]
        public async void TestPostCanFind()
        {
            ///Test that you can find a post
            DbContextOptions<GramDbContext> options = new DbContextOptionsBuilder<GramDbContext>().UseInMemoryDatabase("FindPost").Options;

            using (GramDbContext context = new GramDbContext(options))
            {
                Post post = new Post();
                PostManager manager = new PostManager(context);
                post.ID = 3;
                post.Details = "Cray";
                await manager.SaveAsync(post);

                Post testPost = await manager.FindPost(post.ID);
                Assert.Equal(3, testPost.ID);

            }

        }
                    [Fact]
        public async void TestPostCanEdit()
        {
            ///Test that you can edit a post
            DbContextOptions<GramDbContext> options = new DbContextOptionsBuilder<GramDbContext>().UseInMemoryDatabase("EditPost").Options;

            using (GramDbContext context = new GramDbContext(options))
            {
                Post post = new Post();
                PostManager manager = new PostManager(context);
                post.ID = 4;
                post.Details = "Cray";
                post.Author = "JTT";
                await manager.SaveAsync(post);

                post.Details = "Changed cray";
                string expected = "Changed cray";
                Post testPost = await manager.FindPost(post.ID);
                Assert.Equal(expected, testPost.Details);

            }
        }

        [Fact]
        public async void TestPostCanDelete()
        {
            ///Test that you can delete a post
            DbContextOptions<GramDbContext> options = new DbContextOptionsBuilder<GramDbContext>().UseInMemoryDatabase("DeletePost").Options;

            using (GramDbContext context = new GramDbContext(options))
            {
                Post post = new Post();
                PostManager manager = new PostManager(context);
                post.ID = 4;
                post.Details = "Cray";
                post.Author = "JTT";
                await manager.SaveAsync(post);
                await manager.DeleteAsync(post.ID);
               
                Assert.Null(await manager.FindPost(post.ID));

            }
        }
    }
}
