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
            throw new NotImplementedException();
        }

        public void ExportReadableFiles(IEnumerable<PersonViewModel> people)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonViewModel> GetPeople(string fileName)
        {
            var people = new List<PersonViewModel>
            {
                new PersonViewModel
                {
                    Id = 0,
                    FirstName = "John",
                    LastName = "Doe",
                    Sex = true,
                    Birth = new EventModel
                    {
                        Id = 0,
                        EventId = 0,
                        StartTime = new DateTime(1950, 6, 1)
                    }
                },
                new PersonViewModel
                {
                    Id = 1,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Sex = false,
                    Birth = new EventModel
                    {
                        Id = 0,
                        EventId = 0,
                        StartTime = new DateTime(1965, 7, 4)
                    }
                },
                new PersonViewModel
                {
                    Id = 2,
                    FirstName = "Janette",
                    LastName = "Doe",
                    Sex = false,
                    Birth = new EventModel
                    {
                        Id = 1,
                        EventId = 0,
                        StartTime = new DateTime(1990, 5, 25)
                    },
                    FatherId = 0,
                    MotherId = 1
                },
                new PersonViewModel
                {
                    Id = 6,
                    FirstName = "Joe",
                    LastName = "Smith",
                    Sex = true,
                    Birth = new EventModel
                    {
                        Id = 0,
                        EventId = 0,
                        StartTime = new DateTime(1985, 1, 1)
                    }
                },
                new PersonViewModel
                {
                    Id = 7,
                    FirstName = "Baby",
                    LastName = "Smith",
                    Sex = true,
                    Birth = new EventModel
                    {
                        Id = 0,
                        EventId = 0,
                        StartTime = new DateTime(2018, 1, 1)
                    },
                    FatherId = 6,
                    MotherId = 2
                }
            };







            return people;
        }

        public IEnumerable<EventModel> GetEvents(string fileName)
        {
            var events = new List<EventModel>
            {
                new EventModel
                {
                    Id = 0,
                    Name = "Best Day of Everyone's Life",
                    StartTime = new DateTime(1992, 1, 18)
                },
                new EventModel
                {
                    Id = 1,
                    Name = "Ice Cream Fair",
                    StartTime = new DateTime(1992, 1, 18),
                    EndTime = new DateTime(1992, 2, 18)
                }
            };



            return events;
        }

        public IEnumerable<AttendeeModel> GetAttendees(string fileName)
        {
            var attendees = new List<AttendeeModel>
            {
                new AttendeeModel
                {
                    EventId = 0,
                    PersonId = 2
                }
            };


            return attendees;
        }

        public IEnumerable<HairColorModel> GetHairColors()
        {
            var hairColors = new List<HairColorModel>
            {
                new HairColorModel
                {
                    Id = 0,
                    Color = "Black"
                },
                new HairColorModel
                {
                    Id = 1,
                    Color = "Brown"
                },
                new HairColorModel
                {
                    Id = 2,
                    Color = "Green"
                },
                new HairColorModel
                {
                    Id = 3,
                    Color = "Red"
                },
                new HairColorModel
                {
                    Id = 4,
                    Color = "Blonde"
                }
            };






            return hairColors;
        }

        public IEnumerable<EyeColorModel> GetEyeColors()
        {
            var eyeColors = new List<EyeColorModel>
            {
                new EyeColorModel
                {
                    Id = 0,
                    Color = "Brown"
                },
                new EyeColorModel
                {
                    Id = 1,
                    Color = "Hazel"
                },
                new EyeColorModel
                {
                    Id = 2,
                    Color = "Green"
                },
                new EyeColorModel
                {
                    Id = 3,
                    Color = "Blue"
                }
            };





            return eyeColors;
        }
    }
}