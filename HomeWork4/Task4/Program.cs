using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {            
            var currentCulture = CultureInfo.CurrentCulture;
            var usCulture = CultureInfo.GetCultureInfo("us-US");

            var text = File.ReadAllText("test.txt", Encoding.UTF8);
            string pattern = @"[0-9]+[\.][0-9]+";

            var currentCultureText = Regex.Replace(text, pattern, (m) => double.Parse(m.Value.Replace(".", ",")).ToString("C", currentCulture));
            var usCultureText = Regex.Replace(text, pattern, (m) => double.Parse(m.Value.Replace(".", ",")).ToString("C", usCulture));

            Console.WriteLine(currentCultureText);
            Console.WriteLine(usCultureText);
        }
    }
}
