using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            SetLabelsContent();
            Title = "Main Menu";
        }

        private void InitDummyMenuData()
        {
            if (_db.GetMenuData().Count().Equals(0))
            {
                _db.
                _db.AddMenuData(new MenuData()
                {
                    Content =
                        "Der er ingen nyheder idag. Der er ingen nyheder idag. Der er ingen nyheder idag. Der er ingen nyheder idag. Der er ingen nyheder idag. Der er ingen nyheder idag."
                });
                _db.AddMenuData(new MenuData() {Content = "Du har ingen karakterer, taber"});
                _db.AddMenuData(new MenuData() {Content = "Forumet er tomt"});
                _db.AddMenuData(new MenuData() {Content = "Vi kan desværre ikke hjælpe dig med dette problem"});
                _db.AddMenuData(new MenuData() {Content = "Det bliver 20$, tak"});
            }
            foreach (var data in _db.GetMenuData())
            {
                 Debug.WriteLine(data.Id + " " + data.Content);
            }
        }

        private void SetLabelsContent()
        {
            NewsLbl.Content = _db.GetMenuDataById(1).Content;
            CharactersLbl.Content = _db.GetMenuDataById(2).Content;
            ForumLbl.Content = _db.GetMenuDataById(3).Content;
            SupportLbl.Content = _db.GetMenuDataById(4).Content;
            MarketLbl.Content = _db.GetMenuDataById(5).Content;
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
