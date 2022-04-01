using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]  //startup ta yazdığımız bütün kısıtlamalardan muaf ol diyoruz.
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Writer writer)
        {
            Context db = new Context();
            var value = db.Writers.FirstOrDefault(x => x.mail == writer.mail && x.password == writer.password);
            if (value != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,writer.mail)
                };
                var useridentity = new ClaimsIdentity(claims, "admin");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Writer");

            }
            return View();
        }
    }
}
