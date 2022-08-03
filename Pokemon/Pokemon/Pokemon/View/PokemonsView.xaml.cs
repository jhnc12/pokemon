using Pokemon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokemon.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokemonsView : ContentPage
    {
        PokemonsViewModel viewlModel;
        public PokemonsView()
        {
            InitializeComponent();
            BindingContext = viewlModel = new PokemonsViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            viewlModel.SearchPokemons();
        }
    }
}