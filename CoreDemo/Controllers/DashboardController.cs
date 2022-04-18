using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.Blog_Count = c.Blogs.Count().ToString();
            ViewBag.BlogWriter_Count = c.Blogs.Where(x=>x.WriterId==1).Count().ToString();
            ViewBag.Categories_Count = c.Categories.Count().ToString();

            return View();
        }
    }
}
