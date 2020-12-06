using FlightChecklist.ObjectModel;
using System.Collections.Generic;

namespace FlightChecklist
{
    public class ChecklistPageViewModel
    {
        private Checklist _Model;

        public ChecklistPageViewModel(Checklist checklist)
        {
            _Model = checklist;
        }

        public List<Category> Items
        {
            get { return _Model?.Categories; }
        }
    }
}
