using FA.JustBlog.Services.Posts;
using FA.JustBlog.Services.Categories;
using FA.JustBlog.ViewModels.Categories;
using FA.JustBlog.ViewModels.Posts;
using FA.JustBlog.ViewModels.Tags;
using System.Collections.Generic;
using System.Web.Mvc;
using FA.JustBlog.Services.Tags;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly ITagService tagService;
        private readonly ICategoryService categoryService;

        public PostController(IPostService postService, ICategoryService categoryService, ITagService tagService)
        {
            this.postService = postService;
            this.categoryService = categoryService;
            this.tagService = tagService;
        }

        // GET: Admin/Post
        public ActionResult Index()
        {
            var posts = this.postService.GetAllPostShort();
            return View(posts);
        }

        public ActionResult Create()
        {
            var categories = this.categoryService.GetAll();
            TempData["Categories"] = categories;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CreatePostViewModel request)
        {
            var categories = this.categoryService.GetAll();
            TempData["Categories"] = categories;
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var response = this.postService.Create(request);
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
            var categories = this.categoryService.GetAll();
            TempData["Categories"] = categories;
            var post = this.postService.GetPostById(id);
            TempData["Post"] = post;
            var tags = this.tagService.GetTagsByPostId(id);
            string tag = "";
            foreach(var element in tags)
            {
                tag += element.Name + "; ";
            }
            int temp = tag.Trim().LastIndexOf(";");
            tag = tag.Remove(temp);
            TempData["Tags"] = tag;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(UpdatePostViewModel request)
        {
            var categories = this.categoryService.GetAll();
            TempData["Categories"] = categories;
            var post = this.postService.GetPostById(request.Id);
            TempData["Post"] = post;
            var tags = this.tagService.GetTagsByPostId(request.Id);
            string tag = "";
            foreach (var element in tags)
            {
                tag += element.Name + "; ";
            }
            int temp = tag.Trim().LastIndexOf(";");
            tag = tag.Remove(temp);
            TempData["Tags"] = tag;
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var response = this.postService.Update(request);
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
            var categories = this.categoryService.GetAll();
            TempData["Categories"] = categories;
            var post = this.postService.GetPostById(id);
            TempData["Post"] = post;
            var tags = this.tagService.GetTagsByPostId(id);
            string tag = "";
            foreach (var element in tags)
            {
                tag += element.Name + "; ";
            }
            int temp = tag.Trim().LastIndexOf(";");
            tag = tag.Remove(temp);
            TempData["Tags"] = tag;
            return View();
        }
    }
}