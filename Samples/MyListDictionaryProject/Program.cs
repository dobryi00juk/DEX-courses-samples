using System;
using System.Collections.Generic;

namespace MyListDictionaryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Person ivan = new Person(
                "Ivan", 
                "Ivanovich", 
                "Ivanov", 
                "Tiraspol", 
                123456789, 
                DateTime.Now.Date.AddYears(-30).ToShortDateString());

            Person petr = new Person(
                "Petr",
                "Petrovich",
                "Petrov",
                "Paris",
                789456123,
                DateTime.Now.Date.AddYears(-420).ToShortDateString());
            
            Person tom = new Person(
                "Tom",
                "",
                "Hanks",
                "California",
                987654321,
                DateTime.Now.Date.AddYears(-62).ToShortDateString());

            Dictionary<Person, string> persons = new Dictionary<Person, string>();

            persons.TryAdd(tom, "Apple");
            persons.TryAdd(petr, "Google");
            persons.TryAdd(ivan, "DEX");

            foreach (var item in persons)
            {
                Console.WriteLine(item.Key.FirstName + " " + item.Key.BirthDate);
            }

            Console.WriteLine("--------------");

            while (true)
            {
                Console.Write("Enter first name: ");
                var firstname = Console.ReadLine().ToLower();

                Console.Write("Enter middle name: ");
                var middlename = Console.ReadLine().ToLower();

                Console.Write("Enter last name: ");
                var lastname = Console.ReadLine().ToLower(); 

                Console.Write("Enter passport number: ");
                var passportnumber = Console.ReadLine();

                Console.Write("Enter birth date (dd/m/yy): ");
                var birthdate = Console.ReadLine();

                Console.Write("Enter birth place: ");
                var birthplace = Console.ReadLine().ToLower();

                foreach (var item in persons)
                {
                    if (firstname == item.Key.FirstName.ToLower() & 
                        middlename == item.Key.MiddleName.ToLower() & 
                        lastname == item.Key.LastName.ToLower() & 
                        passportnumber == item.Key.PassportNumber.ToString() &
                        birthdate == item.Key.BirthDate &
                        birthplace == item.Key.BirthPlace.ToLower())
                    {
                        Console.WriteLine();
                        Console.WriteLine("Work place: " + item.Value);
                    }
                }

                Console.WriteLine("--------------------");
            }
        }
    }
    
}
