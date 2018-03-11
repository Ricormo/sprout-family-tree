using System;

namespace FamilyTree.Domain.Model
{
    public class EventModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public short EventTypeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public LocationModel Location { get; set; }
        public string Comment { get; set; }
    }
}