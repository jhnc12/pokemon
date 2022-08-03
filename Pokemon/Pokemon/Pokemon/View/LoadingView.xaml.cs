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
    public partial class LoadingView : StackLayout
    {
        public LoadingView()
        {
            InitializeComponent();
            AnimationLoading();
        }
        public async void AnimationLoading()
        {
            while (true)
           {
                await imageLoading.RotateTo(360, 800);
                imageLoading.Rotation = 0;
            }
        }
    }
}