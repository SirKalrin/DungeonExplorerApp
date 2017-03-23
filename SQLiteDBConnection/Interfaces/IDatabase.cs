using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDBConnection.Interfaces
{
    public interface IDatabase
    {
        SQLiteDBConnection GetConnection();
    }
}
