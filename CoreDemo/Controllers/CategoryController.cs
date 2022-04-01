using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager=new CategoryManager(new EfCategoryRepository());
      
        public IActionResult Index()
        {
            
            return View(_categoryManager.GetAll());
        }
    }
}
