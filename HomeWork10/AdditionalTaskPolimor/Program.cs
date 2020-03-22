using System;
using AdditionalTaskPolimor.Abstraction;
using AdditionalTaskPolimor.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalTaskPolimor
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseDBConnection msConnection = new MSSQLService("select * from somePostgreeTable");
            using (msConnection)
            {
                msConnection.RunQuery();
            }

            Console.WriteLine();

            BaseDBConnection pgConnection = new PostgreeSQLService();
            pgConnection.Query = "select * from somePostgreeTable";
            using (pgConnection)
            {
                pgConnection.RunQuery();
            }
            

            
        }
    }
}
