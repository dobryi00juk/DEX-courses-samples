using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyLinkedList
{
    class LinkedList<T> : IEnumerable<T>
    {
        private int _count;
        public int Count => _count;
        private Element<T> _head;
        private Element<T> _tail;

        public void Add(T item)
        {
            if(item == null)
            {
                Console.WriteLine("Error!");
                return;
            }

            var element = new Element<T>(item);
            var current = _head;

            try
            {
                if (_head == null)
                    _head = element;
                else
                {
                    while (current != null)
                    {
                        if (current.Data.Equals(item))
                        {
                            throw new Exception();
                        }

                        current = current.Next;
                    }

                    _tail.Next = element;
                    element.Previous = _tail;
                }

                _tail = element;
                element.Index = _count++;
            }
            catch (Exception)
            {
                Console.WriteLine($"Элемент {current.Data} уже сущеcтвует!");
            }
        }

        public bool Delete(T item)
        {
            if(item == null) return false;

            var current = _head;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    break;
                }

                current = current.Next;
            }

            if (current != null)
            {
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    _tail = current.Previous;
                }

                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    _head = current.Next;
                }

                _count--;
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Element<T> current = _head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();

        public IEnumerable<T> BackEnumerator()
        {
            var current = _tail;

            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }

        public LinkedList<T> DeepCopy()
        {
            var deepCopy = new LinkedList<T>()
            {
                _tail = this._tail,
                _head = this._head,
                _count = this._count
            };

            return deepCopy;
        }
    }
}
