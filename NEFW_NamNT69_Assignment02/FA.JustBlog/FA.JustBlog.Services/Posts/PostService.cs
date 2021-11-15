using AutoMapper;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels.Posts;
using FA.JustBlog.ViewModels.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FA.JustBlog.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ResponseResult Create(CreatePostViewModel request)
        {
            try
            {
                var tagId = this.unitOfWork.TagRepository.AddTagByString(request.Tags);

                var postTagMaps = new List<PostTagMap>();
                foreach(var tag in tagId)
                {
                    var postTagMap = new PostTagMap()
                    {
                        TagId = tag,
                    };
                    postTagMaps.Add(postTagMap);
                }

                var post = new Post()
                {
                    Title = request.Title,
                    UrlSlug = request.UrlSlug,
                    CategoryId = request.CategoryId,
                    ShortDescription = request.ShortDescription,
                    PostContent = request.PostContent,
                    PostedOn = DateTime.UtcNow,
                    Modified = DateTime.UtcNow,
                    Published = request.Published,
                    PostTagMaps = postTagMaps,
                };
                this.unitOfWork.PostRepository.Add(post);
                this.unitOfWork.SaveChanges();
                return new ResponseResult();
            }
            catch (Exception e)
            {
                return new ResponseResult(e.Message);
            }
        }

        public IEnumerable<PostViewModel> GetAll()
        {
            var posts = this.unitOfWork.PostRepository.GetAll();
            return Mapper.Map<IEnumerable<PostViewModel>>(posts);
        }

        public IEnumerable<PostShortViewModel> GetAllPostShort()
        {
            var posts = this.unitOfWork.PostRepository.GetAll();
            return Mapper.Map<IEnumerable<PostShortViewModel>>(posts);
        }

        public IEnumerable<PostShortViewModel> GetAllShortView()
        {
            var posts = this.unitOfWork.PostRepository.GetLatestPost(5);
            return Mapper.Map<IEnumerable<PostShortViewModel>>(posts);
        }

        public PostViewModel GetPostById(int id)
        {
            var post = this.unitOfWork.PostRepository.GetById(id);
            return Mapper.Map<PostViewModel>(post);
        }

        public PostViewModel GetPostLatest()
        {
            var posts = this.unitOfWork.PostRepository.GetLatestPost(1);
            return Mapper.Map<PostViewModel>(posts.FirstOrDefault());
        }

        public ResponseResult Update(UpdatePostViewModel request)
        {
            try
            {
                var tagId = this.unitOfWork.TagRepository.AddTagByString(request.Tags);

                var postTagMaps = new List<PostTagMap>();
                foreach (var tag in tagId)
                {
                    var postTagMap = new PostTagMap()
                    {
                        TagId = tag,
                    };
                    postTagMaps.Add(postTagMap);
                }

                var post = this.unitOfWork.PostRepository.GetById(request.Id);
                post.Title = request.Title;
                post.UrlSlug = request.UrlSlug;
                post.ShortDescription = request.ShortDescription;
                post.Published = request.Published;
                post.CategoryId = request.CategoryId;
                post.Modified = DateTime.UtcNow;
                post.PostContent = request.PostContent;
                post.Status = request.Status;
                post.PostTagMaps = postTagMaps;
                this.unitOfWork.PostRepository.Update(post);
                this.unitOfWork.SaveChanges();
                return new ResponseResult();
            }
            catch(Exception e)
            {
                return new ResponseResult(e.Message);
            }
        }
    }
}