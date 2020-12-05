using FlightChecklist.ObjectModel;
using System.Collections.Generic;

namespace FlightChecklist
{
    internal class MainPageViewModel
    {
        private readonly MainModel _Model;

        public MainPageViewModel(MainModel model)
        {
            _Model = model;
        }

        public List<Checklist> Items { get { return _Model?.Checklists; } }
    }
}
