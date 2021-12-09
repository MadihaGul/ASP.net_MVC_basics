using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.net_MVC_basics.Models;

namespace ASP.net_MVC_basics.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            PersonMemory personMemory = new PersonMemory();
            List<Person> peopleList = personMemory.ReadPerson();
            return PartialView("_partialListPeople", peopleList);
        }

    }
}
