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
    public class ContactController : Controller
    {
       ContactManager cm = new ContactManager(new EfContactRepository());
       [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.date = DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.status = true;
            cm.ContactAdd(contact);
            return RedirectToAction("Index","Blog");
        }
    }
}
