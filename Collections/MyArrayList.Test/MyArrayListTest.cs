using Collections;
using NUnit.Framework;

namespace Homework.Tests
{
    [TestFixture]
    class MyArrayListTest
    {
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(8, ExpectedResult = -1)]
        [TestCase(0, ExpectedResult = 0)]
        public int IndexOfTest(int val)
        {
            MyArrayList myAL = new MyArrayList(new int[] { 0, 1, 2, 5, 6, 0 });
            return myAL.IndexOf(val);
        }

        [TestCase(0, ExpectedResult = true)]
        [TestCase(-1, ExpectedResult = false)]
        [TestCase(6, ExpectedResult = true)]
        public bool ContainsTest(int val)
        {
            MyArrayList myAL = new MyArrayList(new int[] { 0, 1, 2, 5, 6, 0 });
            return myAL.Contains(val);
        }

        [TestCase(0, ExpectedResult = new int[] { 0, 2 })]
        [TestCase(5, ExpectedResult = new int[] { 3, 7, 8 })]
        [TestCase(-1, ExpectedResult = new int[] { })]
        public int[] SearchTest(int val)
        {
            MyArrayList myAL = new MyArrayList(new int[] { 0, 1, 0, 5, 6, 7, 8, 5, 5 });
            return myAL.Search(val);
        }

        [TestCase(ExpectedResult = 9)]
        public int SizeTest()
        {
            MyArrayList myAL = new MyArrayList(new int[] { 0, 1, 0, 5, 6, 7, 8, 5, 5 });
            return myAL.Size();
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 6 }, 6)]
        [TestCase(new int[] { }, new int[] { 1 }, 1)]
        public void AddTest(int[] array, int[] expected, int val)
        {
            MyArrayList myAL = new MyArrayList(array);
            myAL.Add(val);
            int[] actual = myAL.ToArray();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 4, 65, 765 }, 2, new int[] { 3, 4, 65 }, new int[] { 3, 4, 3, 4, 65 })]
        [TestCase(new int[] { 3, 4, 65, 765, 8 }, 0, new int[] { 34, 67, 98 }, new int[] { 34, 67, 98, 765, 8 })]
        [TestCase(new int[] { 3, 4, 65, 6, 3, 2 }, 3, new int[] { 3, 4, 65, 6, 3, 2 }, new int[] { 3, 4, 65, 3, 4, 65, 6, 3, 2 })]
        public void AddRangeTest(int[] arr, int index, int[] val, int[] expected)
        {
            MyArrayList la = new MyArrayList(arr);
            la.AddRange(val, index);

            Assert.AreEqual(expected, la.GetValues());
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 6, 4 }, 2, 6)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 6, 2, 3, 4 }, 0, 6)]
        public void SetTest(int[] array, int[] expected, int idx, int val)
        {
            MyArrayList myAL = new MyArrayList(array);
            myAL.Set(idx, val);
            int[] actual = myAL.ToArray();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 4 }, 2)]
        public void RemoveByIndTest(int[] array, int[] expected, int idx)
        {
            MyArrayList myAL = new MyArrayList(array);
            myAL.RemoveByInd(idx);
            int[] actual = myAL.ToArray();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 3, 4 }, 2)]
        public void RemoveByValTest(int[] array, int[] expected, int val)
        {
            MyArrayList myAL = new MyArrayList(array);
            myAL.RemoveByVal(val);
            int[] actual = myAL.ToArray();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 1, 4 }, new int[] { 2, 4 }, 1)]
        [TestCase(new int[] { 1, 2, 1, 4 }, new int[] { 1, 2, 1, 4 }, 5)]
        public void RemoveAllTest(int[] array, int[] expected, int val)
        {
            MyArrayList myAL = new MyArrayList(array);
            myAL.RemoveAll(val);
            int[] actual = myAL.ToArray();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 9, 10)]
        public void GetTest(int[] val, int index, int expected)
        {
            MyArrayList myAL = new MyArrayList(val);

            int actual = myAL.Get(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 4, 65 }, new int[] { 3, 4, 65 })]
        [TestCase(new int[] { 3, 4, 65, 6, 3, 2 }, new int[] { 3, 4, 65, 6, 3, 2 })]
        [TestCase(new int[] { 3, 4, 65, 1, 1, 1, 1, 1, 1, 1, 1 }, new int[] { 3, 4, 65, 1, 1, 1, 1, 1, 1, 1, 1 })]
        public void GetValuesTest(int[] val, int[] expected)
        {
            MyArrayList myAL = new MyArrayList(val);
            myAL.GetValues();

            Assert.AreEqual(expected, myAL.GetValues());
        }

        [TestCase(3, new int[] { 3 })]
        [TestCase(876, new int[] { 876 })]
        public void AddTest(int val, int[] expected)
        {
            MyArrayList myAL = new MyArrayList();
            myAL.Add(val);

            Assert.AreEqual(expected, myAL.GetValues());
        }

        [TestCase(new int[] { 1, 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 })]
        public void ArrayExpansionTest(int[] arr, int[] expected)
        {
            MyArrayList la = new MyArrayList(arr);

            int[] actual = la.ArrayExpansion();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 }, new int[] { 1, 1, 1, 1, 1, 1 })]
        public void ArrayReductionTest(int[] arr, int[] expected)
        {
            MyArrayList myAL = new MyArrayList(arr);

            int[] actual = myAL.ArrayReduction();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 1, new int[] { 4, 5, 6, 7}, new int[] {4, 3, 5, 6, 7 })]
        public void AddByIndexTest(int val, int idx, int[] arr, int[] expected)
        {
            MyArrayList myAL = new MyArrayList(arr);

            myAL.AddByIndex(val, idx);

            Assert.AreEqual(expected, myAL.GetValues());
        }

        [TestCase(new int[] { 3, 4, 65, 765 }, new int[] { 3, 4, 65 }, new int[] {3, 4, 65, 765, 3, 4, 65})]
        [TestCase(new int[] { 3, 4, 65, 765, 8 }, new int[] { 34, 67, 98 }, new int[] { 3, 4, 65, 765, 8, 34, 67, 98})]
        public void AddAllTest(int[] arr, int[] val, int[] expected)
        {
            MyArrayList myAL = new MyArrayList(arr);
            myAL.AddAll(val);

            Assert.AreEqual(expected, myAL.GetValues());
        }

    }

}
