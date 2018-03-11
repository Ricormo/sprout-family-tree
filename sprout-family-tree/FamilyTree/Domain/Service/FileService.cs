using System;
using System.Collections.Generic;
using System.IO;
using FamilyTree.Domain.Model;
using FamilyTree.ViewModel;
using Newtonsoft.Json;

namespace FamilyTree.Domain.Service
{
    public class FileService : IFileService
    {
        #region Local Saving

        public void SaveFamilyTreeLocally(IEnumerable<PersonViewModel> people)
        {
            WriteTextAsync(
                JsonConvert.SerializeObject(people, Formatting.Indented),
                "FamilyTree.txt");
        }

        public void SavePeopleLocally(IEnumerable<PersonModel> people)
        {
            WriteTextAsync(
                JsonConvert.SerializeObject(people),
                "People.txt");
        }

        public void SaveEventTypesLocally(IEnumerable<EventTypeModel> eventTypes)
        {
            WriteTextAsync(
                JsonConvert.SerializeObject(eventTypes),
                "EventTypes.txt");
        }

        public void SaveAttendeesLocally(IEnumerable<AttendeeModel> attendees)
        {
            WriteTextAsync(
                JsonConvert.SerializeObject(attendees),
                "EventTypes.txt");
        }

        public void SaveHairColorsLocally(IEnumerable<HairColorModel> hairColors)
        {
            WriteTextAsync(
                JsonConvert.SerializeObject(hairColors),
                "HairColors.txt");
        }

        public void SaveEyeColorsLocally(IEnumerable<EyeColorModel> eyeColors)
        {
            WriteTextAsync(
                JsonConvert.SerializeObject(eyeColors),
                "EyeColors.txt");
        }

        private static async void WriteTextAsync(string text, string fileName)
        {
            var filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "SproutData");

            Directory.CreateDirectory(filePath);

            filePath = Path.Combine(filePath, fileName);

            if (File.Exists(filePath))
                File.Delete(filePath);

            using (var outputFile = new StreamWriter(filePath))
            {
                await outputFile.WriteAsync(text);
            }
        }

        #endregion

        #region Local Loading

        public IEnumerable<PersonModel> GetPeople()
        {
            return new List<PersonModel>
            {
                new PersonModel
                {
                    Id = 0,
                    FirstName = "John",
                    LastName = "Doe",
                    Sex = true,
                    BirthDate = new DateTime(1950, 6, 1)
                },
                new PersonModel
                {
                    Id = 1,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Sex = false
                },
                new PersonModel
                {
                    Id = 2,
                    FirstName = "Janette",
                    LastName = "Doe",
                    Sex = false,
                    FatherId = 0,
                    MotherId = 1
                },
                new PersonModel
                {
                    Id = 6,
                    FirstName = "Joe",
                    LastName = "Smith",
                    Sex = true
                },
                new PersonModel
                {
                    Id = 7,
                    FirstName = "Baby",
                    LastName = "Smith",
                    Sex = true,
                    FatherId = 6,
                    MotherId = 2
                }
            };
        }

        public IEnumerable<EventModel> GetEvents()
        {
            return new List<EventModel>
            {
                new EventModel
                {
                    Id = 0,
                    EventTypeId = 0,
                    Name = "John Doe's Birth",
                    StartTime = new DateTime(1950, 6, 1)
                },
                new EventModel
                {
                    Id = 1,
                    EventTypeId = 0,
                    Name = "Jane Doe's Birth",
                    StartTime = new DateTime(1960, 7, 13)
                },
                new EventModel
                {
                    Id = 2,
                    EventTypeId = 0,
                    Name = "Janette Doe's Birth",
                    StartTime = new DateTime(1985, 5, 30),
                    Location = new LocationModel
                    {
                        City = "Milwaukee",
                        State = "WI",
                        Country = "USA"
                    }

                },
                new EventModel
                {
                    Id = 3,
                    EventTypeId = 0,
                    Name = "Joe Smith's Birth",
                    StartTime = new DateTime(1980, 12, 1)
                },
                new EventModel
                {
                    Id = 4,
                    EventTypeId = 0,
                    Name = "Baby Smith's Birth",
                    StartTime = new DateTime(2010, 3, 25)
                },
                new EventModel
                {
                    Id = 5,
                    EventTypeId = 2,
                    Name = "Family Reunion",
                    StartTime = new DateTime(2010, 3, 25),
                    EndTime = new DateTime(2010, 3, 26)
                }
            };
        }

        public IEnumerable<EventTypeModel> GetEventTypes()
        {
            return new List<EventTypeModel>
            {
                new EventTypeModel
                {
                    Id = 0,
                    EventType = "Birth"
                },
                new EventTypeModel
                {
                    Id = 1,
                    EventType = "Death"
                },
                new EventTypeModel
                {
                    Id = 2,
                    EventType = "Family Reunion"
                }
            };
        }

        public IEnumerable<AttendeeModel> GetAttendees()
        {
            return new List<AttendeeModel>
            {
                new AttendeeModel
                {
                    EventId = 0,
                    PersonId = 0
                },
                new AttendeeModel
                {
                    EventId = 1,
                    PersonId = 1
                },
                new AttendeeModel
                {
                    EventId = 2,
                    PersonId = 0
                },
                new AttendeeModel
                {
                    EventId = 2,
                    PersonId = 1
                },
                new AttendeeModel
                {
                    EventId = 2,
                    PersonId = 2
                },
                new AttendeeModel
                {
                    EventId = 3,
                    PersonId = 6
                },
                new AttendeeModel
                {
                    EventId = 4,
                    PersonId = 5
                },
                new AttendeeModel
                {
                    EventId = 4,
                    PersonId = 6
                },
                new AttendeeModel
                {
                    EventId = 4,
                    PersonId = 7
                },
                new AttendeeModel
                {
                    EventId = 5,
                    PersonId = 0
                },
                new AttendeeModel
                {
                    EventId = 5,
                    PersonId = 1
                },
                new AttendeeModel
                {
                    EventId = 5,
                    PersonId = 2
                },
                new AttendeeModel
                {
                    EventId = 5,
                    PersonId = 3
                },
                new AttendeeModel
                {
                    EventId = 5,
                    PersonId = 4
                },
                new AttendeeModel
                {
                    EventId = 5,
                    PersonId = 5
                },
                new AttendeeModel
                {
                    EventId = 5,
                    PersonId = 6
                }
            };
        }

        public IEnumerable<HairColorModel> GetHairColors()
        {
            return new List<HairColorModel>
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
        }

        public IEnumerable<EyeColorModel> GetEyeColors()
        {
            return new List<EyeColorModel>
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
        }

        #endregion

    }
}