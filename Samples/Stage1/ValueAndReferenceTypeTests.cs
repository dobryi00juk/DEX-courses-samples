//using System;
//using System.Collections.Generic;
//using NUnit.Framework;

//namespace Stage1
//{
//    [TestFixture]
//    public class ValueAndReferenceTypeTests
//    {
//        [Test]
//        public void CopyValueTypesTest()
//        {
//            Appartment appartment1 = new Appartment();
//            Appartment appartment2 = new Appartment();
//            Assert.AreEqual(appartment1.Rooms, appartment2.Rooms);
//            Assert.AreEqual(appartment1.Floor, appartment2.Floor);

//            Room room = new Room();

//        }

//        [Test]
//        public void CopyReferenceTypesTest()
//        {
//            Country country1 = new Country();
//            Assert.AreEqual(0, country1.X);
//            Assert.AreEqual(0, country1.Y);

//            Country country2 = new Country();
//            country2.X = 1;
//            country2.Y = 2;
//            Assert.AreEqual(1, country2.X);
//            Assert.AreEqual(2, country2.Y);

//            country1 = country2;
//            Assert.AreEqual(1, country1.X);
//            Assert.AreEqual(2, country1.Y);

//            country2.X = 5;
//            Assert.AreEqual(5, country2.X);
//            Assert.AreEqual(5, country1.X); // country1.x == 5, так как country1 и country2 указывают на один объект в куче
//        }

//        [Test]
//        public void ValueTypeAsMethodParameterTest()
//        {
//            var i = 0;
//            ChangeValue(i); //передается копия значения
//            Assert.AreEqual(0, i);
//        }

//        [Test]
//        public void ReferenceTypeAsMethodParameterTest()
//        {
//            Person p = new Person { Name = "Tom", Age = 23 };
//            Assert.AreEqual("Tom", p.Name);
//            ChangePerson(p); //передается копия ссылки
//            Assert.AreEqual("Alice", p.Name);
//        }

//        [Test]
//        public void ReferenceTypeAsPartOfValueTypeTest()
//        {
//            State state1 = new State();
//            state1.Country = new Country();
//            state1.Country.X = 1;

//            State state2 = new State();
//            state2.Country = new Country();
//            state2.Country.X = 5;

//            // state1.Country и state2.Country ссылаются на разные объекты в куче
//            Assert.AreEqual(1, state1.Country.X);
//            Assert.AreEqual(5, state2.Country.X);


//            state1 = state2; //копирование
//            state2.Country.X = 8;

//            // state1 и state2 - это копии, а не одно и тоже значение,
//            // state1.Country и state2.Country - копии ссылочной переменной, ссылающихся на один объект в куче
//            Assert.AreEqual(8, state1.Country.X);
//            Assert.AreEqual(8, state2.Country.X);
//        }


//        //private void ChangePerson(Person person)
//        //{
//        //    //person указывает на тот же объект в куче, что и ссылочная переменная из вызывающего кода,
//        //    //но это не та же ссылочная переменная, а ее копия
//        //    person.Name = "Alice"; 
//        //    person = new Person { Name = "Bill", Age = 45 }; // здесь ссылочная переменная указывает уже на другой объект, а ссылочная переменная из вызывающего кода на прежний
//        //    Console.WriteLine(person.Name); // Bill
//        //}

//        private void ChangeValue(int i)
//        {
//            i = 5; // меняется копия значения, а не значение из вызывающего кода
//            Console.WriteLine(i); // 5
//        }

//        struct Appartment
//        {
//            public int Floor { get; set; }
//            public List<Room> Rooms { get; set; }
//        }

//        class Room
//        {
//            public int Square { get; set; }
//            public int Windows { get; set; }
//        }

//        class Door
//        {
//            public int Size { get; set; }
//            public int Color { get; set; }
//        }

//    }
//}