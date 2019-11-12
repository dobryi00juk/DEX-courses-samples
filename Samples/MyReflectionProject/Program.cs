using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MyReflectionProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //требуется указать полный путь к сборке
            Assembly assembly = Assembly.LoadFrom("D:\\Projects\\DEX-courses-samples-master\\Samples\\Stage1\\bin\\Debug\\Stage1.dll");

            Type type = assembly.GetType("Stage1.MyOopTest+House", false, true);

            object obj = Activator.CreateInstance(type, new object[] {3400, 15, 120, true});

            var method1 = type.GetMethod("ShowInfo");
            var method2 = type.GetMethod("MaxOccupant");

            object result1 = method1.Invoke(obj, new object[] { });
            object result2 = method2.Invoke(obj, new object[] { 26 });

            PropertyInfo prop = type.GetProperty("HaveLift", BindingFlags.NonPublic | BindingFlags.Instance);

            var propertyValue = (bool) prop.GetValue(obj);

            Console.WriteLine("Значение свойства: " + propertyValue.ToString());

            Type ctype = typeof(Program);
            var ctors = ctype.GetConstructors();

            foreach (var item in ctors)
            {
                Console.WriteLine("Конструктор для типа: " + item.DeclaringType);
            }
        }
    }
}
