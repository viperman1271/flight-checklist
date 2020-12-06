using FlightChecklist.ObjectModel;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FlightChecklist
{
    public class ChecklistPageViewModel
    {
        private readonly ContentPage _View;
        private readonly Checklist _ChecklistModel;
        private readonly Category _CategoryModel;

        public ChecklistPageViewModel(ContentPage view, Checklist checklist)
        {
            _View = view;
            _ChecklistModel = checklist;
        }

        public ChecklistPageViewModel(ContentPage view, Category category)
        {
            _View = view;
            _CategoryModel = category;
        }

        public List<object> Items
        {
            get
            {
                List<object> items = new List<object>();
                if (_ChecklistModel != null)
                {
                    items.AddRange(_ChecklistModel.Categories);
                }
                if (_CategoryModel != null)
                {
                    items.AddRange(_CategoryModel.Categories);
                    items.AddRange(_CategoryModel.Items);
                }
                return items;
            }
        }

        public object SelectedItem
        {
            get { return null; }
            set
            {
                OnSelectedChecklist(value);
            }
        }

        private async void OnSelectedChecklist(object selectedItem)
        {
            if(selectedItem is Item)
            {
                ((Item)selectedItem).IsChecked = !((Item)selectedItem).IsChecked;
            }
            else if(selectedItem is Category)
            {
                CheckListPage page = new CheckListPage((Category)selectedItem);
                await _View.Navigation.PushModalAsync(page);
            }
        }
    }
}
