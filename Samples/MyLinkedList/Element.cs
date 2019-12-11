using System;
using System.Collections.Generic;
using System.Text;

namespace MyLinkedList
{
    class Element<T>
    {
        public T Data { get; set; }
        public Element<T> Next { get; set; }
        public Element<T> Previous { get; set; }
        public int Index { get; set; }
        public Element(T data)
        {
            Data = data;
        }
    }
}
