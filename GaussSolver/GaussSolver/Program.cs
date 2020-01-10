using System;

namespace GaussSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Random rnd = new Random();
            double[,] arr = new double[6, 6];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i == j || j > i)
                    {
                        arr[i, j] = rnd.Next(10);
                    }
                }
            }

            

            double[] vec = new double[6];
            for (int i = 0; i < vec.Length - 1; i++)
            {
                vec[i] = rnd.Next(10);
            }

            int[] idx = new int[6];
            for (int i = 0; i < idx.Length; i++)
            {
                idx[i] = i;
            }

            Gauss g = new Gauss();
            g.AddMatrix(arr);
            g.AddVector(vec);
            g.PrintMatrix();
            g.DivisionRows();
            Console.WriteLine();
            g.PrintMatrix();
            g.PrintVector(g.vectorB);
            //Console.WriteLine();
            ////g.PrintVector(g.IndexOfColumns());
            //g.GaussForwardStroke(idx);
            //g.PrintMatrix();
            //Console.WriteLine();
            ////g.GaussBackwardStroke(idx);

            //g.PrintVector(g.GaussSolve());
            //Console.WriteLine();

        }

    }
}
