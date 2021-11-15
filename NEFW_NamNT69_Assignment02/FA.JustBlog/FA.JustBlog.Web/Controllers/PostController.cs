using FA.JustBlog.Services.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        // GET: Post
        public ActionResult Index(int id = 0)
        {
            if(id == 0)
            {
                return View(this.postService.GetPostLatest());
            }
            else
            {
                return View(this.postService.GetPostById(id));
            }
        }
    }
}