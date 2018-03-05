using System;
using System.Collections.Generic;
using FamilyTree.Database.Model;
using FamilyTree.ViewModel;

namespace FamilyTree.Database.Service
{
    public class FileService : IFileService
    {
        public IEnumerable<object> ParseFile(string fileName)
        {
            return null;
        }

        public void ExportFiles(IEnumerable<PersonViewModel> people)
        {
            throw new System.NotImplementedException();
        }

        public void ExportReadableFiles(IEnumerable<PersonViewModel> people)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PersonViewModel> GetPeople(string fileName)
        {
            var people = new List<PersonViewModel>();

            people.Add(new PersonViewModel
            {
                Id = 0,
                FirstName = "John",
                LastName = "Doe",
                Sex = true,
                Birth = new EventModel
                {
                    Id = 0,
                    EventId = 0,
                    StartTime = new System.DateTime(1950, 6, 1)
                }
            });

            people.Add(new PersonViewModel
            {
                Id = 1,
                FirstName = "Jane",
                LastName = "Doe",
                Sex = false,
                Birth = new EventModel
                {
                    Id = 0,
                    EventId = 0,
                    StartTime = new System.DateTime(1965, 7, 4)
                }
            });

            people.Add(new PersonViewModel
            {
                Id = 2,
                FirstName = "Janette",
                LastName = "Doe",
                Sex = false,
                Birth = new EventModel
                {
                    Id = 1,
                    EventId = 0,
                    StartTime = new System.DateTime(1990, 5, 25)
                },
                FatherId = 0,
                MotherId = 1
            });
            
            people.Add(new PersonViewModel
            {
                Id = 6,
                FirstName = "Joe",
                LastName = "Smith",
                Sex = true,
                Birth = new EventModel
                {
                    Id = 0,
                    EventId = 0,
                    StartTime = new System.DateTime(1985, 1, 1)
                }
            });

            people.Add(new PersonViewModel
            {
                Id = 7,
                FirstName = "Baby",
                LastName = "Smith",
                Sex = true,
                Birth = new EventModel
                {
                    Id = 0,
                    EventId = 0,
                    StartTime = new System.DateTime(2018, 1, 1)
                },
                FatherId = 6,
                MotherId = 2
            });


            return people;
        }

        public IEnumerable<EventModel> GetEvents(string fileName)
        {
            var events = new List<EventModel>();
            
            events.Add(new EventModel
            {
                Id = 0,
                Name = "Best Day of Everyone's Life",
                StartTime = new DateTime(1992, 1, 18)
            });

            events.Add(new EventModel
            {
                Id = 1,
                Name = "Ice Cream Fair",
                StartTime = new DateTime(1992, 1, 18),
                EndTime = new DateTime(1992, 2, 18)
            });

            return events;
        }

        public IEnumerable<AttendeeModel> GetAttendees(string fileName)
        {
            var attendees = new List<AttendeeModel>();

            attendees.Add(new AttendeeModel
            {
                EventId = 0,
                PersonId = 2
            });

            return attendees;
        }
    }
}