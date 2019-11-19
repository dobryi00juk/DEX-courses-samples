using System;

namespace MyEqualsGetHashCodeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var fio = "Ivanov Ivan Ivanovich";
            var birth = new DateTime().Date;
            var person = new Person("");
        }
    }

    class Person
    {
        private string FIO { get; set; }
        private DateTime BirthDate { get; set; }
        private string BirthPlace { get; set; }
        private int PassportNumber { get; }

        public Person(string fio, DateTime date, string place, int passport)
        {
            FIO = fio;
            BirthDate = date;
            BirthPlace = place;
            PassportNumber = passport;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Fio: {FIO}, Passport number: {PassportNumber}");
        }

        public override bool Equals(object obj)
        {
            return obj is Person person && Equals(this.BirthDate, person.BirthDate);
        }

        public override int GetHashCode()
        {
            return PassportNumber + 100;
        }
    }
}
