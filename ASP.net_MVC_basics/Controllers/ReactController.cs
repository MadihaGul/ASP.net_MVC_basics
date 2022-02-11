using ASP.net_MVC_basics.Data;
using ASP.net_MVC_basics.Models;
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
                if(peopleModel.SpeaksLanguages!=null)
                    { 
                    PeopleLanguageModel peopleLanguage = new PeopleLanguageModel();
                    foreach (var language in peopleModel.SpeaksLanguages)
                    {
                        peopleLanguage.LanguageId = language.LanguageId;
                        peopleLanguage.PersonId = peopleModel.PersonId;
                        _context.PeopleLanguage.Add(peopleLanguage);
                        _context.SaveChanges();
                    }
                }
                    return Json("Person created and saved");
                }
                
            }
            catch (Exception ex)
            { return Json(ex); }
            return Json(new { status = "Error", Message = "Person not saved" });
        }

        public JsonResult AddLanguage(PeopleLanguageModel peopleLanguage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(peopleLanguage);
                    _context.SaveChanges();
                   
                    return Json("Language saved");
                }

            }
            catch (Exception ex)
            { return Json(ex); }
            return Json(new { status = "Error", Message = "Language not saved" });
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
            ReactViewModel personDetails = new ReactViewModel();
            var PersonInfo = _context.People.Include(p => p.City).Include(p => p.SpeaksLanguages).Where(p=>p.PersonId==personId).SingleOrDefault();
            personDetails.PersonId = PersonInfo.PersonId;
            personDetails.Name = PersonInfo.Name;
            personDetails.Phone = PersonInfo.Phone;
       
            personDetails.City = PersonInfo.City.CityName;
            var personCountry = _context.Countries.Find(PersonInfo.City.CountryId);
            personDetails.Country = personCountry.CountryName;

            if (PersonInfo.SpeaksLanguages != null)
            { 
                foreach (var language in PersonInfo.SpeaksLanguages)
                {
                    foreach (var name in _context.Languages)
                    {
                        if (language.LanguageId.Equals(name.LanguageId))
                        { personDetails.SpeakLanguages += name.LanguageName+ "\t"; }
                    }
                }

            }
            return Json(personDetails);
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

        
    }
}
