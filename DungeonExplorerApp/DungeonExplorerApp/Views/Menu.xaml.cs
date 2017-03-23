using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DungeonExplorerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();       
            InitializeEventhandlers(GetLabels());
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
