using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FA.JustBlog.Core
{
    public class DbInitializer : CreateDatabaseIfNotExists<JustBlogContext>
    {
        public void SeedData(JustBlogContext context)
        {
            base.Seed(context);

            if (!context.Categories.Any())
            {
                var categories = new List<Category>()
                {
                    new Category()
                    {
                        Name = "Business",
                        UrlSlug = "",
                        Description = "Ok",
                    },
                    new Category()
                    {
                        Name = "Technology",
                        UrlSlug = "",
                        Description = "Good",
                    },
                    new Category()
                    {
                        Name = "Travel",
                        UrlSlug = "",
                        Description = "",
                    },
                };
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            if (!context.Tags.Any())
            {
                var tags = new List<Tag>()
                {
                    new Tag()
                    {
                        Name = "code",
                        UrlSlug = "",
                        Description = "",
                        Count = 1,
                    },
                    new Tag()
                    {
                        Name = "money",
                        UrlSlug = "",
                        Description = "",
                        Count = 2,
                    },
                    new Tag()
                    {
                        Name = "HoaLac",
                        UrlSlug = "",
                        Description = "",
                        Count = 1,
                    },
                };
                context.Tags.AddRange(tags);
                context.SaveChanges();
            }

            if (!context.Posts.Any())
            {
                var posts = new List<Post>()
                {
                    new Post()
                    {
                        Title = "Business",
                        ShortDescription ="",
                        PostContent = "Dang nghi",
                        UrlSlug = "k biet",
                        Published = "nam",
                        PostedOn = DateTime.UtcNow,
                        Modified = DateTime.UtcNow,
                        CategoryId = 1,
                    },
                    new Post()
                    {
                        Title = "Technology",
                        ShortDescription ="",
                        PostContent = "Dang nghi",
                        UrlSlug = "k biet",
                        Published = "nam",
                        PostedOn = DateTime.UtcNow,
                        Modified = DateTime.UtcNow,
                        CategoryId = 2,
                    },
                    new Post()
                    {
                        Title = "Travel",
                        ShortDescription ="",
                        PostContent = "Dang nghi",
                        UrlSlug = "k biet",
                        Published = "nam",
                        PostedOn = DateTime.UtcNow,
                        Modified = DateTime.UtcNow,
                        CategoryId = 1,
                    },
                };
                context.Posts.AddRange(posts);
                context.SaveChanges();
            }

            if (!context.PostTagMaps.Any())
            {
                var postTagMaps = new List<PostTagMap>()
                {
                    new PostTagMap()
                    {
                        PostId = 1,
                        TagId = 1,
                    },
                    new PostTagMap()
                    {
                        PostId = 1,
                        TagId = 2,
                    },
                    new PostTagMap()
                    {
                        PostId = 2,
                        TagId = 1,
                    },
                    new PostTagMap()
                    {
                        PostId = 2,
                        TagId = 2,
                    },
                    new PostTagMap()
                    {
                        PostId = 3,
                        TagId = 3,
                    },
                };
                context.PostTagMaps.AddRange(postTagMaps);
                context.SaveChanges();
            }
        }
    }
}