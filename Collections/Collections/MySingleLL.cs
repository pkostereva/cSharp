using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    public class MySingleLL
    {
        MyNode head;
        int size;

        public MySingleLL()
        {
            head = null;
            size = 0;
        }

        public MySingleLL(int[] array)
        {
            MyNode prev = null;

            for (int i = 0; i < array.Length; i++)
            {
                MyNode node = new MyNode();
                node.value = array[i];

                if (i == 0)
                {
                    head = node;
                }
                else
                {
                    prev.next = node;
                }
                prev = node;
            }
            size = array.Length;
        }

        /// <summary>
        /// Преобразование списка в массив
        /// </summary>
        /// <returns>Массив элементов</returns>
        public int[] ToArray()
        {
            int[] arr = new int[size];
            int count = 0;
            MyNode node = head;

            while (node != null)
            {
                arr[count] = node.value;
                node = node.next;
                count++;
            }
            return arr;
        }

        /// <summary>
        /// Добавление элемента в начало списка
        /// </summary>
        /// <param name="val">Значение элемента</param>
        public void AddFirst(int val)
        {
            MyNode node = new MyNode();
            node.value = val;

            if (head != null)
            {
                node.next = head;
            }

            head = node;
            size++;
        }

        /// <summary>
        /// Добавление массива в начало списка
        /// </summary>
        /// <param name="vals">Массив значений</param>
        public void AddFirstArr(int[] vals)
        {
            MyNode prev = null;
            MyNode newHead = null;

            for (int i = 0; i < vals.Length; i++)
            {
                MyNode node = new MyNode();
                node.value = vals[i];

                if (i == 0)
                {
                    newHead = node;
                }
                else
                {
                    prev.next = node;
                }
                prev = node;
            }

            prev.next = head;
            head = newHead;
            size += vals.Length;
        }

        /// <summary>
        /// Добавление элемента в конец списка
        /// </summary>
        /// <param name="val">Элемент</param>
        public void AddLast(int val)
        {
            MyNode prev = head;
            MyNode node = new MyNode();
            node.value = val;

            if (head == null)
            {
                head = node;
                size++;
                return;
            }

            while (prev.next != null)
            {
                prev = prev.next;
            }
            prev.next = node;
            size++;
        }

        /// <summary>
        /// Добавление массива в конец списка
        /// </summary>
        /// <param name="vals">Массив элементов</param>
        public void AddLastArr(int[] vals)
        {
            MyNode node = head;

            while (node.next != null)
            {
                node = node.next;
            }

            for (int i = 0; i < vals.Length; i++)
            {
                MyNode newNode = new MyNode();
                newNode.value = vals[i];
                node.next = newNode;
                node = newNode;
            }

            size += vals.Length;
        }

        /// <summary>
        /// Вставка по индексу в список
        /// </summary>
        /// <param name="idx">Индекс</param>
        /// <param name="val">Элемент</param>
        public void AddAt(int idx, int val)
        {
            MyNode node = new MyNode();
            node.value = val;

            MyNode prev = head;
            int count = 0;

            while (count < idx)
            {
                prev = prev.next;
                count++;
            }
            node.next = prev.next;
            prev.next = node;
            size++;
        }

        /// <summary>
        /// Вставка массива по индексу
        /// </summary>
        /// <param name="idx">Индекс</param>
        /// <param name="vals">Массив элементов</param>
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
        /// Размер списка
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return size;
        }

        /// <summary>
        /// Возврат первого элемента списка
        /// </summary>
        /// <returns></returns>
        public int GetFirst()
        {
            if (head == null)
            {
                return -1;
            }

            return head.value;
        }

        /// <summary>
        /// Возрат последнего элемента списка
        /// </summary>
        /// <returns></returns>
        public int GetLast()
        {
            MyNode node = head;
            if (head == null)
            {
                return -1;
            }
            else
            {
                while (node.next != null)
                {
                    node = node.next;
                }
            }

            return node.value;
        }

        /// <summary>
        /// Возврат элемента по индексу
        /// </summary>
        /// <param name="idx">Индекс</param>
        /// <returns></returns>
        public int Get(int idx)
        {
            if (idx < 0 || idx > size)
            {
                return -1;
            }
            MyNode prev = head;
            int count = 0;

            while (count < idx)
            {
                prev = prev.next;
                count++;
            }

            return prev.value;
        }

        /// <summary>
        /// Проверка наличия элемента в списке по значению
        /// </summary>
        /// <param name="val">Значение</param>
        /// <returns>True/False</returns>
        public bool Contains(int val)
        {
            MyNode node = head;

            if (GetSize() == 0) return false;

            while (node.next != null)
            {
                if (node.value == val)
                {
                    return true;
                }
                node = node.next;
            }

            return false;
        }

        /// <summary>
        /// Переписать значение элемента по индексу
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="val"></param>
        public void Set(int idx, int val)
        {
            if (idx > size) return;

            MyNode prev = head;
            int count = 0;

            while (count != idx)
            {
                prev = prev.next;
                count++;
            }
            prev.value = val;
        }

        /// <summary>
        /// Удаление первого элемента
        /// </summary>
        public void RemoveFirst()
        {
            head = head.next;
            size--;
        }

        /// <summary>
        /// Удаление последнего элемента
        /// </summary>
        public void RemoveLast()
        {
            if (head == null) return;

            MyNode current = head;
            MyNode node = null;

            while (current.next != null)
            {
                node = current;
                current = current.next;
            }
            node.next = null;
            size--;
        }

        /// <summary>
        /// Удаление элемента по индексу
        /// </summary>
        /// <param name="idx">индекс</param>
        public void RemoveAt(int idx)
        {
            if (head == null) return;

            MyNode current = head, nodeP = null;
            int count = 0;

            while (count != idx)
            {
                nodeP = current;
                current = current.next;
                count++;
            }

            if (nodeP != null)
            {
                nodeP.next = current.next;
            }
            else
            {
                head = head.next;
            }
            size--;
        }

        /// <summary>
        /// Получение индекса элемента с определенным значением (первый)
        /// </summary>
        /// <param name="val">Значение</param>
        /// <returns>Индекс элемента</returns>
        public int IndexOf(int val)
        {
            MyNode node = head;
            int idx = 0;

            while (node != null)
            {
                if (node.value == val)
                {
                    return idx;
                }
                node = node.next;
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

            MyNode tmp = head;
            while (tmp.next != null)
            {
                MyNode tmp1 = tmp.next;
                tmp.next = tmp.next.next;
                tmp1.next = head;
                head = tmp1;
            }
        }

        /// <summary>
        /// Удалить все элементы равные значению
        /// </summary>
        /// <param name="val">Значение</param>
        public void RemoveAll(int val)
        {
            if (head == null) return;

            MyNode current = head, nodeP = null;

            while (current != null)
            {
                if (current.value.Equals(val))
                {
                    if (nodeP != null)
                    {
                        nodeP.next = current.next;
                    }
                    else
                    {
                        head = head.next;
                    }

                    size--;
                }
                nodeP = current;
                current = current.next;
            }
        }

    }
}

