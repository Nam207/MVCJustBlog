using FA.JustBlog.Services.Categories;
using FA.JustBlog.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: Admin/Category
        public ActionResult Index()
        {
            var categories = this.categoryService.GetAll();
            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CreateCategoryViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var response = this.categoryService.Create(request);
            if (response.IsSuccessed)
            {
                TempData["Message"] = "Add Success";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View();
        }

        public ActionResult Update(int id)
        {
            var category = this.categoryService.GetCategoryById(id);
            TempData["Category"] = category;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(UpdateCategoryViewModel request)
        {
            var category = this.categoryService.GetCategoryById(request.Id);
            TempData["Category"] = category;
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var response = this.categoryService.Update(request);
            if (response.IsSuccessed)
            {
                TempData["Message"] = "Update Success";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View();
        }

        public ActionResult Detail(int id)
        {
            var category = this.categoryService.GetCategoryById(id);
            TempData["Category"] = category;
            return View();
        }
    }
}