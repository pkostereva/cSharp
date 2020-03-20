using System;
using System.Collections.Generic;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfHalls = 0, countOfMovies = 0;
            List<Movie> moviesList = new List<Movie>();
            while (countOfHalls == 0)
            {
                Console.WriteLine("Введите количество залов в кинотеатре:");
                while (Int32.TryParse(Console.ReadLine(), out int result))
                {
                    countOfHalls = result;
                    break;
                }
            }

            while (countOfMovies == 0)
            {
                Console.WriteLine("Введите количество фильмов:");
                while (Int32.TryParse(Console.ReadLine(), out int result))
                {
                    if (result > 1)
                    {
                        countOfMovies = result;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Введите количество фильмов > 1:");
                        continue;
                    }

                }
            }


            for (int i = 0; i < countOfMovies; i++)
            {
                int movieDuration = 0;
                string movieName = "";
                while (movieDuration == 0)
                {
                    Console.WriteLine($"Введите название и длительность сеанса №{i + 1} в минутах.");
                    movieName = Console.ReadLine();
                    while (Int32.TryParse(Console.ReadLine(), out int result))
                    {
                        movieDuration = result;
                        break;
                    }
                }

                moviesList.Add(new Movie(movieName, movieDuration));
            }


            Tree tree = new Tree(new Node(840, moviesList, new List<Seance>()), countOfHalls);
            tree.Create();
            tree.DisplayTimeTable();
        }
    }
}
