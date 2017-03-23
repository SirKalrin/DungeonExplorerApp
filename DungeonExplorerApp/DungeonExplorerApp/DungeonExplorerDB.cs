using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorerApp.Models;
using SQLite.Net;
using Xamarin.Forms;

namespace DungeonExplorerApp
{
    class DungeonExplorerDB
    {

        private static DungeonExplorerDB _instance;
        private SQLiteConnection _connection;

        private DungeonExplorerDB()
        {
            _connection = DependencyService.Get<IDBConnection>().GetConnection();
            _connection.CreateTable<MenuData>();
        }

        public static DungeonExplorerDB GetInstance()
        {
            return _instance ?? (_instance = new DungeonExplorerDB());
        }

        public IEnumerable<MenuData> GetMenuData()
        {
            return (from t in _connection.Table<MenuData>() select t).ToList();
        }

        public int Count()
        {
            return GetMenuData().Count();
        }

        public MenuData GetMenuDataById(int id)
        {
            return _connection.Table<MenuData>().FirstOrDefault(x => x.Id == id);
        }

        public bool DeleteMenuData(int id)
        {
            return _connection.Delete<MenuData>(id) > 0;
        }

        public void AddMenuData(MenuData menuData)
        {
            _connection.Insert(menuData);
        }

        public void WipeDatabase()
        {
            _connection.DeleteAll<MenuData>();
        }

        public void UpdateMenuData(MenuData menuData)
        {
            _connection.Update(menuData);
        }

    }
}
