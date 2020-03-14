using System;
using System.IO;
using System.Reflection;

namespace AdditionalTask
{
    class Program
    {
        static void Main(string[] args)
        {

            Assembly assembly = null;

            try
            {
                assembly = Assembly.Load("Task2");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            ListAllTypes(assembly);
            ListAllMembers(assembly);

        }

        private static void ListAllTypes (Assembly assembly)
        {
            Console.WriteLine(new string ('*', 20));
            Type[] types = assembly.GetTypes();
            foreach (Type t in types)
            {
                Console.WriteLine(t);
            }
         }

        private static void ListAllMembers(Assembly assembly)
        {
            Console.WriteLine(new string('*', 20));
            Type[] type = assembly.GetTypes();
            foreach (Type t in type)
            {
                var methods = t.GetMethods();
                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine(method.Name);
                }
            }    
                       
        }
    }
}
