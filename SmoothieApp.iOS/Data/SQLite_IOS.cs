using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Foundation;
using SmoothieApp.Data;
using SmoothieApp.iOS.Data;
using UIKit;

using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_IOS))]
namespace SmoothieApp.iOS.Data
{
    public class SQLite_IOS : ISQLite
    {
        public SQLite_IOS() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var fileName = "Testdb.db3";
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}