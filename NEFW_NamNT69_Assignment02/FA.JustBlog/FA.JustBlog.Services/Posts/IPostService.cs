using FA.JustBlog.ViewModels.Posts;
using FA.JustBlog.ViewModels.Results;
using System.Collections.Generic;

namespace FA.JustBlog.Services.Posts
{
    public interface IPostService
    {
        ResponseResult Create(CreatePostViewModel request);

        IEnumerable<PostViewModel> GetAll();

        IEnumerable<PostShortViewModel> GetAllShortView();

        PostViewModel GetPostById(int id);

        PostViewModel GetPostLatest();

        ResponseResult Update(UpdatePostViewModel request);

        IEnumerable<PostShortViewModel> GetAllPostShort();
    }
}