using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Client
    {
        public string Name { get; set; }
        public Client(string name)
        {
            Name = name;
        }      

    }

    enum Category
    {
        monitor,
        mouse,
        keyboard
    }

    


    class Program
    {

        public static List<Client> GetClientsByCategory(Category category, Dictionary<Client, List<Category>> dic)
        {
            List<Client> result = new List<Client>();

            foreach (KeyValuePair<Client, List<Category>> item in dic)
            {
                if (item.Value.Contains(category))
                {
                    result.Add(item.Key);
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            Client c1 = new Client("Alex");
            Client c2 = new Client("Oleg");
            Client c3 = new Client("Roman");
            Dictionary<Client, List<Category>> clients = new Dictionary<Client, List<Category>>();

            clients.Add(c1, new List<Category> {Category.keyboard });
            clients.Add(c2, new List<Category> { Category.keyboard, Category.monitor, Category.mouse});
            clients.Add(c3, new List<Category> { Category.mouse});

            foreach (KeyValuePair <Client, List<Category>> item in clients)
            {
                Console.WriteLine(new string('*',20));
                Console.WriteLine(item.Key.Name);
                foreach (var cat in item.Value)
                {
                    Console.WriteLine(cat);
                }
            }

            Console.WriteLine(new string('/', 20));
            var clientsKeyboard = GetClientsByCategory(Category.keyboard, clients);
            foreach (var item in clientsKeyboard)
            {
                Console.WriteLine(item.Name);
            }



        }
    }
}
