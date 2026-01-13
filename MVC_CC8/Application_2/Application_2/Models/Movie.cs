using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesApp.Models
{
    public class Movie
    {
        public int Mid { get; set; }
        public string Moviename { get; set; }
        public string DirectorName { get; set; }
        public DateTime DateofRelease { get; set; }
    }
}
