using FlightChecklist.ObjectModel;
using System.Collections.Generic;

namespace FlightChecklist
{
    internal class MainPageViewModel
    {
        private readonly MainPage _View;
        private readonly MainModel _Model;
        private Checklist _SelectedItem;

        public MainPageViewModel(MainPage view, MainModel model)
        {
            _View = view;
            _Model = model;
        }

        public List<Checklist> Items { get { return _Model?.Checklists; } }

        public Checklist SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                if(_SelectedItem != value)
                {
                    _SelectedItem = value;
                    OnSelectedChecklist();
                }
            }
        }

        private async void OnSelectedChecklist()
        {
            if (_SelectedItem != null)
            {
                CheckListPage page = new CheckListPage(_SelectedItem);
                await _View.Navigation.PushModalAsync(page);
            }
        }
    }
}
