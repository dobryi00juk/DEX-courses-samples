using System;

namespace MyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> list = new LinkedList<string>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i.ToString());
            }

            list.Delete("4");
            list.Add("1");
            list.Add("5");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------------------------");
            var a = list.DeepCopy();

            foreach (var item in a.BackEnumerator())
            {
                Console.WriteLine(item);
            }
        }
    }
}
