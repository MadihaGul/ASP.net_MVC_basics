using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.net_MVC_basics.Models;

namespace ASP.net_MVC_basics.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {

            PersonMemory personMemory = new PersonMemory();
            PeopleViewModel ListPersonViewModel = new PeopleViewModel { ListPersonView= personMemory.ReadPerson() };
            if (ListPersonViewModel.ListPersonView.Count==0|| ListPersonViewModel.ListPersonView == null)
            {
                personMemory.SeedPerson();
            }
            return View(ListPersonViewModel);
        }

        [HttpPost]
        public IActionResult Index(PeopleViewModel viewModel)
        {

            PersonMemory personMemory = new PersonMemory();
            viewModel.ListPersonView.Clear();

            foreach (Person p in personMemory.ReadPerson())
            {
                if (p.Name.Contains(viewModel.FilterString, StringComparison.OrdinalIgnoreCase))
                {
                    viewModel.ListPersonView.Add(p);

                }

            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel cPersonViewModel)
        {

            PeopleViewModel newViewModel = new PeopleViewModel();
            PersonMemory personMemory = new PersonMemory();

            if (ModelState.IsValid)
            {
                newViewModel.Name = cPersonViewModel.Name;
                newViewModel.Phone = cPersonViewModel.Phone;
                newViewModel.City = cPersonViewModel.City;
                newViewModel.ListPersonView = personMemory.ReadPerson();

                personMemory.CreatePerson(cPersonViewModel.Name,cPersonViewModel.Phone,cPersonViewModel.City);
                ViewBag.Message="Success! Person added";
                return View("Index",newViewModel);

            }
            ViewBag.Message="Error! Failed to add person"+ModelState.Values;
            return View("Index", newViewModel);
        }
        public IActionResult DeletePerson(int personId)
        {
            PersonMemory personMemory = new PersonMemory();
            Person targetPerson = personMemory.ReadPerson(personId);
            personMemory.DeletePerson(targetPerson);

            return RedirectToAction("Index");
        }

        public PartialViewResult PeopleList()
        {
            return PartialView("_partialListPeople");


        }
    }
}
