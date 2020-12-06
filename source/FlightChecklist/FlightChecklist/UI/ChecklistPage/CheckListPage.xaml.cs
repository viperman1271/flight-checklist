using FlightChecklist.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlightChecklist
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckListPage : ContentPage
	{
		public CheckListPage(Checklist checklist)
		{
            BindingContext = new ChecklistPageViewModel(checklist);
			InitializeComponent ();
		}
	}
}