using System.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComicBookGallery.Controllers;
using ComicBooks.Models;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Security.Cryptography;

namespace ComicBooks.data

{
    public class ComicRepository
    {



        private const string marvel_publicKey = "b075ca326169b3feb2a7c612c9fdd160";
        private const string marvel_privateKey = "f2d4b191fe33fbb7a0b86aeb9240a40d31397bd9";
        private string hashValue;

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

        // would need to be differnt for when getting info from Marvel's api 
        public ComicBook[] GetComicBooks()
        {
            // Would need to load it from the API frist 
            return _comicBooks;
        }
        public ComicBook[] GetComicBooks2()
        {


            long ticks = DateTime.Now.Ticks;
            string timeStamp = DateTime.Now.Ticks.ToString();
            string finalhash = calulateHash(timeStamp);
            string uri = String.Format("https://gateway.marvel.com:443/v1/public/comics?title=iron%20man&ts={0}&apikey={1}&hash={2}", ticks, marvel_publicKey, finalhash);

            Random rand = new Random();
            var offset = rand.Next(1400);

            WebClient webClient = new WebClient();
            webClient.Headers.Add("Ocp-Apim-Subscription-Key", marvel_publicKey);
            //webClient.Headers.Add(HttpRequestHeader.Accept, "applicaiton/json");
            //webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");


            var serializer = new JsonSerializer();
            // Download bytes of the url reuqest 
            byte[] jsondata = webClient.DownloadData(uri);
            //  transoform bytes  into jason string 
            string jsonData_string = Encoding.UTF8.GetString(jsondata);
            //demateralize json string 
            marvelComics marevel_Comics = JsonConvert.DeserializeObject<marvelComics>(jsonData_string);
            // Debug check results 
            System.Diagnostics.Debug.WriteLine(marevel_Comics.data.results.Length.ToString());
            System.Diagnostics.Debug.WriteLine(marevel_Comics.data.results[0].title.ToString());

            // put search results in varible 
            var marvelApiResults = marevel_Comics.data.results;
            int count = 0;

            foreach (marvelComics.Result marvel_comic in marvelApiResults)
            {
                // create commic book from comicbook class
                ComicBook result_commic = new ComicBook()
                {
                    SeriesTitle = marvel_comic.title,
                    Id = int.Parse(marvel_comic.id),
                    issueNumber = int.Parse(marvel_comic.issueNumber),
                    DescriptionHTML = marvel_comic.description,
                    Favorite = false,




                };
                //result_commic.artists = new Artists[marvel_comic.creators.items.Length];

                // enterintg artist  artist array 
                List<Artists> A_List = new List<Artists>();

                foreach (var m_artist in marvel_comic.creators.items)
                {
                    A_List.Add(new Artists() { Name = m_artist.name, Role = m_artist.role });
                }
                result_commic.artists = A_List.ToArray();



                //  adding to array
                //_comicBooks[_comicBooks.Length + 1] = result_commic;
                List<ComicBook> comic_list = _comicBooks.ToList<ComicBook>();
                comic_list.Add(result_commic);
                _comicBooks = new ComicBook[comic_list.Count];
                _comicBooks = comic_list.ToArray();

            }
            // HttpRequest req = new HttpRequest(null, uri, null);

            // Would need to load it from the API frist 
            return _comicBooks;
        }

        private string calulateHash(string timeStamp)
        {


            var toBehashed = timeStamp + marvel_privateKey + marvel_publicKey;



            string source = "Hello World!";
            using (MD5 md5Hash = MD5.Create())
            {
                hashValue = GetMd5Hash(md5Hash, toBehashed);

            }

            return hashValue;

        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }



        public ComicBook GetCommicBook(int id)
        {


            ComicBook comicBook = _comicBooks.First(e => e.Id == id);
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