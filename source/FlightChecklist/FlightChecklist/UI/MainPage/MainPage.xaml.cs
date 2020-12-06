using System.Collections.Generic;
using Xamarin.Forms;

namespace FlightChecklist
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainModel model = null)
        {
            BindingContext = new MainPageViewModel(this, model);
            InitializeComponent();
        }
    }
}
