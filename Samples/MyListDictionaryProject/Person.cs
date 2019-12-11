using System;
using System.Collections.Generic;
using System.Text;

namespace MyListDictionaryProject
{
    class Person
    {
        public string BirthDate { get; }
        public string BirthPlace { get; }
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
        public int PassportNumber { get; }

        public Person(
            string firstName,
            string middleName,
            string lastName,
            string birthPlace,
            int passportNumber,
            string birthDate)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            BirthPlace = birthPlace;
            BirthDate = birthDate;
            PassportNumber = passportNumber;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Person))
            {
                return false;
            }

            var passport = (Person)obj;

            return passport.PassportNumber == PassportNumber;
        }

        public override int GetHashCode()
        {
            return PassportNumber - 1000;
        }
    }
}
