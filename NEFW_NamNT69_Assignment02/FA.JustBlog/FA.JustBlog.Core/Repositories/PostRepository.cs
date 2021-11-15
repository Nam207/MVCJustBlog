using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.IRepositories;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(JustBlogContext context) : base(context)
        {
            Console.WriteLine("PostRepository is created");
        }

        public int CountPostsForCategory(string category)
        {
            return context.Posts.Count(p => p.category.Name.ToLower().Equals(category.ToLower()));
        }

        public int CountPostsForTag(string tag)
        {
            return context.PostTagMaps.Count(p => p.tag.Name.ToLower().Equals(tag.ToLower()));
        }

        public Post FindPost(int year, int month, string urlSlug)
        {
            return context.Posts.Where(p => p.PostedOn.Year == year && p.PostedOn.Month == month
                && p.UrlSlug.ToLower().Equals(urlSlug.ToLower())).FirstOrDefault();
        }

        public IEnumerable<Post> GetHighestPosts(int size)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetLatestPost(int size)
        {
            return context.Posts.OrderByDescending(p => p.PostedOn).Take(size);
        }

        public IEnumerable<Post> GetMostViewedPost(int size)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostsByCategory(string category)
        {
            return context.Posts.Where(p => p.category.Name.ToLower().Equals(category.ToLower()));
        }

        public IEnumerable<Post> GetPostsByMonth(DateTime monthYear)
        {
            return context.Posts.Where(p => p.PostedOn == monthYear);
        }

        public IEnumerable<Post> GetPostsByTag(string tag)
        {
            return context.Posts.Where(p => p.PostTagMaps.Any(ptm => ptm.tag.Name.ToLower().Equals(tag.ToLower())));
        }

        public IEnumerable<Post> GetPublisedPosts()
        {
            return context.Posts.Where(p => p.Published != null);
        }

        public IEnumerable<Post> GetUnpublisedPosts()
        {
            return context.Posts.Where(p => p.Published == null);
        }
    }
}
