using System;
using System.IO;
using Xamarin.Forms;
using SQLite.Net;
using SQLiteDBConnection.Interfaces;

namespace SQLiteDBConnection
{
    public class SQLiteDBConnection : IDatabase
    {
        public SQLiteDBConnection()
        {
        }

        public SQLiteDBConnection GetConnection()
        {
            var fileName = "PersonsDB.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);

            return connection;
        }

    }


}

