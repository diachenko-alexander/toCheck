using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter url: ");
            string url = Console.ReadLine();

            WebRequest request = WebRequest.Create(url);
            HttpWebResponse res = (HttpWebResponse)request.GetResponse();

            if (!res.StatusDescription.Equals("OK"))
            {
                Console.WriteLine("Error");
                Console.WriteLine(res.StatusCode);
            }

            Stream stream = res.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);
            var httpResponse = streamReader.ReadToEnd();

            res.Close();
            streamReader.Close();


            StreamWriter streamWriter = File.CreateText("response.txt");

            var linkRegex = new Regex(@"href=""(?<link>\S+)"">(?<caption>\S+)</a>");
            var phoneRegex = new Regex(@"(?<phone>[+3(0-90-90-9)\s]{2,}[0-9]{3}[\s\-][0-9]{2}[\s\-][0-9]{2})");
            var emailRegex = new Regex(@"(?<email>[0-9A-Za-z_.-]+@[0-9a-zA-Z-]+\.[a-zA-Z]{2,4})");
                      

            foreach (Match m in linkRegex.Matches(httpResponse))
            {
                streamWriter.WriteLine("Link: {0,-50} Caption: {1, -4}", m.Groups["link"], m.Groups["caption"]);

            }

            foreach (Match m in phoneRegex.Matches(httpResponse))
            {
                streamWriter.WriteLine("Phone: {0,-25}", m.Groups["phone"]);
            }

            foreach (Match m in emailRegex.Matches(httpResponse))
            {
                streamWriter.WriteLine("Email: {0,-25}", m.Groups["email"]);
            }


            streamWriter.Close();


        }
    }
}
