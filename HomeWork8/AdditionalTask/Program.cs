using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalTask
{
    [Serializable]
    public class User
    {
        private Guid id;
        private string name;
        private string surname;

        public Guid Id { get {return id; } }
        public string Name {
            get
            {
                return name;
            }
            set
            {
                name = value;
            } 
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }

        public User(string name, string surname)
        {
            id = Guid.NewGuid();
            this.name = name;
            this.surname = surname;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("alex", "Diachenko");
            FileStream stream = File.Create("User.dat");
            BinaryFormatter formatter = new BinaryFormatter();
            
            formatter.Serialize(stream, user1);
            stream.Close();

            stream = File.OpenRead("User.dat");
            var user2 = formatter.Deserialize(stream) as User;
            stream.Close();
            Console.WriteLine(user2.Name);
            


            Console.ReadKey();
        }
    }
}
