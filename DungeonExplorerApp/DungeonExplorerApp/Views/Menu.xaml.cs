using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorerApp.Models;
using SQLite.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DungeonExplorerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        private DungeonExplorerDB _db = DungeonExplorerDB.GetInstance();

        public Menu()
        {
            InitializeComponent();
            InitDummyMenuData();
            InitializeEventhandlers(GetLabels());
            Title = "Main Menu";
        }

        public void InitDummyMenuData()
        {
            _db.AddMenuData(new MenuData() {Content = "Der er ingen nyheder idag. Der er ingen nyheder idag. Der er ingen nyheder idag. Der er ingen nyheder idag. Der er ingen nyheder idag. Der er ingen nyheder idag." });
            NewsLbl.Content = _db.GetMenuDataById(1).Content;
        }

        private List<MenuLabel> GetLabels()
        {
            return new List<MenuLabel>()
            {
                NewsLbl, CharactersLbl, ForumLbl, MarketLbl, SupportLbl
            };
        }

        private void OnLabelClicked(string content)
        {
            ContentLabel.Text = content;
        }

        private void InitializeEventhandlers(List<MenuLabel> lblLst)
        {
            foreach (var lbl in lblLst)
            {
                lbl.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = new Command(() => OnLabelClicked(lbl.Content)),
                });
            }
        }
    }
}
