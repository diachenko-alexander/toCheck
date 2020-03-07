using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file = File.Create("test.txt");
            var writer = new StreamWriter(file);
            writer.WriteLine("Hello");
            writer.WriteLine("ALL");
            writer.Close();
                        
            Console.WriteLine(File.ReadAllText("test.txt"));
            



        }
    }
}
