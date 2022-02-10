using ASP.net_MVC_basics.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Controllers
{
    [Authorize]
    public class ReactController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReactController(ApplicationDbContext context)
        { _context = context; }
        public IActionResult Index()
        {
            return (IActionResult)View();
        }

        public JsonResult GetPeople()
        {
            var PeopleList = _context.People.ToList();
            
            return Json(PeopleList);
        }

        [HttpPost]
        public JsonResult CreatePerson(PeopleModel peopleModel)
        {
            try {
                if (ModelState.IsValid)
                {
                    _context.Add(peopleModel);
                     _context.SaveChanges();
                    return Json("Person created and saved");
                }
                
            }
            catch (Exception ex)
            { return Json(ex); }
            return Json(new { status = "Error", Message = "Person not saved" });
        }

        public JsonResult DeletePerson(int personId)
        {
            if (personId != 0)
            {
                var person = _context.People.Find(personId);
                if (person != null)
                {
                    _context.People.Remove(person);
                    _context.SaveChanges();
                    return Json("Success! Person deleted");
                }
                else { return Json("Alert! Person doesn't exist"); }
               
                
            }

            return Json("Error! Person not deleted");
        }
        public JsonResult GetPersonDetails(int personId) 
        {
            var personInfo =//_context.People.Include(p => p.City).Where(x => x.PersonId == personId).SingleOrDefault();
           _context.People.Where(x => x.PersonId == personId).SingleOrDefault();
            return Json(personInfo);
            //new { status = "Error", Message = "Person not saved" }
        }

        public JsonResult GetInitialCites()
        {
            CityModel none = new CityModel
            {
                CityId = 0,
                CityName = "none"
            };
            List<CityModel> CityList = new List<CityModel>();
            CityList.Add(none);
            //CityList.AddRange(_context.Cities.ToList());
            return Json(CityList);
        }
        public JsonResult GetCountries()
        {
            CountryModel Select = new CountryModel
            {
                CountryId = 0,
                CountryName = "Select"
            };
            List<CountryModel> CountryList = new List<CountryModel>();

            CountryList.Add(Select);
            CountryList.AddRange(_context.Countries.ToList());
            return Json(CountryList);
        }

        public JsonResult GetLanguages()
        {
            LanguageModel Select = new LanguageModel
            {
                LanguageId = 0,
                LanguageName = "Select"
            };
            List<LanguageModel> LanguageList = new List<LanguageModel>();

            LanguageList.Add(Select);
            LanguageList.AddRange(_context.Languages.ToList());
            return Json(LanguageList);
        }

        [HttpPost]
        public JsonResult GetCities(int countryId)
        {
            CityModel Select = new CityModel
            {
                CityId = 0,
                CityName = "Select"
            };
            List<CityModel> CityList = new List<CityModel>();
            CityList.Add(Select);
            CityList.AddRange(_context.Cities.Where(c => c.CountryId == countryId));

            return Json(CityList);
        }

        public JsonResult DetailPerson( int id)
        {
            PeopleModel PersonDetail = _context.People.Find(id);

            return Json(PersonDetail);
        }

        
    }
}
