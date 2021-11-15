using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;

namespace FA.JustBlog.Core.IRepositories
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Post FindPost(int year, int month, string urlSlug);

        IEnumerable<Post> GetPublisedPosts();

        IEnumerable<Post> GetUnpublisedPosts();

        IEnumerable<Post> GetLatestPost(int size);

        IEnumerable<Post> GetPostsByMonth(DateTime monthYear);

        int CountPostsForCategory(string category);

        IEnumerable<Post> GetPostsByCategory(string category);

        int CountPostsForTag(string tag);

        IEnumerable<Post> GetPostsByTag(string tag);

        IEnumerable<Post> GetMostViewedPost(int size);

        IEnumerable<Post> GetHighestPosts(int size);

    }
}