using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    public class MyArrayList
    {
        private int[] array;
        private int realLength;

        public MyArrayList()
        {
            array = new int[10];
            realLength = 0;
        }

        public MyArrayList(int[] array)
        {
            this.array = array;
            realLength = array.Length;
        }

        public int[] ArrayExpansion()
        {
            int[] array2 = new int[(realLength * 3) / 2 + 1];
            for (int i = 0; i < realLength; i++)
            {
                array2[i] = array[i];
            }
            return array2;
        }
        public int[] ArrayReduction()
        {
            int arrayNewLength = Convert.ToInt32((array.Length - 1) * 2 / 3);
            int[] smallArray = new int[arrayNewLength];
            for (int i = 0; i < arrayNewLength; i++)
            {
                smallArray[i] = array[i];
            }
            return smallArray;
        }

        public int[] ToArray()
        {
            int[] temp = new int[realLength];
            for (int i = 0; i < realLength; i++)
            {
                temp[i] = array[i];
            }
            return temp;
        }

        public bool Contains(int val)
        {
            if (IndexOf(val) == -1)
            { return false; }
            else { return true; }
        }

        public void Add(int val)
        {
            array = ArrayExpansion();
            array[realLength] = val;
            realLength++;
        }

        public void AddByIndex(int val, int idx)
        {
            if (realLength == array.Length)
            {
                array = ArrayExpansion();
            }
            for (int i = realLength + 1; i > 0; i--)
            {
                if (i >= idx + 1)
                {
                    array[i] = array[i - 1];
                }
                else if (i == idx)
                {
                    array[i] = val;
                }
            }
            realLength++;
        }

        public void AddAll(int[] val)
        {
            if (realLength + val.Length >= array.Length)
            {
                array = ArrayExpansion();
            }
            for (int i = 0; i < val.Length; i++)
            {
                array[realLength + i] = val[i];
            }
            realLength += val.Length;
        }

        public void AddRange(int[] val, int idx)
        {
            int count = 0;
            for (int i = 0; i < val.Length; i++)
            {
                if (realLength - idx + val.Length >= array.Length)
                {
                    array = ArrayExpansion();
                }
                array[idx + count] = val[i];
                count++;
            }
            if (realLength < idx + val.Length)
            {
                realLength = idx + val.Length;
            }
        }

        public int Size()
        {
            return realLength;
        }

        public void Set(int idx, int val)
        {
            array[idx] = val;
        }

        public int Get(int idx)
        {
            if (idx <= realLength)
            {
                return array[idx];
            }
            return -1;
        }

        public void RemoveByInd(int idx)
        {
            if (idx < realLength)
            {
                for (int i = idx; i < array.Length - 1; i++)
                    array[i] = array[i + 1];
                array[realLength - 1] = 0;
                realLength--;
            }
        }

        public void RemoveByVal(int val)
        {
            if (Contains(val))
            {
                RemoveByInd(IndexOf(val));
            }
        }

        public void RemoveAll(int val)
        {
            if (!Contains(val))
            {
                return;
            }
            int[] newArr = new int[array.Length];
            int count = 0;
            for (int i = 0, j = 0; i < realLength; i++)
            {
                if (array[i] != val)
                {
                    newArr[j] = array[i];
                    j++;
                    count++;
                }
            }
            realLength -= count;
            array = newArr;

            if (array.Length / 2 > realLength)
            {
                array = ArrayExpansion();
            }
            return;
        }

        public int[] Search(int val)
        {
            int counter = 0;
            if (Contains(val))
            {
                for (int i = 0; i < realLength; i++)
                {
                    if (array[i] == val)
                    {
                        counter++;
                    }
                }
            }
            int j = 0;
            int[] arr = new int[counter];
            for (int i = 0; i < realLength; i++)
            {
                if (array[i] == val)
                {
                    arr[j] = i;
                    j++;
                }
            }
            return arr;
        }

        public int IndexOf(int val)
        {
            for (int i = 0; i < realLength; i++)
            {
                if (val == array[i])
                {
                    return i;
                }
            }
            return -1;
        }

        // возвращает эл-ты внутри массива array от 0 до reallength, может вернуть пустой массив
        public int[] GetValues()
        {
            int[] newArr = new int[realLength];
            for (int i = 0; i < realLength; i++)
            {
                newArr[i] = array[i];
            }
            return newArr;
        }
    }
}
