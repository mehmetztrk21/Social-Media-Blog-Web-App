using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;  //Sisteme Giriş yapmış kullanıcı.
            Context c = new Context();
            var writer = c.Writers.Where(i => i.mail == usermail).FirstOrDefault();
            return View(writer);
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult WriterEditProfile()
        {

            var usermail = User.Identity.Name;  //Sisteme Giriş yapmış kullanıcı.
            Context c = new Context();
            var writerId = c.Writers.Where(i => i.mail == usermail).Select(x => x.Id).FirstOrDefault();
            var values = wm.GetById(writerId);
            return View(values);
        }

        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidator wl = new WriterValidator();
            ValidationResult results = wl.Validate(writer);
            if (results.IsValid)
            {
                wm.Update(writer);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddWriterModel entity)
        {
         
            Writer writer = new Writer();
            writer.mail = entity.mail;
            writer.name = entity.name;
            writer.password = entity.password;
            writer.status = true;
            writer.about = entity.about;
            wm.Add(writer);
            if (entity.image != null)
            {
                var extension = Path.GetExtension(entity.image.FileName);
                var image_name = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/writer/WriterImages/", image_name);
                var stream = new FileStream(location, FileMode.Create);
                entity.image.CopyTo(stream);
                writer.image = image_name;
               
            }
            return RedirectToAction("Index", "Dashboard");

        }
    }
}

