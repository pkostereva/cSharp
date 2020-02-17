using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    public class MyDoublyLL
    {
        MyDoublyNode head;
        MyDoublyNode tail;
        int size;

        public MyDoublyLL()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public MyDoublyLL(int[] array)
        {
            MyDoublyNode prev = null;

            for (int i = 0; i < array.Length; i++)
            {
                MyDoublyNode node = new MyDoublyNode();
                node.Value = array[i];

                if (i == 0)
                {
                    head = node;
                    tail = node;
                }
                else
                {
                    prev.Next = node;
                    tail = node;
                    tail.Previous = prev;
                }
                prev = node;
            }
            size = array.Length;
        }

        /// <summary>
        /// Преобразование списка в массив
        /// </summary>
        /// <returns></returns>
        public int[] ToArray()
        {
            MyDoublyNode current = head;
            int[] arr = new int[size];
            int count = 0;

            while (current != null)
            {
                arr[count] = current.Value;
                current = current.Next;
                count++;
            }
            return arr;
        }

        /// <summary>
        /// Вставка элемента в начало списка
        /// </summary>
        /// <param name="val"></param>
        public void AddFirst(int val)
        {
            MyDoublyNode node = new MyDoublyNode();
            node.Value = val;
            node.Next = head;
            head = node;

            if (size == 0)
                tail = head;
            else
                head.Previous = node;

            size++;
        }

        /// <summary>
        /// Вставка массива в начало списка
        /// </summary>
        /// <param name="vals"></param>
        public void AddFirstArr(int[] vals)
        {
            for (int i = vals.Length - 1; i >= 0; i--)
            {
                AddFirst(vals[i]);
            }
        }

        /// <summary>
        /// Вставка элемента в конец списка
        /// </summary>
        /// <param name="val"></param>
        public void AddLast(int val)
        {
            MyDoublyNode node = new MyDoublyNode();
            node.Value = val;

            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            size++;
        }

        /// <summary>
        /// Вставка массива в конец списка
        /// </summary>
        /// <param name="vals"></param>
        public void AddLastArr(int[] vals)
        {
            for (int i = 0; i < vals.Length; i++)
            {
                AddLast(vals[i]);
            }
        }

        /// <summary>
        /// Вставка элемента по индексу
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="val"></param>
        public void AddAt(int idx, int val)
        {
            MyDoublyNode node = new MyDoublyNode();
            node.Value = val;

            MyDoublyNode prev = head;
            int count = 0;

            while (count < idx)
            {
                prev = prev.Next;
                count++;
            }

            if (size == idx)
            {
                tail.Next = node;
                node.Previous = tail;
                tail = node;
            }

            node.Next = prev.Next;
            prev.Next = node;
            node.Previous = prev;
            prev.Next.Previous = node;
            size++;
        }

        /// <summary>
        /// Вставка массива по индексу
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="vals"></param>
        public void AddAtArr(int idx, int[] vals)
        {
            if (idx > size)
            {
                return;
            }

            for (int i = 0; i < vals.Length; i++)
            {
                AddAt(idx, vals[i]);
                idx++;
            }

        }

        /// <summary>
        /// Возвращает количество элементов в списке
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return size;
        }

        /// <summary>
        /// Возвращает первый элемент списка
        /// </summary>
        /// <returns></returns>
        public int GetFirst()
        {
            if (head == null)
            {
                return -1;
            }

            return head.Value;
        }

        /// <summary>
        /// Возвращает последний элемент списка
        /// </summary>
        /// <returns></returns>
        public int GetLast()
        {
            if (head == null)
            {
                return -1;
            }

            return tail.Value;
        }

        /// <summary>
        /// Возращает элемент списка по индексу
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public int Get(int idx)
        {
            if (idx < 0 || idx > size)
            {
                return -1;
            }

            MyDoublyNode prev = head;
            int count = 0;

            while (count < idx)
            {
                prev = prev.Next;
                count++;
            }

            return prev.Value;
        }

        /// <summary>
        /// Проверка наличия элемента в списке
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool Contains(int val)
        {
            MyDoublyNode node = head;

            if (GetSize() == 0) return false;

            while (node.Next != null)
            {
                if (node.Value == val)
                {
                    return true;
                }
                node = node.Next;
            }

            return false;
        }

        /// <summary>
        /// Перезапись элемента по индексу на значение
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="val"></param>
        public void Set(int idx, int val)
        {
            if (idx > size) return;

            MyDoublyNode prev = head;
            int count = 0;

            while (count < idx)
            {
                prev = prev.Next;
                count++;
            }
            prev.Value = val;
        }

        /// <summary>
        /// Удаление первого элемента списка
        /// </summary>
        public void RemoveFirst()
        {
            head = head.Next;
            head.Previous = null;

            if (head == null) { tail = null; }
            size--;
        }

        /// <summary>
        /// Удаление последнего элемента списка
        /// </summary>
        public void RemoveLast()
        {
            if (head == null) return;

            tail.Previous.Next = null;
            tail = tail.Previous;

            size--;
        }

        /// <summary>
        /// Удаление по индексу
        /// </summary>
        /// <param name="idx"></param>
        public void RemoveAt(int idx)
        {
            if (head == null) return;

            MyDoublyNode current = head, prev = null;
            int count = 0;

            while (count < idx)
            {
                prev = current;
                current = current.Next;
                count++;
            }

            if (prev == null)
            {
                head = head.Next;
                head.Previous = null;
            }
            else
            {
                if (current.Next == null)
                {
                    tail = prev.Previous;
                    prev.Next = null;
                }
                else
                {
                    prev.Next = current.Next;
                    current.Next.Previous = prev;
                }
            }
            size--;
        }

        /// <summary>
        /// Индекс элемента равного val (первый)
        /// </summary>
        /// <param name="val"></param>
        public int IndexOf(int val)
        {
            MyDoublyNode node = head;
            int idx = 0;

            while (node != null)
            {
                if (node.Value == val)
                {
                    return idx;
                }
                node = node.Next;
                idx++;
            }

            return -1;
        }

        /// <summary>
        /// Реверс списка
        /// </summary>
        public void Reverse()
        {
            if (head == null) return;

            MyDoublyNode tmp = head;
            while (tmp.Next != null)
            {
                MyDoublyNode tmp1 = tmp.Next;
                tmp.Next = tmp.Next.Next;

                if (tmp.Previous == null)
                {
                    tmp.Previous = tmp1;
                }

                tmp1.Next = head;
                tmp1.Previous = null;
                head = tmp1;

                if (tmp.Next != null)
                {
                    tmp.Next.Previous = tmp;
                }
            }
        }

        /// <summary>
        /// Удаление всех элементов со значением val
        /// </summary>
        /// <param name="val"></param>
        public void RemoveAll(int val)
        {
            if (head == null) return;

            MyDoublyNode current = head, prev = null;

            while (current != null)
            {
                if (current.Value.Equals(val))
                {
                    if (prev == null)
                    {
                        head = head.Next;
                        head.Previous = null;
                    }
                    else
                    {
                        if (current.Next == null)
                        {
                            tail = prev.Previous;
                            prev.Next = null;
                        }
                        else
                        {
                            prev.Next = current.Next;
                            current.Next.Previous = prev;
                        }
                    }

                    size--;
                }
                prev = current;
                current = current.Next;
            }
        }
    }
}

