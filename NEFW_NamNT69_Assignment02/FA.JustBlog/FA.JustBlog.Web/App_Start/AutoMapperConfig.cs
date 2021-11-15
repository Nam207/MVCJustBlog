using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels.Categories;
using FA.JustBlog.ViewModels.Posts;
using FA.JustBlog.ViewModels.Tags;

namespace FA.JustBlog.Web.App_Start
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CreatePostViewModel, Post>().ReverseMap();

            CreateMap<PostViewModel, Post>().ReverseMap();

            CreateMap<UpdatePostViewModel, Post>().ReverseMap();

            CreateMap<PostShortViewModel, Post>().ReverseMap();

            CreateMap<CategoryViewModel, Category>().ReverseMap();

            CreateMap<TagViewModel, Tag>().ReverseMap();

            CreateMap<CategoryViewModel, Category>().ReverseMap();
        }
    }
}