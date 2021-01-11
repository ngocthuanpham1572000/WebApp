using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Areas.Admin.Data;
using WebApp.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly EcommerceDB _context;
        public LoginController(EcommerceDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Username,Password")] Member member)
        {
            var r = _context.Member.Where(m => (m.Username == member.Username && m.Password == StringProcessing.CreateMD5Hash(member.Password))).ToList();
            if (r.Count == 0)
            {
                return View("Index");

            }
            var str = JsonConvert.SerializeObject(member);
            HttpContext.Session.SetString("user", str);
            if(r[0].Rule==0)
            {
                var url = Url.RouteUrl("areas", new { controller = "Home", action = "Index", area = "Admin" });
                return Redirect(url);

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
