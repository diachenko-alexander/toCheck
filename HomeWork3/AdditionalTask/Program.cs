using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = new DirectoryInfo(@"C:\1\2\3");

            if (directory.Exists)
            {
                for (int i = 0; i < 3; i++)
                {
                    directory.CreateSubdirectory("Folder_" + i.ToString());
                }
            }

            Console.Read();

            var directoryes = directory.GetDirectories();

            foreach (DirectoryInfo dir in directoryes)
            {
                try
                {
                    dir.Delete();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);                    
                }
            }
            
           
        }
    }
}
