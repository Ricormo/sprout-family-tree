using System;

namespace FamilyTree.Domain.Model
{
    public class PersonModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Sex { get; set; }

        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public AppearanceModel Appearance { get; set; }
        
        public long? FatherId { get; set; }
        public long? MotherId { get; set; }       
    }
}