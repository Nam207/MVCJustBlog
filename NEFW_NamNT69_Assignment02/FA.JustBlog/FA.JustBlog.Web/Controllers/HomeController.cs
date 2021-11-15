using FA.JustBlog.Services.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService postService;

        public HomeController(IPostService postService)
        {
            this.postService = postService;
        }

        //get post for Home
        public ActionResult Index(string pub = "")
        {
            if (string.IsNullOrEmpty(pub))
            {
                return View(this.postService.GetAllShortView());
            }
            else
            {
                return View(this.postService.GetAllShortView());
            }
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}