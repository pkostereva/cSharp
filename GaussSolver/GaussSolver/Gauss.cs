using System;
using System.Collections.Generic;
using System.Text;

namespace GaussSolver
{
    public class Gauss
    {
        public double[,] matrixA;
        public double[] vectorB { get; set; }
        private int size { get; set; }

        public void PrintMatrix()
        {
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    Console.Write("{0,6}", Math.Round(matrixA[i,j],3));
                }
                Console.WriteLine();
            }
        }

        public void PrintVector(double[] vector)
        { 
            for (int i = 0; i < vector.Length; i++)
                Console.WriteLine(vector[i] + " ");
        }

        public void AddMatrix(double[,] arr)
        {
            matrixA = arr;
        }

        public void AddVector(double[] vec)
        {
            vectorB = vec;
        }

        public int[] IndexOfColumns()
        {
            int[] arr = new int[matrixA.GetLength(1)];
            for (int i = 0; i < matrixA.GetLength(1); i++)
            {
                arr[i] = i;
            }
            return arr;
        }

        // Прямой ход метода Гаусса
        //public void GaussForwardStroke(int[] index) {
        //    int size = matrixA.GetLength(0);
        //    // перемещаемся по каждой строке сверху вниз
        //    for (int i = 0; i < size; ++i) {
        //        // 1) выбор главного элемента
        //        double r = matrixA[i,i];

        //        // 2) преобразование текущей строки матрицы A
        //        for (int j = 0; j < size; ++j)
        //            matrixA[i, j] /= r;

        //        // 3) преобразование i-го элемента вектора b
        //        vectorB[i] /= r;

        //        // 4) Вычитание текущей строки из всех нижерасположенных строк
        //        for (int k = i + 1; k < size; ++k) {
        //            double p = matrixA[k, index[i]];
        //            for (int j = i; j < size; ++j)
        //                matrixA[k, index[j]] -= matrixA[i, index[j]] * p;
        //            vectorB[k] -= vectorB[i] * p;
        //            matrixA[k, index[i]] = 0;
        //        }
        //    }
        //}

        // Обратный ход метода Гаусса
        //public double[] GaussBackwardStroke(int[] index)
        //{
        //    int size = matrixA.GetLength(0);
        //    double[] vectorX = new double[vectorB.Length];
        //    // перемещаемся по каждой строке снизу вверх
        //    for (int i = size - 1; i >= 0; --i)
        //    {
        //        // 1) задаётся начальное значение элемента x
        //        double xI = vectorB[i];

        //        // 2) корректировка этого значения (на первой итерации не заходит в этот цикл)
        //        for (int j = i + 1; j < size; ++j)
        //            xI -= vectorX[index[j]] * matrixA[i, index[j]];
        //        vectorX[index[i]] = Math.Round(xI, 3);
        //    }
        //    return vectorX;
        //}

        public void DivisionRows()
        {
            int size = matrixA.GetLength(0);
            double[,] arr2 = new double[size, size];
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    if (j >= i)
                    {
                        arr2[i, j] = matrixA[i, j] / matrixA[i, i];

                    }
                    vectorB[i] /= matrixA[i, i];
                }
            }
            matrixA = arr2;
        }

        public double[] GaussBackwardStroke(int[] index)
        {
            int size = matrixA.GetLength(0);
            double[] vectorX = new double[vectorB.Length];

            // перемещаемся по каждой строке снизу вверх
            for (int i = size - 1; i >= 0; --i)
            {
                // 1) задаётся начальное значение элемента x
                double xI = vectorB[i];

                // 2) корректировка этого значения (на первой итерации не заходит в этот цикл)
                for (int j = i + 1; j < size; ++j)
                    xI -= vectorX[index[j]] * matrixA[i, index[j]];
                vectorX[index[i]] = Math.Round(xI, 3);
            }
            return vectorX;
        }

        public double[] GaussSolve()
        {
            int[] index = IndexOfColumns();
            DivisionRows();
            //GaussForwardStroke(index);
            double[] a = GaussBackwardStroke(index);
            return a;
        }

    }
}
