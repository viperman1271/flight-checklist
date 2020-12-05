using FlightChecklist.ObjectModel;
using System.Collections.Generic;

namespace FlightChecklist
{
    public class MainModel
    {
        public MainModel()
        {
            Checklists = new List<Checklist>();
        }

        public List<Checklist> Checklists { get; }
    }
}
