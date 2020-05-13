using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmoothieApp.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
