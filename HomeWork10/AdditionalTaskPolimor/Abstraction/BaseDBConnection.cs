using System;
using AdditionalTaskPolimor.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalTaskPolimor.Abstraction
{
    abstract class BaseDBConnection : IDBConnection, IDisposable
    {
        public string Query { get; set; }
        private bool disposed = false;

        public BaseDBConnection()
        {

        }
        
        public BaseDBConnection(string query)
        {
            Query = query;
        }

        public void RunQuery()
        {
            CreateDbConnection();
            OpenDbConnection();
            ExecuteQuery();
            CloseDbConnection();
        }
        
        protected virtual void CreateDbConnection()
        {
            Console.WriteLine("Creating DB Connection");
        }

        protected virtual void OpenDbConnection()
        {
            Console.WriteLine("Opening DB Connection");
        }

        protected virtual void ExecuteQuery()
        {
            Console.WriteLine($"Executing query: {Query}");
        }

        protected virtual void CloseDbConnection()
        {
            Console.WriteLine("Closing DB Connection");
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose (bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    CloseDbConnection();
                }
                disposed = true;
            }
        }

        ~BaseDBConnection()
        {
            Dispose(false);      
        }

    }
}
