using AutoMapper;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.ViewModels.Tags;
using System.Collections.Generic;

namespace FA.JustBlog.Services.Tags
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork unitOfWork;

        public TagService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<TagViewModel> GetTagsByPostId(int postId)
        {
            var tags = this.unitOfWork.TagRepository.GetTagByPost(postId);
            return Mapper.Map<IEnumerable<TagViewModel>>(tags);
        }
    }
}