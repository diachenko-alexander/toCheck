using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditioanalTask
{
    public class DescendingComparer : IComparer
    {
        CaseInsensitiveComparer comparer = new CaseInsensitiveComparer();

        public int Compare(object x, object y)
        {
            int result = comparer.Compare(y, x);
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var mySort = new SortedList();
            mySort.Add("first", "1");
            mySort.Add("Second", "2");
            mySort.Add("Third", "3");

            foreach (DictionaryEntry entry in mySort)
            {
                Console.WriteLine($"{entry.Key}  {entry.Value}");
            }

            Console.WriteLine();
            var mySort2 = new SortedList(new DescendingComparer());
            mySort2.Add("first", "1");
            mySort2.Add("Second", "2");
            mySort2.Add("Third", "3");

            foreach (DictionaryEntry entry in mySort2)
            {
                Console.WriteLine($"{entry.Key}  {entry.Value}");
            }
        }
    }
}
