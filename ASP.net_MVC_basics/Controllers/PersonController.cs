using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.net_MVC_basics.Models;
using ASP.net_MVC_basics.Data;

namespace ASP.net_MVC_basics.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;
        public  PersonController(ApplicationDbContext context)
        { _context = context; }
        
        public IActionResult Index()
        {
            PeopleViewModelDB ListPeopleViewModel = new PeopleViewModelDB { ListPersonView = _context.People.ToList()};
    
            return View(ListPeopleViewModel);
        }

        [HttpPost]
        public IActionResult Index(PeopleViewModelDB viewModel)
        {
            viewModel.ListPersonView.Clear();
            if (viewModel.FilterString == "" || viewModel.FilterString == null)
            { viewModel.ListPersonView = _context.People.ToList(); }
            else
            {
                foreach (var p in _context.People.ToList())
                {
                    if (p.Name.Contains(viewModel.FilterString, StringComparison.OrdinalIgnoreCase))
                    {
                        viewModel.ListPersonView.Add(p);

                    }

                }
            }
            return View(viewModel);
        }

        public IActionResult CreatePerson()
        {
            return View();

        }

        [HttpPost]
        public IActionResult CreatePerson(PeopleModel person)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(person);
                _context.SaveChanges();
                ViewBag.Message = "Success! Person added";
                return RedirectToAction("Index");

            }
            ViewBag.Message = "Error! Failed to add person" + ModelState.Values;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeletePersonDb(int personId)
        {
            
            if (ModelState.IsValid)
            {

                _context.People.Remove(_context.People.Find(personId));
                _context.SaveChanges();
                ViewBag.Message = "Success! Person deleted";
            }
            return RedirectToAction("Index");
            
        }
        
        public IActionResult DeletePerson(int personId)
        {
            PersonMemory personMemory = new PersonMemory();
            Person targetPerson = personMemory.ReadPerson(personId);
            personMemory.DeletePerson(targetPerson);
            ViewBag.Message = "Success! Person deleted";

            return RedirectToAction("Index");
        }


        public PartialViewResult PeopleList()
        {
            return PartialView("_partialListPeople");
        }

        /*
         
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
         */
    }
}
