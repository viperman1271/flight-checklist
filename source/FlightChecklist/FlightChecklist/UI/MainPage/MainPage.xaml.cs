using System;
using Xamarin.Forms;

namespace FlightChecklist
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainModel model = null)
        {
            BindingContext = new MainPageViewModel(model);

            try
            {
                InitializeComponent();
            }
            catch (InvalidCastException ex2)
            {

            }
            catch (Exception ex)
            {
            }
        }
    }
}
