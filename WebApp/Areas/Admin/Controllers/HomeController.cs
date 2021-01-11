using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Areas.Admin.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            JObject us = JObject.Parse(HttpContext.Session.GetString("user"));
            Member mem = new Member();
            mem.Username = us.SelectToken("Username").ToString();
            mem.Password = us.SelectToken("Password").ToString();
            mem.Rule = Int32.Parse(us.SelectToken("Rule").ToString());
            return View(mem);


        }
    }
}
