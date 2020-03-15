using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task2
{
    [XmlRoot("User")]
    public class User
    {
        private Guid id;
        private string name;
        private string surname;

        public Guid Id 
        { get 
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

    public class UserAtr
    {
        private Guid id;
        private string name;
        private string surname;

        [XmlAttribute("id")]
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

        [XmlAttribute("name")]
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

        [XmlAttribute("surname")]
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

        public UserAtr()
        {

        }
        
        public UserAtr (string name, string surname)
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
            User user = new User("alex", "diachenko");
            UserAtr userAtr = new UserAtr("alex", "diachenko");

            XmlSerializer serializer = new XmlSerializer(typeof(User));
            XmlSerializer serializerAtr = new XmlSerializer(typeof(UserAtr));

            FileStream stream = new FileStream("user.xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            serializer.Serialize(stream, user);
            stream.Close();

            stream = new FileStream("userAtr.xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            serializerAtr.Serialize(stream, userAtr);
            stream.Close();
        }
    }
}
