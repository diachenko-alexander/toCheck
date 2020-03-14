using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class MyClass
    {
        [Obsolete ("Metod will be removed")]
        public void MyMethod()
        {
            Console.WriteLine("Some text");
        }

        [Obsolete("Metod is forbidden", true)]
        public void MyMethod2()
        {
            Console.WriteLine("Some text");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            myClass.MyMethod();
            myClass.MyMethod2();
        }
    }
}
