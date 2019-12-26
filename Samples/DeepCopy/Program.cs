using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DeepCopy
{
    static class Program
    {
        static void Main(string[] args)
        {
            var original = new List<Employee>
            {
                new Employee {Id = Guid.NewGuid(), Person = new Person{Name = "Tom1"}},
                new Employee {Id = Guid.NewGuid(), Person = new Person{Name = "Tom2"}},
                new Employee {Id = Guid.NewGuid(), Person = new Person{Name = "Tom3"}},
                new Employee {Id = Guid.NewGuid(), Person = new Person{Name = "Tom4"}},
                new Employee {Id = Guid.NewGuid(), Person = new Person{Name = "Tom5"}}
            };

            var copy = DeepCopy(original);
            
            foreach (var item in copy)
            {
                Console.WriteLine(item.Id);
            }

            Console.WriteLine("---------------------------------");
            var copy1 = DeepCopy(copy);

            foreach (var item in copy1)
            {
                Console.WriteLine(item.Id);
            }
        }

        private static T DeepCopy<T>(T obj)
        {
            if (ReferenceEquals(obj,null)) return default(T);
            var setting = new JsonSerializerSettings {ContractResolver = new ContractResolver()};
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj, setting), setting);
        }
    }
    
    public class Employee
    {
        public Guid Id { get; set; }
        public Person Person { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
    }
}