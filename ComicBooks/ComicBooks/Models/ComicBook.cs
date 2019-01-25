using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicBooks.Models
{
    public class ComicBook
    {
        public int Id { get; set; }
        public string SerisTitle { get; set; }
        public int issueNumber { get; set; }
        public String DescriptionHTML { get; set; }
        public Artists [] artists { get; set; }
        public bool Favorite { get; set; }

        

    }
}