using FA.JustBlog.Common;
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
    public class TagRepository: GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(JustBlogContext context) : base(context)
        {
            Console.WriteLine("TagRepository is created");
        }

        public IEnumerable<int> AddTagByString(string tags)
        {
            var tagNames = tags.Split(';');
            foreach(var element in tagNames)
            {
                var tagExisting = this.context.Tags.Where(t => t.Name.Trim().ToLower() == element.Trim().ToLower()).Count();
                if(tagExisting == 0)
                {
                    var tag = new Tag()
                    {
                        Name = element.Trim(),
                        UrlSlug = UrlSlugHelper.FrientlyUrl(element.Trim()),
                    };
                    this.context.Tags.Add(tag);
                }
            }
            this.context.SaveChanges();

            foreach(var element in tagNames)
            {
                var tagExisting = this.context.Tags.FirstOrDefault(t => t.Name.Trim().ToLower() == element.Trim().ToLower());
                if(tagExisting != null)
                {
                    yield return tagExisting.Id;
                }
            }
        }

        public IEnumerable<Tag> GetTagByPost(int postId)
        {
            var tagIds = context.PostTagMaps.Where(ptm => ptm.PostId == postId).ToList();
            foreach(var element in tagIds)
            {
                yield return context.Tags.Where(t => t.Id == element.TagId).ToList().FirstOrDefault();
            }
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return context.Tags.Where(t => t.UrlSlug.ToLower().Equals(urlSlug.ToLower())).FirstOrDefault();
        }
    }
}
