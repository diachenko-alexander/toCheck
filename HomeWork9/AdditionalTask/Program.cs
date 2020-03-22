using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalTask
{
    class MyClass : IDisposable
    {
        Array array = new int[1000000];

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose (bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Console.WriteLine("Connection closed");
                }
                disposed = true;
            }
        }

        ~MyClass()
        {
            Dispose(false);
            Console.WriteLine("Finalize");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass1 = new MyClass();
            myClass1.Dispose();
            myClass1.Dispose();
        }
    }
}
