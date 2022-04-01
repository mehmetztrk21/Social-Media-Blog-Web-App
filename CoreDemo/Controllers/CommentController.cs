using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class CommentController : Controller
    {
        CommentManager _commentManager = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddComment(Comment comment)
        {
            comment.date = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.status = true;
            comment.BlogId = 2;
            _commentManager.Add(comment);
            return PartialView();
        }
        public PartialViewResult CommentListByBlog(int id)
        {
            var values = _commentManager.GetAll(id);
            return PartialView(values);
        }
    }
}
