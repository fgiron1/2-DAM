using EjerciciosUD7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjerciciosUD7.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            clsPersona user = new clsPersona("Pepe", "Paluzo", DateTime.ParseExact("10-06-2000", "dd-MM-yyyy", null), "pepepaluzo@gmail.com", "+34654000000");

            //We determine morning, afternoon or night by the current hour (without minutes) as an int

            int currentHour = Int16.Parse(DateTime.Now.ToString("HH"));

            if (currentHour >= 6 && currentHour < 12)
            {
                ViewData["welcomeMsg"] = "Good morning";

            }else if (currentHour >= 12 && currentHour <= 23)
            {
                ViewData["welcomeMsg"] = "Good afternoon";
            } else if (currentHour == 24 || (currentHour >= 0 && currentHour < 6))
            {
                ViewData["welcomeMsg"] = "Good night";
            } else //In case currentHour stores a value out of 0-24 range
            {
                ViewData["welcomeMsg"] = "Welcome";
            }

            ViewBag.actualDate = DateTime.Now.ToLongDateString();

            return View(user);
        }
    }
}