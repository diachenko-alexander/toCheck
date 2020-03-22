using System;
using AdditionalTaskPolimor.Abstraction;

namespace AdditionalTaskPolimor.Services
{
    class PostgreeSQLService : BaseDBConnection
    {
        public PostgreeSQLService()
         : base ()
        {

        }

        public PostgreeSQLService(string query)
            : base (query)
        {

        }

        protected override void CreateDbConnection()
        {
            Console.WriteLine("Creating PostgreeSQL DB Connection");
        }

        protected override void OpenDbConnection()
        {
            Console.WriteLine("Opening PostgreeSQL DB Connection");
        }

        protected override void ExecuteQuery()
        {
            Console.WriteLine($"Executing PostgreeSQL query: {Query}");
        }

        protected override void CloseDbConnection()
        {
            Console.WriteLine("Closing PostgreeSQL DB Connection");
            Dispose(false);
        }
    }
}
