using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicBooks.Models
{
    public class ComicBook
    {
        public int Id { get; set; }
        public string SeriesTitle { get; set; }
        public string issueNumber { get; set; }
        public String DescriptionHTML { get; set; }
        public Artists [] artists { get; set; }
        public bool Favorite { get; set; }
        public string DisplayText { get {
                return SeriesTitle + " #" + issueNumber;
            } }
        // for eventual json data string that comes in using marvel API 
    
        public string ImageLink { set; get; }

        // Seris-title- issunumeber.jpg commic image 
        //public string CoverImageFileName {

        //    get {
        //        return SeriesTitle.Replace(" ", "-").ToLower() + "-" + issueNumber +".jpg";
               
        //    }
            
        //}
    }
}