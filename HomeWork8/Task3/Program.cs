using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task3
{
    public class User
    {
        private Guid id;
        private string name;
        private string surname;

        public Guid Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Name
        {
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

        public User()
        {

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
            FileStream stream = new FileStream("user.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            XmlSerializer serializer = new XmlSerializer(typeof(User));
            var user = serializer.Deserialize(stream) as User;
            stream.Close();
            Console.WriteLine(user.Id);
            Console.WriteLine(user.Name);
            Console.WriteLine(user.Surname);
        }
    }
}
