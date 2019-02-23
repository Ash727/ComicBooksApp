using ComicBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ComicBooks.data;
using System.Web.UI;

namespace ComicBookGallery.Controllers
{
    // Note that for any view used the Name of the fuew must
    // Match the method along with the class in its file structure
    // that is ComicBooks-> detail-> Detail For file structure 
    public class ComicBooksController : Controller
    {
        ComicRepository _comicbookRepo;
        public ComicBooksController()
        {
            _comicbookRepo = new ComicRepository();

        }
        //public string index()
        //{
        //    return "Hellow world";
        //}


        
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


        [HttpGet]
        [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)] // will be applied to all actions in MyController, unless those actions override with their own decoration
        public ActionResult index()
        { 
            var comicBooks = _comicbookRepo.GetComicBooks2();
            //Console.WriteLine("FUlly responsive ");
           // System.Diagnostics.Debug.WriteLine("SomeText");
           

            // Not the at comicBooks si the model expected 
            return View("index",comicBooks);
        }

        // get request with already linked string 


        [HttpGet]
        [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)] // will be applied to all actions in MyController, unless those actions override with their own decoration
        public ActionResult Search(string Search)
        {
            Response.Cache.SetNoStore();
            Response.Cache.AppendCacheExtension("no-cache");
;
            

            if (Search == null) {
                return HttpNotFound("These are not the drones your looking for ");
            }
            var comicBooks = _comicbookRepo.GetComicSearch(Search);
            //Console.WriteLine("FUlly responsive ");
            // System.Diagnostics.Debug.WriteLine("SomeText");

            System.Diagnostics.Debug.WriteLine("This is your search"+Search);

            ViewBag.Search = Search;
            // Not the at comicBooks si the model expected 
            return View("Search",comicBooks);
        }




        //the paramter int is added to the last section of the url 
        // the ? mark just makes it non nullable 
        // commibBook/Detail/id
        public ActionResult Detail(int? id)
        {
            if (id == null) {
                return HttpNotFound();
            }
            var comicBook = _comicbookRepo.GetCommicBook((int)id);
           //var comicBook = new ComicBook()
            //{ //object initializer syntax 


            //    SerisTitle = "The amazing Spider-Man",
            //    issueNumber = 700,
            //    DescriptionHTML = "<p>Final issue! Witness the final hours of Doctor Octopus' life and his one, last, great act of revenge! Even if Spider-Man survives... <strong>will Peter Parker?</strong></p>",
            //    artists = new Artists[]
            //    {
            //     new Artists() { Name = "Dan Slott", Role="Script"},
            //     new Artists() { Name = "Humberto Ramos", Role = "Pencils" },
            //     new Artists() { Name = "Victor Olazaba", Role="Inks"},
            //     new Artists() { Name = "Edgar Delgado", Role = "Colors" },
            //     new Artists() { Name = "Chris Elipoulos", Role = "Letters" },
            //    }


            //};
            
           

        //    ViewBag.SerisTitle = "The amazing Spider-Man";
        //    ViewBag.IssueNumber = 700;
        //    ViewBag.Image = "";
        //    ViewBag.Description = "<p>Final issue! Witness the final hours of Doctor Octopus' life and his one, last, great act of revenge! Even if Spider-Man survives... <strong>will Peter Parker?</strong></p>";
        //    ViewBag.Artists = new string[]
        //    {
        //"Inks: Victor Olazaba",
        //"Colors: Edgar Delgado",
        //"Letters: Chris Eliopoulos"
        //    };

            // UPdate view to be strongly typed MVC view associated with a type 
            // Exposes model instance  with model property 
            return View("Detail",comicBook);
        }


    }

    //public class HomeController : Controller
    //{
    //    public string index()
    //    {
    //        return "Hellow world";
    //    }
    //}
}