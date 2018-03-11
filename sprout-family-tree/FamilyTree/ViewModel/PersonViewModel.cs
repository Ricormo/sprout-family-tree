using System;
using System.Collections.Generic;
using FamilyTree.Domain.Model;

namespace FamilyTree.ViewModel
{
    public class PersonViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }

        public long? FatherId { get; set; }
        public long? MotherId { get; set; }
        //public List<PersonModel> Children { get; set; }

        public AppearanceModel Appearance { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public List<EventModel> Events { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string FullName => FirstName + " " + LastName;
        //public string LifeSpan => $"{Birth?.StartTime:d} - {Death?.StartTime:d}";


    }
}