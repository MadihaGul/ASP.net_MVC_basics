using ASP.net_MVC_basics.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("GuessingGame", "Game");
        }
        [HttpGet]
        public IActionResult GuessingGame()
        {
            HttpContext.Session.SetString("SecretNumber", Utility.generateRandomNum().ToString());
            ViewBag.Message = Utility.gameStart();
            return View();
        }
        [HttpPost]
        public IActionResult GuessingGame(uint num)
        {
            if (Utility.CheckUint(Convert.ToString(num)))
            {
                ViewBag.Message = Utility.IsGuessRight(Convert.ToUInt32(HttpContext.Session.GetString("SecretNumber")), num);

            }
            else 
            {
                ViewBag.Message = "Error!! Invalid Input. Please enter a number between 1-100";
            }

            return View();
        }
    }
}
