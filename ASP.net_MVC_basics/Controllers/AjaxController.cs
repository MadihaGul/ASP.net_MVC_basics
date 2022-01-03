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
            PersonMemory personMemory = new PersonMemory();
            PeopleViewModel ListPersonViewModel = new PeopleViewModel { ListPersonView = personMemory.ReadPerson() };
            if (ListPersonViewModel.ListPersonView.Count == 0 || ListPersonViewModel.ListPersonView == null)
            {
                personMemory.SeedPerson();
            }
            return View();
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            PersonMemory personMemory = new PersonMemory();
            List<Person> peopleList = personMemory.ReadPerson();
            if (peopleList.Count==0 || peopleList==null) { }
            return PartialView("_partialListPeopleAjax", peopleList);
        }

        [HttpPost]
        public IActionResult FindPeopleById(int PeopleId)
        {
            PersonMemory personMemory = new PersonMemory();
            Person targetPerson =personMemory.ReadPerson(PeopleId);
            List<Person> people = new List<Person>();
            if (targetPerson!=null)
            {
                people.Add(targetPerson);
            }
            return PartialView("_partialListPeopleAjax", people);
        }

        [HttpPost]
        public IActionResult DeletePeopleById(int PeopleId)
        {
            bool sucess = false;
            PersonMemory personMemory = new PersonMemory();
            Person targetPerson = personMemory.ReadPerson(PeopleId);
            List<Person> people = personMemory.ReadPerson();
            if (targetPerson != null)
            {
                sucess=people.Remove(targetPerson);


            }
            if (sucess)
            { return StatusCode(200); }
            else
            { return StatusCode(404); }
        }

    }
}
