using FlightChecklist.ObjectModel;
using System.Collections.Generic;

namespace FlightChecklist
{
    internal class MainPageViewModel
    {
        private readonly MainPage _View;
        private readonly MainModel _Model;

        public MainPageViewModel(MainPage view, MainModel model)
        {
            _View = view;
            _Model = model;
        }

        public List<Checklist> Items { get { return _Model?.Checklists; } }

        public Checklist SelectedItem
        {
            get { return null; }
            set
            {
                OnSelectedChecklist(value);
            }
        }

        private async void OnSelectedChecklist(Checklist selectedItem)
        {
            if (selectedItem != null)
            {
                CheckListPage page = new CheckListPage(selectedItem);
                await _View.Navigation.PushModalAsync(page);
            }
        }
    }
}
