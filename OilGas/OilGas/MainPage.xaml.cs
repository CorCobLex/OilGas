using Xamarin.Forms;

namespace OilGas
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MainViewModel(this);
            InitializeComponent();
        }
    }
}
