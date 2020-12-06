using FlightChecklist.ObjectModel;
using System.Collections.Generic;

namespace FlightChecklist
{
    public class MainModel
    {
        public MainModel()
        {
            Checklists = new List<Checklist>();
            IdentifierPackages = new List<IdentifierPackage>();
        }

        public List<Checklist> Checklists { get; }
        public List<IdentifierPackage> IdentifierPackages { get; }
    }
}
