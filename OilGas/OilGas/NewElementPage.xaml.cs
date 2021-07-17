using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OilGas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewElementPage : ContentPage
    {
        public NewElementPage()
        {
            BindingContext = new NewElementViewModel(this);
            InitializeComponent();
        }
    }
}