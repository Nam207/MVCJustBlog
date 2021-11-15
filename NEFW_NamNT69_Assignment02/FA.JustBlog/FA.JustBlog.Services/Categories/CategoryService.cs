using AutoMapper;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels.Categories;
using FA.JustBlog.ViewModels.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ResponseResult Create(CreateCategoryViewModel request)
        {
            try
            {
                var category = Mapper.Map<Category>(request);
                this.unitOfWork.CategoryRepository.Add(category);
                this.unitOfWork.SaveChanges();
                return new ResponseResult();
            }
            catch(Exception e)
            {
                return new ResponseResult(e.Message);
            }
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var categories = this.unitOfWork.CategoryRepository.GetAll();
            return Mapper.Map<IEnumerable<CategoryViewModel>>(categories); ;
        }

        public UpdateCategoryViewModel GetCategoryById(int id)
        {
            var category = this.unitOfWork.CategoryRepository.GetById(id);
            return Mapper.Map<UpdateCategoryViewModel>(category);
        }

        public ResponseResult Update(UpdateCategoryViewModel request)
        {
            try
            {
                var category = this.unitOfWork.CategoryRepository.GetById(request.Id);
                category.Name = request.Name;
                category.UrlSlug = request.UrlSlug;
                category.Description = request.Description;
                this.unitOfWork.CategoryRepository.Update(category);
                this.unitOfWork.SaveChanges();
                return new ResponseResult();
            }
            catch (Exception e)
            {
                return new ResponseResult(e.Message);
            }
        }
    }
}
