using System;

namespace FamilyTree.Database.Model
{
    public class EventModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public short EventId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public LocationModel Location { get; set; }
        public string Comment { get; set; }
    }
}