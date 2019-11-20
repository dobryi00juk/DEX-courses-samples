using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using Console = System.Console;

namespace MyEventProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = 10;
            var queue = new Queue<int>();
            queue.TrimExcess();

            Handler += Display;

            for (int i = 0; i < 15; i++)
            {
                if (queue.Count >= size)
                {
                    Handler?.Invoke("Queue is full");
                    break;
                }
                else
                {
                    queue.Enqueue(i);
                }
            }

            for (int i = 0; i < 15; i++)
            {
                if (Equals(queue.Count,0))
                {
                    Handler?.Invoke("Queue is empty!");
                    break;
                }
                else
                {
                    queue.Dequeue();
                }
            }

            Handler -= Display;

            var digit = new Digit(30);
            digit.handler += Display;

            for (int i = 0; i < 100; i += 10)
            {
                digit.Add(i);
            }

            digit.Add(5000);
            digit.handler -= Display;

            var prop = new PropChange();

            void PropertyHandler(object s, PropertyChangedEventArgs e)
            {
                Console.WriteLine($"Property {e.PropertyName} is changed!");
            }

            prop.PropertyChanged += PropertyHandler;
            prop.Prop1 = 111;
            prop.Prop1 = 222;
            prop.Prop2 = "123";
            prop.PropertyChanged -= PropertyHandler;
        }

        public delegate void Counter(string message);
        public static event Counter Handler;

        private static void Display(string message)
        {
            Console.WriteLine(message);
        }
    }

    class Digit
    {
        private List<int> List { get; set; }
        public int Percent { get; set; }

        public delegate void DigitHandler(string message);

        public event DigitHandler handler;
        public Digit(int percent)
        {
            Percent = percent;
            List = new List<int>();
        }

        public void Add(int item)
        {
            if (List.Count == 0)
            {
                List.Add(item);
                return;
            }

            if (item / 100 * Percent > List.Average()) 
            {
                handler?.Invoke("More than 30 %");
                return;
            }
            else
            {
                List.Add(item);
            }
        }

    }
}