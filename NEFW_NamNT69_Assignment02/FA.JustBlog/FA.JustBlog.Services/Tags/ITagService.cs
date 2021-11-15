using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels.Tags;
using System.Collections.Generic;

namespace FA.JustBlog.Services.Tags
{
    public interface ITagService
    {
        IEnumerable<TagViewModel> GetTagsByPostId(int postId);
    }
}