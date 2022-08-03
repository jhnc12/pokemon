using Pokemon.Helper;
using Pokemon.Model;
using Pokemon.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.ViewModel
{
    public class DetailViewModel : BaseViewlModel
    {

        private DetalhesModel _details;
        public DetalhesModel Details
        {
            get { return _details; }
            set
            {
                _details = value;
                OnPropertyChanged(nameof(Details));
            }
        }
        private PokemonModel _selection;
        public PokemonModel Selection
        {
            get { return _selection; }
            set
            {
                _selection = value;
                OnPropertyChanged(nameof(Selection));
            }
        }
        private string _image;
        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private string _anotation;
        public string Anotation
        {
            get { return _anotation; }
            set
            {
                _anotation = value;
                OnPropertyChanged(nameof(Anotation));
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
        public DetailViewModel(PokemonModel itemSelected)
        {
            Selection = itemSelected;
            Anotation = itemSelected.anotation;
            Name = itemSelected.name;
            Image = itemSelected.image;
            Details = new DetalhesModel();
            LoadingVisivel = true;
            GetDetail();
        }
        public async Task GetDetail()
        {
            try
            {
                LoadingVisivel = true;
                Details = await new PokemonServices().GetDetail(Selection.url);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Erro ao processar sua solicitação - " + ex.Message, "OK");
            }
            finally
            {
                await Task.Delay(3000);
                LoadingVisivel = false;
            }
        }
    }
}
