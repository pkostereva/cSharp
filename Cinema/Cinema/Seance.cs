using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    class Seance
    {
        public string MovieName { get; set; }
        public DateTime MovieStart { get; set; }
        public DateTime MovieEnd { get; set; }

        public Seance(string name, DateTime start, DateTime end)
        {
            MovieName = name;
            MovieStart = start;
            MovieEnd = end;

        }
    }
}
