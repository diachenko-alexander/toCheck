using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalTaskPolimor.Interfaces
{
    interface IDBConnection
    {
        string Query { get; set; }
        void RunQuery();
        
    }
}
