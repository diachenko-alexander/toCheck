using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Months months = new Months();
            foreach (var item in months)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine(months.GetMonthByNumber(DateTime.Now.Month));
            Console.WriteLine();
            Console.WriteLine(months.GetMonthByDaysCount(31));

        }
    }
}
