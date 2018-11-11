using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicBookGallery.Controllers
{
    // Note that for any view used the Name of the fuew must
    // Match the method along with the class in its file structure
    // that is ComicBooks-> detail-> Detail For file structure 
    public class ComicBooksController : Controller
    {
        
        public string index()
        {
            return "Hellow world";
        }


        
        public ActionResult Detail2()
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
            {
                return new RedirectResult("/");

            }
            return new ContentResult()
            {
                Content = "Hello From commic Controller"
            };
        }

    





        public ActionResult Detail()
        {
            ViewBag.SerisTitle = "The amazing Spider-Man";
            ViewBag.IssueNumber = 700;
            ViewBag.Description = "<p>Final issue! Witness the final hours of Doctor Octopus' life and his one, last, great act of revenge! Even if Spider-Man survives... <strong>will Peter Parker?</strong></p>";
            ViewBag.Artists = new string[]
            {
        "Script: Dan Slott",
        "Pencils: Humberto Ramos",
        "Inks: Victor Olazaba",
        "Colors: Edgar Delgado",
        "Letters: Chris Eliopoulos"
            };


            return View("Detail");
        }


    }

    public class HomeController : Controller
    {
        public string index()
        {
            return "Hellow world";
        }
    }
}