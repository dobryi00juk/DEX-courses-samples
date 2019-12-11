using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyEventProject
{
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
