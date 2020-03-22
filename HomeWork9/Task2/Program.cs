using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    class SomeObject
    {
        Array array = new int[10000];
    }

    class Program
    {
        public static void CreateManyObjects ()
        {
            SomeObject[] someObjects = new SomeObject[10000];
            for (int i = 0; i < someObjects.Length; i++)
            {
                someObjects[i] = new SomeObject();
                Thread.Sleep(100);
            }
        }
       
        static void Main(string[] args)
        {
            new Thread(CreateManyObjects).Start();
            MyMonitor monitor = new MyMonitor();
            monitor.AlertMemoryLevel = 1000000;
            monitor.StartMonitor(400);

            while (true)
            {
                Console.WriteLine(GC.GetTotalMemory(false));
                Thread.Sleep(500);
            }

        }
    }
}
