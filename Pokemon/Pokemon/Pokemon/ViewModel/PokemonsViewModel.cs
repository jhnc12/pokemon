using Pokemon.DataAccess;
using Pokemon.Helper;
using Pokemon.Model;
using Pokemon.Services;
using Pokemon.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pokemon.ViewModel
{
    public class PokemonsViewModel : BaseViewlModel
    {

        private List<PokemonModel> _listPokemon;
        public List<PokemonModel> ListPokemon
        {
            get { return _listPokemon; }
            set
            {
                _listPokemon = value;
                OnPropertyChanged(nameof(ListPokemon));
            }
        }

        private bool _popupExcluirVisivel;
        public bool PopupExcluirVisivel
        {
            get { return _popupExcluirVisivel; }
            set
            {
                _popupExcluirVisivel = value;
                OnPropertyChanged(nameof(PopupExcluirVisivel));
            }
        }

        public bool _loadingVisivel;
        public bool LoadingVisivel
        {
            get { return _loadingVisivel; }
            set
            {
                _loadingVisivel = value;
                OnPropertyChanged(nameof(LoadingVisivel));
            }
        }

        private PokemonModel _lastSelection;
        public PokemonModel LastSelection
        {
            get { return _lastSelection; }
            set
            {
                _lastSelection = value;
                OnPropertyChanged(nameof(LastSelection));
            }
        }

        public Command EditCommand { get; set; }
        public Command DetailCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Command ExcludItemCommand { get; set; }
        public Command CloseDeleteCommand { get; set; }

        public PokemonsViewModel()
        {
            EditCommand = new Command(async (obj) => Edit(obj));
            DetailCommand = new Command(async (obj) => GoToDetail(obj));
            DeleteCommand = new Command(async (obj) => Delete(obj));
            CloseDeleteCommand = new Command(Close);
            ExcludItemCommand = new Command(async () => DeleteItem());
            ListPokemon = new List<PokemonModel>();
            PopupExcluirVisivel = false;
            LoadingVisivel = true;
        }
        //Get
        public async Task SearchPokemons()
        {
            LoadingVisivel = true;
            try
            {
                ListPokemon = await Database.GetItemAsync();
                if (ListPokemon.Count == 0)
                {
                    var lista = await new PokemonServices().GetPokemon();
                    await SaveItens(lista);
                }

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Erro ao processar sua solicitação - " + ex.Message, "OK");
            }
            finally
            {
                LoadingVisivel = false;
            }
        }
        //Save
        async Task SaveItens(List<PokemonModel> _list)
        {
            foreach (var item in _list)
                await Database.SaveItemAsync(item);

            ListPokemon = await Database.GetItemAsync();

        }
        // Delete
        async Task DeleteItem()
        {
            if (LastSelection != null)
            {
                await Database.DeleteItemAsync(LastSelection);
                ListPokemon = await Database.GetItemAsync();
                Close();
            }
        }
        public void Close()
        {
            PopupExcluirVisivel = false;
        }
        public async Task Edit(object item)
        {
            LastSelection = (PokemonModel)item;
            await App.Current.MainPage.Navigation.PushAsync(new EditarItemView(LastSelection));
        }
        public async Task Delete(object item)
        {
            LastSelection = (PokemonModel)item;
            PopupExcluirVisivel = true;
        }
        public async Task GoToDetail(object item)
        {
            LastSelection = (PokemonModel)item;
            await App.Current.MainPage.Navigation.PushAsync(new DetailView(LastSelection));

        }
    }
}
