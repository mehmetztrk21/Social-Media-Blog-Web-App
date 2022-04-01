using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Blog
{
    public class WriterLastBlog:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke(int id,int valid_blog_id)
        {
            var values = bm.GetBlogListByWriter(id).Where(i=>i.Id!=valid_blog_id);
            return View(values);
        }
    }
}
