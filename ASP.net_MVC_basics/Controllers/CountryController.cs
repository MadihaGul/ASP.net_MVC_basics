using ASP.net_MVC_basics.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CountryController(ApplicationDbContext context)
        { _context = context; }

        // GET: CountryController
        public ActionResult Index()
        {
            var CountryView = _context.Countries.ToList();
            if (TempData["shortMessage"] != null)
                ViewBag.Message = TempData["shortMessage"].ToString();
            return View(CountryView);
        }


        // GET: CountryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountryModel country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Countries.Add(country);
                    _context.SaveChanges();
                    TempData["shortMessage"] = "Success! Country added";
                    return RedirectToAction("Index");

                }
                else
                {
                    TempData["shortMessage"] = "Error! Failed to add country";

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CountryController/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryModel = await _context.Countries
                .FirstOrDefaultAsync(m => m.CountryId== id);
            if (countryModel == null)
            {
                return NotFound();
            }

            return View(countryModel);
        }

        // POST: CountryController/Delete/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var countryModel =  _context.Countries.Find(id);
                _context.Countries.Remove(countryModel);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
