using NUnit.Framework;
using Collections;

namespace MySingleLLTest
{
    [TestFixture]
    public class MySingleLLTests
    {
        [TestCase(8, new int[] { 1, 2, 3 }, ExpectedResult = new int[] { 8, 1, 2, 3 })]
        [TestCase(5, new int[] { }, ExpectedResult = new int[] { 5 })]
        public int[] AddFirstTest(int val, int[] arr)
        {
            MySingleLL list = new MySingleLL(arr);
            list.AddFirst(val);

            return list.ToArray();
        }

        [TestCase(new int[] { 8, 8, 8 }, new int[] { 1, 2, 3 }, ExpectedResult = new int[] { 8, 8, 8, 1, 2, 3 })]
        [TestCase(new int[] { 8, 8, 8 }, new int[] { }, ExpectedResult = new int[] { 8, 8, 8 })]
        public int[] AddFirstArrTest(int[] val, int[] arr)
        {
            MySingleLL list = new MySingleLL(arr);
            list.AddFirstArr(val);

            return list.ToArray();
        }

        [TestCase(5, new int[] { 1, 2, 3 }, ExpectedResult = new int[] { 1, 2, 3, 5 })]
        [TestCase(5, new int[] { }, ExpectedResult = new int[] { 5 })]
        public int[] AddLastTest(int val, int[] arr)
        {
            MySingleLL list = new MySingleLL(arr);
            list.AddLast(val);

            return list.ToArray();
        }

        [TestCase(new int[] { 8, 7, 5 }, new int[] { 1, 2, 3 }, ExpectedResult = new int[] { 1, 2, 3, 8, 7, 5 })]
        [TestCase(new int[] { 8, 8, 8 }, new int[] { 1, 2, 3 }, ExpectedResult = new int[] { 1, 2, 3, 8, 8, 8 })]
        [TestCase(new int[] { 4, 4, 4 }, new int[] { 1 }, ExpectedResult = new int[] { 1, 4, 4, 4 })]
        public int[] AddLastArrTest(int[] val, int[] arr)
        {
            MySingleLL list = new MySingleLL(arr);
            list.AddLastArr(val);

            return list.ToArray();
        }

        [TestCase(2, 5, new int[] { 1, 2, 3 }, ExpectedResult = new int[] { 1, 2, 3, 5 })]
        [TestCase(0, 5, new int[] { 4, 6, 7, 5 }, ExpectedResult = new int[] { 4, 5, 6, 7, 5 })]
        [TestCase(1, 5, new int[] { 1, 2, 3 }, ExpectedResult = new int[] { 1, 2, 5, 3 })]
        public int[] AddAtTest(int idx, int val, int[] arr)
        {
            MySingleLL list = new MySingleLL(arr);
            list.AddAt(idx, val);

            return list.ToArray();
        }

        [TestCase(2, new int[] { 4, 5 }, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(0, new int[] { 4, 5 }, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 1, 4, 5, 2, 3, 6 })]
        [TestCase(3, new int[] { 4, 5 }, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 1, 2, 3, 6, 4, 5 })]
        [TestCase(10, new int[] { 4, 5 }, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 1, 2, 3, 6 })]
        public int[] AddAtArrTest(int idx, int[] val, int[] arr)
        {
            MySingleLL list = new MySingleLL(arr);
            list.AddAtArr(idx, val);

            return list.ToArray();
        }

        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = 3)]
        [TestCase(new int[] { 5 }, ExpectedResult = 1)]
        [TestCase(new int[] { }, ExpectedResult = 0)]
        public int GetSizeTest(int[] arr)
        {
            MySingleLL list = new MySingleLL(arr);

            return list.GetSize();
        }

        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = 1)]
        [TestCase(new int[] { 5 }, ExpectedResult = 5)]
        [TestCase(new int[] { }, ExpectedResult = -1)]
        public int GetFirstTest(int[] arr)
        {
            MySingleLL list = new MySingleLL(arr);

            return list.GetFirst();
        }

        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = 3)]
        [TestCase(new int[] { 5 }, ExpectedResult = 5)]
        [TestCase(new int[] { }, ExpectedResult = -1)]
        public int GetLastTest(int[] arr)
        {
            MySingleLL list = new MySingleLL(arr);

            return list.GetLast();
        }

        [TestCase(2, new int[] { 1, 2, 3, 6 }, ExpectedResult = 3)]
        [TestCase(1, new int[] { 1, 2, 3, 6 }, ExpectedResult = 2)]
        [TestCase(10, new int[] { 1, 2, 3, 6 }, ExpectedResult = -1)]
        public int GetTest(int idx, int[] arr)
        {
            MySingleLL list = new MySingleLL(arr);

            return list.Get(idx);
        }

        [TestCase(10, new int[] { 1, 2, 3 }, ExpectedResult = false)]
        [TestCase(15, new int[] { 5, 15, 15, 3 }, ExpectedResult = true)]
        [TestCase(1, new int[] { }, ExpectedResult = false)]
        public bool ContainsTest(int val, int[] arr)
        {
            MySingleLL list = new MySingleLL(arr);

            return list.Contains(val);
        }

        [TestCase(2, 5, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 1, 2, 5, 6 })]
        [TestCase(3, 5, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 1, 2, 3, 5 })]
        [TestCase(0, 5, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 5, 2, 3, 6 })]
        [TestCase(10, 5, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 1, 2, 3, 6 })]
        public int[] SetTest(int idx, int val, int[] arr)
        {
            MySingleLL list = new MySingleLL(arr);
            list.Set(idx, val);

            return list.ToArray();
        }

        [TestCase(new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 2, 3, 6 })]
        [TestCase(new int[] { 1, 2, 3, 6, 7 }, ExpectedResult = new int[] { 2, 3, 6, 7 })]
        public int[] RemoveFirstTest(int[] arr)
        {
            MySingleLL list = new MySingleLL(arr);
            list.RemoveFirst();

            return list.ToArray();
        }

        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = new int[] { 1, 2 })]
        [TestCase(new int[] { }, ExpectedResult = new int[] { })]
        public int[] RemoveLastTest(int[] arr)
        {
            MySingleLL list = new MySingleLL(arr);
            list.RemoveLast();

            return list.ToArray();
        }

        [TestCase(2, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 1, 2, 6 })]
        [TestCase(1, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 1, 3, 6 })]
        [TestCase(0, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 2, 3, 6 })]
        [TestCase(3, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 1, 2, 3 })]
        public int[] RemoveAtTest(int idx, int[] arr)
        {
            MySingleLL list = new MySingleLL(arr);
            list.RemoveAt(idx);

            return list.ToArray();
        }

        [TestCase(6, new int[] { 1, 2, 3, 6 }, ExpectedResult = 3)]
        [TestCase(3, new int[] { 1, 2, 3, 6 }, ExpectedResult = 2)]
        [TestCase(2, new int[] { 1, 2, 3, 6 }, ExpectedResult = 1)]
        [TestCase(1, new int[] { 1, 2, 3, 6 }, ExpectedResult = 0)]
        [TestCase(10, new int[] { 1, 2, 3, 6 }, ExpectedResult = -1)]
        public int IndexOfTest(int val, int[] arr)
        {
            MySingleLL list = new MySingleLL(arr);

            return list.IndexOf(val);
        }

        [TestCase(new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 6, 3, 2, 1 })]
        [TestCase(new int[] { 7, 8, 9, 10, 11 }, ExpectedResult = new int[] { 11, 10, 9, 8, 7 })]
        public int[] ReverseTest(int[] arr)
        {
            MySingleLL list = new MySingleLL(arr);
            list.Reverse();

            return list.ToArray();
        }

        [TestCase(5, new int[] { 6, 5, 6, 5 }, ExpectedResult = new int[] { 6, 6 })]
        [TestCase(7, new int[] { 7, 8, 9, 10, 11 }, ExpectedResult = new int[] { 8, 9, 10, 11 })]
        [TestCase(11, new int[] { 11, 8, 11, 10, 11 }, ExpectedResult = new int[] { 8, 10 })]
        [TestCase(11, new int[] { }, ExpectedResult = new int[] { })]
        public int[] RemoveAllTest(int val, int[] arr)
        {
            MySingleLL list = new MySingleLL(arr);
            list.RemoveAll(val);

            return list.ToArray();
        }
    }
}