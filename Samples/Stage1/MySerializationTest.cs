using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Stage1
{
    public class MySerializationTest
    {
        [Serializable]
        public class Car
        {
            public string Model { get; set; }
            public int MaxSpeed { get; set; }
            public Guid GarageId { get; set; }

            public Car() { }

            public Car(string model, int maxSpeed)
            {
                Model = model;
                MaxSpeed = maxSpeed;
                GarageId = Guid.NewGuid();
            }
        }

        [Serializable]
        public class Garage 
        {
            public int Plases { get; set; }
            public List<Car> Cars { get; set; }

            public Garage(int plases, List<Car> cars)
            {
                Plases = plases;
                Cars = cars;
            }
        }

        private List<Car> GetCars()
        {
            Car ford = new Car("Ford", 220);
            Car mersedes = new Car("Mersedes", 280);
            Car jiga = new Car("Жигули 6-й модели", 9999);

            return new List<Car> {ford, mersedes, jiga};
        }

        private Garage[] GetGarages()
        {
            Garage garage = new Garage(120, GetCars());

            return new Garage[] {garage};
        }

        [Test]
        public void BinaryTest()
        {
            var garages = GetGarages();
            BinaryFormatter formatter = new BinaryFormatter();

            Garage[] deserilizeGarage;
            using (var stream = new MemoryStream())
            {
                // сериализация
                formatter.Serialize(stream, garages);


                var base64 = Convert.ToBase64String(stream.ToArray());
                Console.WriteLine("Сериализованные данные:\n{0}",base64);
                stream.Position = 0;

                // десериализация
                deserilizeGarage = (Garage[]) formatter.Deserialize(stream);
            }

            Console.WriteLine();
            Console.WriteLine("Десериализованные данные:");
        }

        [Test]
        public void XmlTest()
        {
            var cars = GetCars();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Car>));

            List<Car> deserilizeCars;
            using (var stream = new MemoryStream())
            {
                // сериализация
                formatter.Serialize(stream, cars);

                var text = Encoding.Default.GetString(stream.ToArray());
                Console.WriteLine("Сериализованные данные:\n{0}",text);
                stream.Position = 0;

                // десериализация
                deserilizeCars = (List<Car>) formatter.Deserialize(stream);
            }
            
            Console.WriteLine();
            Console.WriteLine("Десериализованные данные:");
        }

        [Test]
        public void JsonTest()
        {
            var garages = GetGarages();

            string json = JsonConvert.SerializeObject(garages);
            Console.WriteLine("Сериализованные данные:");
            Console.WriteLine(json);
            
            Garage[] deserilizeUsers = JsonConvert.DeserializeObject<Garage[]>(json);
            Console.WriteLine();
            Console.WriteLine("Десериализованные данные:");
        }
    }
}