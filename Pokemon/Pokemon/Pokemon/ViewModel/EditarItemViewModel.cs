using Pokemon.DataAccess;
using Pokemon.Helper;
using Pokemon.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pokemon.ViewModel
{
    public class EditarItemViewModel : BaseViewlModel
    {
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
        public Command UpdateCommand { get; set; }
        public EditarItemViewModel(PokemonModel itemSelected)
        {
            UpdateCommand = new Command(async () => UpdateItem());
            Selection = itemSelected;
            Anotation = itemSelected.anotation;
            Name = itemSelected.name;
            Image = itemSelected.image;
        }
        // Update
        public async Task UpdateItem()
        {

            if (Selection != null)
            {
                Selection.image = Image;
                Selection.name = Name;
                Selection.anotation = Anotation;
                await Database.UpdateItemAsync(Selection);
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}
