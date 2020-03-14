using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create file
            string file = "sometext.txt";
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine("Файл для замены всех предлогов на слово ГАВ. И на где");
            writer.Close();
            
            // Change word in file
            string pattern = @"\s[а-я]{1,3}\s";
            var originText = File.ReadAllText(file);
            var replacedText = Regex.Replace(originText, pattern, "ГАВ");
            File.WriteAllText("sometext2.txt", replacedText);
        }
    }
}
