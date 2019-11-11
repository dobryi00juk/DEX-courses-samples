using System;
using System.ComponentModel;

namespace INotifyPropertyChange
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class MyClass 
    {
        public string Count { get; set; }

        public MyClass(string count)
        {
            Count = count;
        }

        public event EventHandler CountChanged;

    }
}
