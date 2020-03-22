using System;
using AdditionalTaskPolimor.Abstraction;

namespace AdditionalTaskPolimor.Services
{
    class MSSQLService : BaseDBConnection
    {
        public MSSQLService()
            : base()
        {

        }

        public MSSQLService(string query)
            : base (query)
        {

        }
        
        protected override void CreateDbConnection()
        {
            Console.WriteLine("Creating MSSQL DB Connection");
        }

        protected override void OpenDbConnection()
        {
            Console.WriteLine("Opening MSSQL DB Connection");
        }

        protected override void ExecuteQuery()
        {
            Console.WriteLine($"Executing MSSQL query: {Query}");
        }

        protected override void CloseDbConnection()
        {
            Console.WriteLine("Closing MSSQL DB Connection");
            Dispose(false);
        }        
    }
}
