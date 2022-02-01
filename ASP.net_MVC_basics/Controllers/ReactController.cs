using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Controllers
{
    public class ReactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
