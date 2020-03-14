using System;
using System.IO;
using System.Xml;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = new FileStream("TelephoneBook.xml", FileMode.Open);

            XmlTextReader xmlReader = new XmlTextReader(stream);

            while (xmlReader.Read())
            {
                Console.WriteLine("NodeType: {0,-15}| Name: {1,-15}| Value: {2,-15}",
                                xmlReader.NodeType,
                                xmlReader.Name,
                                xmlReader.Value);
            }

            xmlReader.Close();
            stream.Close();
        }
    }
}
