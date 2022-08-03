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
    public partial class ExcluirItemView : StackLayout
    {
        public ExcluirItemView()
        {
            InitializeComponent();
        }
    }
}