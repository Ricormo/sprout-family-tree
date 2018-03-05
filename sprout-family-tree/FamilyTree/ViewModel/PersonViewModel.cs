using FamilyTree.Database.Model;
using System.Collections.Generic;

namespace FamilyTree.ViewModel
{
    public class PersonViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Sex { get; set; }

        public AppearanceModel Appearance { get; set; }
        public EventModel Birth { get; set; }
        public EventModel Death { get; set; }

        public List<EventModel> Events { get; set; }

        public long? FatherId { get; set; }
        public long? MotherId { get; set; }

        public List<PersonModel> Family { get; set; }

        public string FullName => FirstName + " " + LastName;
        public string LifeSpan => $"{Birth?.StartTime:d} - {Death?.StartTime:d}";
    }
}