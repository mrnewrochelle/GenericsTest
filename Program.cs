using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Generics
{

    public class Test1 
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public string Property3 { get; set; }
    }

    public class Test2
    {
        public string Property4 { get; set; }
        public string Property5 { get; set; }
        public string Property6 { get; set; }
    }

    public class Test3
    {
        public string Property7 { get; set; }
        public string Property8 { get; set; }
        public string Property9 { get; set; }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            var dic1 = new Dictionary<string, string>()
            {
                {"Property1", "The_Property1"},
                {"Property2", "The_Property2"},
                {"Property3", "The_Property3"}
            };

            Test1 result = Convert<Test1>(dic1);

            foreach (PropertyInfo item in typeof(Test1).GetProperties())
            {
                System.Console.WriteLine($"{item.Name} = {item.GetValue(result)}");
            }

            // ******************************************************

            var dic2 = new Dictionary<string, string>()
            {
                {"Property4", "The_Property4"},
                {"Property5", "The_Property5"},
                {"Property6", "The_Property6"}
            };

            Test2 result2 = Convert<Test2>(dic2);
            
            foreach (PropertyInfo item in typeof(Test2).GetProperties())
            {
                System.Console.WriteLine($"{item.Name} = {item.GetValue(result2)}");
            }

            // **************************************************

            var dic3 = new Dictionary<string, string>()
            {
                {"Property7", "The_Property7"},
                {"Property8", "The_Property8"},
                {"Property9", "The_Property9"}
            };

            Test3 result3 = Convert<Test3>(dic3);
            
            foreach (PropertyInfo item in typeof(Test3).GetProperties())
            {
                System.Console.WriteLine($"{item.Name} = {item.GetValue(result3)}");
            }

        }

        public static T Convert<T>(Dictionary<string,string> parameters) where T: class, new()
        {
            var newObject = new T();
            var newObjectType = newObject.GetType();
            
            foreach (var item in parameters)
            {
                newObjectType.GetProperty(item.Key).SetValue(newObject, item.Value);
            }

            return newObject;
        }

        
    }
}
