using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    class Movie
    {
        public string MovieName { get; set; }
        public int MovieDuration { get; set; }

        public Movie(string name, int duration)
        {
            MovieName = name;
            MovieDuration = duration;
        }
        //public Film() { }
    }
}
