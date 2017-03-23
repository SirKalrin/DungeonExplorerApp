using System;
using System.IO;
using DungeonExplorerApp.Droid;
using SQLite.Net;
using Xamarin.Forms;


[assembly: Dependency(typeof(AndroidSQLiteDBConnection))]

namespace DungeonExplorerApp.Droid
{
    class AndroidSQLiteDBConnection : IDBConnection
    {
        public SQLiteConnection GetConnection()
        {
            var fileName = "DungeonExplorer.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLiteConnection(platform, path);

            return connection;
        }
    }
}