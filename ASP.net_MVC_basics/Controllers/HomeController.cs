using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "";
            return View();
        }

        public IActionResult Contact()
        {
          
            return View();
        }

        public IActionResult Projects()
        {
            ViewBag.Message = "";
            return View();
        }
    }
}
