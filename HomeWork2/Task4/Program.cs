using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections;

namespace Task4
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Client(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return string.Format($"{Id}  {Name}");
        }
    }

    class IdCompare : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            Client x1 = x as Client;
            Client y2 = y as Client;
            return x1.Id == y2.Id;
        }

        public int GetHashCode(object obj)
        {
            return (obj as Client).Id;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Client c1 = new Client(1, "Alex");
            Client c2 = new Client(2, "Petr");
            Client c3 = new Client(2, "Oleg");
            
            var orderedDictionary = new OrderedDictionary(new IdCompare());
            orderedDictionary.Add(c1, "test1");
            orderedDictionary.Add(c2, "test2");
            orderedDictionary.Add(c3, "test");

            foreach(DictionaryEntry entry in orderedDictionary)
            {
                Console.WriteLine($"{entry.Key}");
            }
        }

    }
}
