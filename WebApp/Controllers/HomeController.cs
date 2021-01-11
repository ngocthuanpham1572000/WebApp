using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Areas.Admin.Models;

namespace WebApp.Controllers
{
   
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
           
            return View();


        }
    }
}
