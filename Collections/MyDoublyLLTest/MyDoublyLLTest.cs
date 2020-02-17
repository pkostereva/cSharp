using NUnit.Framework;
using Collections;

namespace MyDoublyLLTest
{
    [TestFixture]
    public class MyDoublyLLTests
    {
        [TestCase(0, new int[] { 14, 56, 43 }, ExpectedResult = new int[] { 0, 14, 56, 43 })]
        [TestCase(56, new int[] { }, ExpectedResult = new int[] { 56 })]
        public int[] AddFirstTest(int val, int[] arr)
        {
            MyDoublyLL dLL = new MyDoublyLL(arr);
            dLL.AddFirst(val);
            return dLL.ToArray();
        }

        [TestCase(new int[] { 14, 56, 43 }, new int[] { 1, 2, 3 }, ExpectedResult = new int[] { 14, 56, 43, 1, 2, 3 })]
        [TestCase(new int[] { 14, 56, 43 }, new int[] { }, ExpectedResult = new int[] { 14, 56, 43 })]
        public int[] AddFirstArrTest(int[] val, int[] arr)
        {
            MyDoublyLL dLL = new MyDoublyLL(arr);
            dLL.AddFirstArr(val);
            return dLL.ToArray();
        }

        [TestCase(5, new int[] { 14, 56, 43 }, ExpectedResult = new int[] { 14, 56, 43, 5 })]
        [TestCase(71, new int[] { }, ExpectedResult = new int[] { 71 })]
        public int[] AddLastTest(int val, int[] arr)
        {
            MyDoublyLL dLL = new MyDoublyLL(arr);
            dLL.AddLast(val);
            return dLL.ToArray();
        }

        [TestCase(new int[] { 14, 56, 43 }, new int[] { 1, 2, 3 }, ExpectedResult = new int[] { 1, 2, 3, 14, 56, 43 })]
        [TestCase(new int[] { }, new int[] { 1 }, ExpectedResult = new int[] { 1 })]
        public int[] AddLastArrTest(int[] val, int[] arr)
        {
            MyDoublyLL dLL = new MyDoublyLL(arr);
            dLL.AddLastArr(val);
            return dLL.ToArray();
        }

        [TestCase(2, 5, new int[] { 14, 56, 43 }, ExpectedResult = new int[] { 14, 56, 43, 5 })]
        [TestCase(0, 5, new int[] { 4, 6, 7, 5 }, ExpectedResult = new int[] { 4, 5, 6, 7, 5 })]
        [TestCase(1, 5, new int[] { 1, 2, 3 }, ExpectedResult = new int[] { 1, 2, 5, 3 })]
        public int[] AddAtTest(int idx, int val, int[] arr)
        {
            MyDoublyLL dLL = new MyDoublyLL(arr);
            dLL.AddAt(idx, val);
            return dLL.ToArray();
        }

        [TestCase(2, new int[] { 4, 5 }, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(0, new int[] { 4, 5 }, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 1, 4, 5, 2, 3, 6 })]
        [TestCase(3, new int[] { 4, 5 }, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 1, 2, 3, 6, 4, 5 })]
        [TestCase(10, new int[] { 4, 5 }, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 1, 2, 3, 6 })]
        public int[] AddAtArrTest(int idx, int[] val, int[] arr)
        {
            MyDoublyLL dLL = new MyDoublyLL(arr);
            dLL.AddAtArr(idx, val);
            return dLL.ToArray();
        }

        [TestCase(new int[] { 14, 22, 34 }, ExpectedResult = 3)]
        [TestCase(new int[] { 54 }, ExpectedResult = 1)]
        [TestCase(new int[] { }, ExpectedResult = 0)]
        public int GetSizeTest(int[] arr)
        {
            MyDoublyLL dLL = new MyDoublyLL(arr);
            return dLL.GetSize();
        }

        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = 1)]
        [TestCase(new int[] { 5 }, ExpectedResult = 5)]
        [TestCase(new int[] { }, ExpectedResult = -1)]
        public int GetFirstTest(int[] arr)
        {
            MyDoublyLL dLL = new MyDoublyLL(arr);
            return dLL.GetFirst();
        }

        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = 3)]
        [TestCase(new int[] { 55, 67, 959 }, ExpectedResult = 959)]
        public int GetLastTest(int[] arr)
        {
            MyDoublyLL dLL = new MyDoublyLL(arr);
            return dLL.GetLast();
        }

        [TestCase(2, new int[] { 1, 2, 3, 6 }, ExpectedResult = 3)]
        [TestCase(1, new int[] { 1, 2, 3, 6 }, ExpectedResult = 2)]
        [TestCase(10, new int[] { 1, 2, 3, 6 }, ExpectedResult = -1)]
        public int GetTest(int idx, int[] arr)
        {
            MyDoublyLL dLL = new MyDoublyLL(arr);
            return dLL.Get(idx);
        }

        [TestCase(10, new int[] { 1, 2, 3 }, ExpectedResult = false)]
        [TestCase(15, new int[] { 5, 15, 15, 3 }, ExpectedResult = true)]
        [TestCase(1, new int[] { }, ExpectedResult = false)]
        public bool ContainsTest(int val, int[] arr)
        {
            MyDoublyLL dLL = new MyDoublyLL(arr);
            return dLL.Contains(val);
        }

        [TestCase(2, 5, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 1, 2, 5, 6 })]
        [TestCase(3, 5, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 1, 2, 3, 5 })]
        [TestCase(0, 5, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 5, 2, 3, 6 })]
        [TestCase(10, 5, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 1, 2, 3, 6 })]
        public int[] SetTest(int idx, int val, int[] arr)
        {
            MyDoublyLL dLL = new MyDoublyLL(arr);
            dLL.Set(idx, val);
            return dLL.ToArray();
        }

        [TestCase(new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 2, 3, 6 })]
        [TestCase(new int[] { 1, 2, 3, 6, 7 }, ExpectedResult = new int[] { 2, 3, 6, 7 })]
        public int[] RemoveFirstTest(int[] arr)
        {
            MyDoublyLL dLL = new MyDoublyLL(arr);
            dLL.RemoveFirst();
            return dLL.ToArray();
        }

        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = new int[] { 1, 2 })]
        [TestCase(new int[] { }, ExpectedResult = new int[] { })]
        public int[] RemoveLastTest(int[] arr)
        {
            MyDoublyLL dLL = new MyDoublyLL(arr);
            dLL.RemoveLast();
            return dLL.ToArray();
        }

        [TestCase(2, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 1, 2, 6 })]
        [TestCase(0, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 2, 3, 6 })]
        [TestCase(3, new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 1, 2, 3 })]
        public int[] RemoveAtTest(int idx, int[] arr)
        {
            MyDoublyLL dLL = new MyDoublyLL(arr);
            dLL.RemoveAt(idx);
            return dLL.ToArray();
        }

        [TestCase(6, new int[] { 1, 2, 3, 6 }, ExpectedResult = 3)]
        [TestCase(3, new int[] { 1, 2, 3, 6 }, ExpectedResult = 2)]
        [TestCase(2, new int[] { 1, 2, 3, 6 }, ExpectedResult = 1)]
        [TestCase(1, new int[] { 1, 2, 3, 6 }, ExpectedResult = 0)]
        [TestCase(10, new int[] { 1, 2, 3, 6 }, ExpectedResult = -1)]
        public int IndexOfTest(int val, int[] arr)
        {
            MyDoublyLL dLL = new MyDoublyLL(arr);
            return dLL.IndexOf(val);
        }

        [TestCase(new int[] { 1, 2, 3, 6 }, ExpectedResult = new int[] { 6, 3, 2, 1 })]
        [TestCase(new int[] { 7, 8, 9, 10, 11 }, ExpectedResult = new int[] { 11, 10, 9, 8, 7 })]
        public int[] ReverseTest(int[] arr)
        {
            MyDoublyLL dLL = new MyDoublyLL(arr);
            dLL.Reverse();
            return dLL.ToArray();
        }

        [TestCase(5, new int[] { 6, 5, 6, 5 }, ExpectedResult = new int[] { 6, 6 })]
        [TestCase(7, new int[] { 7, 8, 9, 10, 11 }, ExpectedResult = new int[] { 8, 9, 10, 11 })]
        [TestCase(11, new int[] { 11, 8, 11, 10, 11 }, ExpectedResult = new int[] { 8, 10 })]
        [TestCase(11, new int[] { }, ExpectedResult = new int[] { })]
        public int[] RemoveAllTest(int val, int[] arr)
        {
            MyDoublyLL dLL = new MyDoublyLL(arr);
            dLL.RemoveAll(val);
            return dLL.ToArray();
        }
    }
}