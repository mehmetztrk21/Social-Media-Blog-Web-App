using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult BlogListByWriter()
        {
            var usermail = User.Identity.Name;  //Sisteme Giriş yapmış kullanıcı.
            Context c = new Context();
            var writerId = c.Writers.Where(i => i.mail == usermail).Select(x => x.Id).FirstOrDefault();
            var values = _blogs.GetListWithCategoryByWriter(writerId);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> category_values = (from x in cm.GetAll()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.name,
                                                        Value = x.Id.ToString()
                                                    }).ToList();
            ViewBag.category_values = category_values;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            var usermail = User.Identity.Name;  //Sisteme Giriş yapmış kullanıcı.
            Context c = new Context();
            var writerId = c.Writers.Where(i => i.mail == usermail).Select(x => x.Id).FirstOrDefault();
            BlogValidator blogValidator = new BlogValidator();
            ValidationResult results = blogValidator.Validate(blog);
            if (results.IsValid)
            {

                blog.status = true;
                blog.date = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = writerId;
                _blogs.Add(blog);
                return RedirectToAction("BlogListByWriter", "Blog");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(blog);
        }
        public IActionResult DeleteBlog(int id)
        {
            var value = _blogs.GetById(id);
            _blogs.Delete(value);
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> category_values = (from x in cm.GetAll()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.name,
                                                        Value = x.Id.ToString()
                                                    }).ToList();
            ViewBag.category_values = category_values;
            var blog = _blogs.GetById(id);
            return View(blog);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            var usermail = User.Identity.Name;  //Sisteme Giriş yapmış kullanıcı.
            Context c = new Context();
            var writerId = c.Writers.Where(i => i.mail == usermail).Select(x => x.Id).FirstOrDefault();
            blog.WriterId = writerId;
            _blogs.Update(blog);
            return RedirectToAction("BlogListByWriter", "Blog");
        }

    }
}
