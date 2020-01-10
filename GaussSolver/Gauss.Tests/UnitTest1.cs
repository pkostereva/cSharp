using NUnit.Framework;

namespace GaussSolver
{
    [TestFixture]
    public class GaussTests
    {
        [SetUp]
        public void Setup()
        {
        }

        public double[,] GetMatrixByName(string matrixName)
        {
            switch (matrixName)
            {
                case "matrix1":
                    return new double[,] { { 1, 2, -1 }, { 0, 1, -1 }, { 0, 0, 1 } };
                case "matrix2":
                    return new double[,] { { 1, 1, -1 }, { 0, 1, 0 }, { 0, 0, 1 } };
                case "matrix3":
                    return new double[,] { { 1, 3, 2, 1 }, { 0, 1, 0, 1 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            }
            return new double[,] { };
        }

        [TestCase("matrix1", new double[] { 9, 1, 4 }, new int[] { 0, 1, 2 }, new double[] { 3, 5, 4 })]
        [TestCase("matrix2", new double[] { 1, 3, 1 }, new int[] { 0, 1, 2 }, new double[] { -1, 3, 1 })]
        [TestCase("matrix3", new double[] { 11, 2, 2, 0 }, new int[] { 0, 1, 2, 3 }, new double[] { 1, 2, 2, 0 })]
        public void GaussBackwardStrokeTest(string arrName, double[] vec, int[] index, double[] expected)
        {
            Gauss gauss = new Gauss();
            double[,] arr = GetMatrixByName(arrName);
            gauss.AddMatrix(arr);
            gauss.AddVector(vec);
            double[] actual = gauss.GaussBackwardStroke(index);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase("matrix1", new double[] { 9, 1, 4 }, new double[] { 3, 5, 4 })]
        [TestCase("matrix2", new double[] { 1, 3, 1 }, new double[] { -1, 3, 1 })]
        [TestCase("matrix3", new double[] { 11, 2, 2, 0 }, new double[] { 1, 2, 2, 0 })]
        public void GaussSolveTest(string arrName, double[] vec, double[] expected)
        {
            Gauss gauss = new Gauss();
            double[,] arr = GetMatrixByName(arrName);
            gauss.AddMatrix(arr);
            gauss.AddVector(vec);
            double[] actual = gauss.GaussSolve();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}