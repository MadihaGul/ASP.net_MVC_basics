using ASP.net_MVC_basics.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult FeverCheck()
        {
            ViewBag.Message = Utility.msg();
            return View();
        }

        [HttpPost]
        public IActionResult FeverCheck(double temp)
        {
           
            ViewBag.Message = Utility.chkFever(temp);
            return View();

        }
    }
}
