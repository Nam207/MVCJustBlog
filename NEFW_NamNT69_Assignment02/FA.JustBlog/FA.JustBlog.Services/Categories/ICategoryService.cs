using FA.JustBlog.ViewModels.Categories;
using FA.JustBlog.ViewModels.Results;
using System.Collections.Generic;

namespace FA.JustBlog.Services.Categories
{
    public interface ICategoryService
    {
        IEnumerable<CategoryViewModel> GetAll();

        ResponseResult Create(CreateCategoryViewModel request);

        ResponseResult Update(UpdateCategoryViewModel request);

        UpdateCategoryViewModel GetCategoryById(int id);
    }
}