using FlightChecklist.ObjectModel;
using System.Collections.Generic;

namespace FlightChecklist
{
    public class ChecklistPageViewModel
    {
        private readonly Checklist _Model;

        public ChecklistPageViewModel(Checklist checklist, MainModel dataRepository)
        {
            _Model = checklist;
            DataRepository = dataRepository;
        }

        public List<Category> Items
        {
            get { return _Model?.Categories; }
        }

        public MainModel DataRepository { get; }
    }
}
