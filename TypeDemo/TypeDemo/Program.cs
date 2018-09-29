using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeDemo
{
    public class Personal {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*Type*/
            Type type = typeof(Personal);

            /*GetProperty*/
            List<string> personalProp = type.GetProperties().Select(x => x.Name).ToList();
            PrintList(personalProp);

            /*GetValue*/
            Personal personal = new Personal() { Id = "0", Name = "Elijah", Value = "150", Age = "24" };

            foreach (string obj in personalProp) {
                Console.Write($"{type.GetProperty(obj).GetValue(personal,null)} ");
            }
            Console.Write("\n");

            /*SetValue*/
            Personal emptyPersonal = new Personal();

            string[] values = { "1", "JJ", "250", "24" };
            for (int i = 0; i < personalProp.Count; i++)
            {
                type.GetProperty(personalProp[i]).SetValue(emptyPersonal, values[i], null);
            }
            Console.Write($"{emptyPersonal.Id} ");
            Console.Write($"{emptyPersonal.Name} ");
            Console.Write($"{emptyPersonal.Value} ");
            Console.Write($"{emptyPersonal.Age} ");

            /*Dynamic Gernerator*/
            Personal empty = new Personal();
            string[] setValues = { "2", "Elijah", "350", "22" };
            SetObj(empty, setValues);

            Console.Write($"{empty.Id} ");
            Console.Write($"{empty.Name} ");
            Console.Write($"{empty.Value} ");
            Console.Write($"{empty.Age} ");

            /*GetPropertyType*/
            List<string> propertyType = type.GetProperties().Select(x => x.PropertyType.ToString()).ToList();
            PrintList(propertyType);

            Console.ReadLine();
        }

        static T SetObj<T>(T source, string[] values)
        {
            Type type = source.GetType();
            List<string> propList = type.GetProperties().Select(x => x.Name).ToList();
            for (int i = 0; i < propList.Count; i++)
            {
                type.GetProperty(propList[i]).SetValue(source, values[i], null);
            }
            return source;
        }

        static void PrintList<T>(List<T> source) {
            if (source != null) {
                foreach (T obj in source) {
                    Console.Write($"{obj},");
                }
                Console.Write("\n");
            }
        }
    }
}
