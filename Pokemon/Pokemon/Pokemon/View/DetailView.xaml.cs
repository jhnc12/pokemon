using Pokemon.Model;
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
    public partial class DetailView : ContentPage
    {
        public DetailView(PokemonModel itemSelected)
        {
            InitializeComponent();
            BindingContext = new DetailViewModel(itemSelected);
        }
    }
}