using System;
using System.Xml;

namespace AdditionalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlWriter = new XmlTextWriter("TelephoneBook.xml", null);
            xmlWriter.Formatting = Formatting.Indented;
            xmlWriter.IndentChar = '\t';
            xmlWriter.Indentation = 1;

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("MyContacts");
            xmlWriter.WriteStartElement("Contact");
            xmlWriter.WriteStartAttribute("TelephoneNumber");       // Атрибут - FontSize
            xmlWriter.WriteString("+123456789");                      // ="8"
            xmlWriter.WriteEndAttribute();
            xmlWriter.WriteString("Alex");
            xmlWriter.WriteEndElement();                     
            xmlWriter.WriteEndElement();

            xmlWriter.Close();
        }
    }
}
