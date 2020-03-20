using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    class Node
    {
        // Осталось всего времени
        public int TimeLeft { get; set; }

        // Список фильмов
        public List<Movie> Films { get; set; }

        // Список дочерних вершин.
        public List<Node> Children { get; set; }

        // Cписок сеансов
        public List<Seance> Seanses { get; set; }

        public Node(int timeLeft, List<Movie> movies, List<Seance> seanses)
        {
            this.TimeLeft = timeLeft;
            this.Films = movies;
            Children = new List<Node>();
            Seanses = seanses;
        }
    }
}
