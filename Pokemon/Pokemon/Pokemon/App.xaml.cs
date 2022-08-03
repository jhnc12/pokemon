using Pokemon.DataAccess;
using Pokemon.View;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokemon
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            if (Database._database == null)
            {
                var p = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "pokemon.db3");
                Database.NewDatabase(p);
            }
            MainPage = new NavigationPage(new PokemonsView());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
