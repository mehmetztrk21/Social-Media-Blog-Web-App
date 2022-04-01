using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager _blogs = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            return View(_blogs.GetBlogsWithCategoryName());
        }

        public IActionResult Details(int id)
        {
            ViewBag.id = id;
            var value = _blogs.GetById(id);
            return View(value);
        }


    }
}
