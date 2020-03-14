using System;
using System.Reflection;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.Load("Task2");
            dynamic instance = Activator.CreateInstance(assembly.GetType("Task2.Converter"));
            Console.Write("Enter celsius temperature: ");
            double celsius = double.Parse(Console.ReadLine());
            
            Console.WriteLine(instance.CelsiusToFahrenheit(celsius));
            Console.ReadKey();
        }
    }
}
