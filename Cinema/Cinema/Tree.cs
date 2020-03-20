using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema
{
    class Tree
    {
        Node root;
        int countOfHalls, numberOfHall;
        List<Node> listOfAllTimetable, optimalTimetable, templistOfTimetable;
        List<List<Node>> listOfTimetableByHalls;
        bool canCreate = true;

        public Tree(Node node, int countOfHalls)
        {
            root = node;
            this.countOfHalls = countOfHalls;
            numberOfHall = 1;
            listOfAllTimetable = new List<Node>();
            listOfTimetableByHalls = new List<List<Node>>();
        }
        public void Create()
        {
            CreateTree(root);
        }
        public void DisplayTimeTable()
        {
            CreateListOfTimeTable(root); // создаем список всех возможных вариантов
            CreateListOfTimetableByHalls(); // распределяем листы по залам
            CreateTempList(); // создаем первый вариант расписания
            OptimalTimetable(templistOfTimetable); // ищем оптимальное расписание
            Print(optimalTimetable); // выводим его
        }


        private void CreateTree(Node node)
        {
            for (int i = 0; i < node.Films.Count; i++) //перебираем сеансы 
            {

                if ((node.Films[i].MovieDuration <= node.TimeLeft)) // если осталось время
                {

                    Node newNode; //создаётся новая нода

                    //заполнение сеанса фильма
                    List<Seance> seanses = new List<Seance>(node.Seanses);
                    if (node.Seanses.Count == 0)
                    {
                        seanses.Add(new Seance($"{node.Films[i].MovieName}", new DateTime(2020, 1, 1, 8, 0, 0),
                                          new DateTime(2020, 1, 1, 8, 0, 0).AddMinutes(node.Films[i].MovieDuration)));
                    }
                    else
                    {
                        seanses.Add(new Seance($"{node.Films[i].MovieName}", node.Seanses[node.Seanses.Count - 1].MovieEnd,
                                        node.Seanses[node.Seanses.Count - 1].MovieEnd.AddMinutes(node.Films[i].MovieDuration))); 
                    }

                    newNode = new Node(node.TimeLeft - node.Films[i].MovieDuration, node.Films, seanses);

                    node.Children.Add(newNode); //связь с дочерними элементами 

                    CreateTree(newNode); //рекурсия, пока не закончится время
                }
            }
        }

        // Создаем список всех расписаний
        private void CreateListOfTimeTable(Node node)
        {
            if (node.Children.Count != 0)
            {
                foreach (Node i in node.Children)
                {
                    CreateListOfTimeTable(i);
                }
            }
            else
            {
                listOfAllTimetable.Add(node);
            }
            listOfAllTimetable = listOfAllTimetable.OrderBy(u => u.TimeLeft).ToList();
        }

        // Хитрая запись разных фильмов по расписаниям
        private void CreateListOfTimetableByHalls()
        {
            for (int i = 0; i < countOfHalls; i++)
            {
                List<Node> temp = new List<Node>();
                foreach (Node node in listOfAllTimetable)
                {
                    if (i < root.Films.Count)
                    {
                        if (node.Seanses[0].MovieName == root.Films[i].MovieName)
                        {
                            temp.Add(node);
                        }
                    }
                    else
                    {
                        if (root.Films.Count == 1)
                        {
                            break;
                        }

                        if ((int)Math.Floor((double)(i / root.Films.Count)) < root.Films.Count)
                        {
                            temp.Add(listOfTimetableByHalls[i % root.Films.Count][(int)Math.Floor((double)(i / root.Films.Count))]);
                        }
                        else
                        {
                            canCreate = false;
                            temp.Add(listOfTimetableByHalls[i % root.Films.Count][root.Films.Count - 1]);
                        }
                    }
                }
                listOfTimetableByHalls.Add(temp);
            }
        }

        // временное расписание (если встречаются все фильмы (следующий метод) - оно оптимальное)
        private void CreateTempList()
        {
            templistOfTimetable = new List<Node>();
            for (int i = 0; i < countOfHalls; i++)
            {
                templistOfTimetable.Add(listOfTimetableByHalls[i][0]);
            }
        }

        // Поиск оптимального расписания (если встречаются все фильмы - временное расписание становится оптимальным, 
        // если нет такого расписания - то берутся расписания по порядку)
        // хардкод - 3
        private void OptimalTimetable(List<Node> templistOfTimatable)
        {
            // если все фильмы встречаются во временном списке расписаний
            optimalTimetable = new List<Node>();
            if (FilmIsMeet(templistOfTimatable))
            {
                optimalTimetable = templistOfTimatable;
                return;
            }
            else
            {
                for (int i = 0; i < listOfTimetableByHalls[0].Count; i++)
                {
                    templistOfTimetable[0] = listOfTimetableByHalls[0][i];
                    for (int j = 0; j < listOfTimetableByHalls[1].Count; j++)
                    {
                        templistOfTimetable[1] = listOfTimetableByHalls[1][j];
                        if (templistOfTimetable.Count > 2)
                        {
                            for (int k = 0; k < listOfTimetableByHalls[2].Count; k++)
                            {
                                templistOfTimetable[2] = listOfTimetableByHalls[2][k];
                                if (FilmIsMeet(templistOfTimetable))
                                {
                                    optimalTimetable = templistOfTimetable;
                                    return;
                                }
                            }
                        }
                        if (FilmIsMeet(templistOfTimetable))
                        {
                            optimalTimetable = templistOfTimetable;
                            return;
                        }
                    }
                }
            }
        }

        // Вывод на экран расписания
        private void Print(List<Node> optimalTimetable)
        {
            if (optimalTimetable.Count == 0 || !canCreate)
            {
                Console.WriteLine();
                Console.WriteLine("nope");
                return;
            }
            else
            {
                for (int i = 0; i < optimalTimetable.Count; i++)
                {
                    Console.WriteLine($"Расписание в зале № {numberOfHall}:");
                    int TimeLeft = optimalTimetable[i].TimeLeft;
                    foreach (Seance seance in optimalTimetable[i].Seanses)
                    {
                        Console.WriteLine($"{seance.MovieStart.ToShortTimeString()} - {seance.MovieEnd.ToShortTimeString()} : {seance.MovieName}");
                    }
                    Console.WriteLine($"свободное оставшееся время: {TimeLeft} минут \n");
                    numberOfHall++;

                    if (numberOfHall > countOfHalls)
                    {
                        return;
                    }
                }
            }

        }

        // Условие, чтобы все фильмы встречались в расписании
        private bool FilmIsMeet(List<Node> list)
        {
            bool allright = true;
            bool[] meetingMovies = new bool[root.Films.Count];

            for (int i = 0; i < root.Films.Count; i++)
            {
                foreach (Node nod in list)
                {
                    for (int j = 0; j < nod.Seanses.Count; j++)
                    {
                        if (nod.Seanses[j].MovieName == root.Films[i].MovieName)
                        {
                            meetingMovies[i] = true;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < meetingMovies.Count(); i++)
            {
                allright = allright && meetingMovies[i];
            }
            return allright;
        }
    }
}
