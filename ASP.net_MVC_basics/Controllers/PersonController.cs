﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.net_MVC_basics.Models;
using ASP.net_MVC_basics.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.net_MVC_basics.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;
        public  PersonController(ApplicationDbContext context)
        { _context = context; }
        
        public IActionResult Index()
        {
            PeopleViewModelDB ListPeopleViewModel = new PeopleViewModelDB { ListPersonView = _context.People.Include(p => p.City).ToList()};
            
            
            return View(ListPeopleViewModel);
        }

        [HttpPost]
        public IActionResult Index(PeopleViewModelDB viewModel)
        {
            viewModel.ListPersonView.Clear();
            if (viewModel.FilterString == "" || viewModel.FilterString == null)
            {
                viewModel.ListPersonView = _context.People.Include(p => p.City).ToList(); 
            }
            else
            {
                var listPerson =
                    _context.People.Include(p => p.City).Where(p => p.Name.ToLower().Contains(viewModel.FilterString.ToLower()));
                viewModel.ListPersonView.AddRange(listPerson.ToList());

                //foreach (var p in _context.People.ToList())
                //{
                //    if (p.Name.Contains(viewModel.FilterString, StringComparison.OrdinalIgnoreCase))
                //    {
                //        viewModel.ListPersonView.Add(p);

                //    }

                //}
            }
            return View(viewModel);
        }

        public IActionResult CreatePerson()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePerson([Bind("PersonId,Name,Phone,CityId")] PeopleModel peopleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peopleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", peopleModel.CityId);
            return View(peopleModel);
        }


        //[HttpPost]
        //public IActionResult CreatePerson(PeopleModel person)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.People.Add(person);
        //        _context.SaveChanges();
        //        TempData["shortMessage"] = "Success! Person added";
        //        return RedirectToAction("Index");

        //    }
        //    else
        //    {
        //        TempData["shortMessage"] = "Error! Failed to add person";// + ModelState.Values;

        //    }
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public IActionResult DeletePersonDb(int personId)
        //{

        //    if (ModelState.IsValid)
        //    {

        //        _context.People.Remove(_context.People.Find(personId));
        //        _context.SaveChanges();
        //        TempData["shortMessage"] = "Success! Person is deleted";

        //    }
        //    else { TempData["shortMessage"] = "Fail! Person not deleted"; }
        //    return RedirectToAction("Index");

        //}

        // GET: City/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peopleModel = await _context.People
                .Include(c => c.City)
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (peopleModel == null)
            {
                return NotFound();
            }

            return View(peopleModel);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peopleModel = await _context.People.FindAsync(id);
            _context.People.Remove(peopleModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        public IActionResult DeletePerson(int personId)
        {
            PersonMemory personMemory = new PersonMemory();
            Person targetPerson = personMemory.ReadPerson(personId);
            personMemory.DeletePerson(targetPerson);
            TempData["shortMessage"] = "Success! Person deleted";

            return RedirectToAction("Index");
        }


        public PartialViewResult PeopleList()
        {
            return PartialView("_partialListPeople");
        }

        private bool PeopleModelExists(int id)
        {
            return _context.People.Any(e => e.PersonId == id);
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
