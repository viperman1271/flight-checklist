
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlightChecklist
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckListPage : ContentPage
	{
		public CheckListPage ()
		{
            BindingContext = new ChecklistPageViewModel();
			InitializeComponent ();
		}
	}
}