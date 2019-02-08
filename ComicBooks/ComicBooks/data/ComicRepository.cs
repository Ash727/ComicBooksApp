using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComicBookGallery.Controllers;
using ComicBooks.Models;
using System.Net;

namespace ComicBooks.data
    
{
    public class ComicRepository
    {

        public ComicRepository() {
            
}


        private static ComicBook[] _comicBooks = new ComicBook[]
{
    new ComicBook()
    {
        SeriesTitle = "The Amazing Spider-Man",
        issueNumber = 700,
        DescriptionHTML = "<p>Final issue! Witness the final hours of Doctor Octopus' life and his one, last, great act of revenge! Even if Spider-Man survives...<strong>will Peter Parker?</strong></p>",
        artists = new Artists[]
        {
            new Artists() { Name = "Dan Slott", Role = "Script" },
            new Artists() { Name = "Humberto Ramos", Role = "Pencils" },
            new Artists() { Name = "Victor Olazaba", Role = "Inks" },
            new Artists() { Name = "Edgar Delgado", Role = "Colors" },
            new Artists() { Name = "Chris Eliopoulos", Role = "Letters" },
        },
        Favorite = false,
        Id = 1
    },
    new ComicBook()
    {
        SeriesTitle = "The Amazing Spider-Man",
        issueNumber = 657,
        DescriptionHTML = "<p><strong>FF: THREE TIE-IN.</strong> Spider-Man visits the FF for a very private wake--just for family.</p>",
        artists = new Artists[]
        {
            new Artists() { Name = "Dan Slott", Role = "Script" },
            new Artists() { Name = "Marcos Martin", Role = "Pencils" },
            new Artists() { Name = "Marcos Martin", Role = "Inks" },
            new Artists() { Name = "Muntsa Vicente", Role = "Colors" },
            new Artists() { Name = "Joe Caramagna", Role = "Letters" }
        },
        Favorite = false,
        Id = 2
    },
    new ComicBook()
    {
        SeriesTitle = "Bone",
        issueNumber = 50,
        DescriptionHTML = "<p><strong>The Dungeon & The Parapet, Part 1.</strong> Thorn is discovered by Lord Tarsil and the corrupted Stickeaters and thrown into a dungeon with Fone Bone. As she sleeps, a message comes to her about the mysterious \"Crown of Horns\".</p>",
        artists = new Artists[]
        {
            new Artists() { Name = "Jeff Smith", Role = "Script" },
            new Artists() { Name = "Jeff Smith", Role = "Pencils" },
            new Artists() { Name = "Jeff Smith", Role = "Inks" },
            new Artists() { Name = "Jeff Smith", Role = "Letters" }
        },
        Favorite = false,
        Id = 3
    }
};


        public ComicBook GetCommicBook (int id) {


            ComicBook comicBook =_comicBooks.First(e => e.Id == id);
            return comicBook; 
            
            //var comicBook = null;
            //foreach(var comic in _comicBooks)
            //{
            //    if (id.Equals(comic.Id)) {
            //        comicBook = comic;
            // break 
            //    }
                
            //}

            //return comicBook;

        }

    }
}