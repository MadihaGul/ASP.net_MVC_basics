using ASP.net_MVC_basics.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Controllers
{
    [Authorize(Roles = "Admin")]
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

        // GET:
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryModel = await _context.Countries.FindAsync(id);
            if (countryModel == null)
            {
                return NotFound();
            }
            return View(countryModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CountryId,CountryName")] CountryModel countryModel)
        {
            if (id != countryModel.CountryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(countryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryModelExists(countryModel.CountryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
           return View(countryModel);
        }
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


        private bool CountryModelExists(int id)
        {
            return _context.Countries.Any(e => e.CountryId == id);
        }
    }
}
