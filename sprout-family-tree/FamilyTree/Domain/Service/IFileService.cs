using System.Collections.Generic;
using FamilyTree.Domain.Model;
using FamilyTree.ViewModel;

namespace FamilyTree.Domain.Service
{
    public interface IFileService
    {
        IEnumerable<PersonModel> GetPeople();
        IEnumerable<EventModel> GetEvents();
        IEnumerable<EventTypeModel> GetEventTypes();
        IEnumerable<AttendeeModel> GetAttendees();
        IEnumerable<HairColorModel> GetHairColors();
        IEnumerable<EyeColorModel> GetEyeColors();

        void SaveFamilyTreeLocally(IEnumerable<PersonViewModel> people);
        void SavePeopleLocally(IEnumerable<PersonModel> people);
        void SaveEventTypesLocally(IEnumerable<EventTypeModel> eventTypes);
        void SaveAttendeesLocally(IEnumerable<AttendeeModel> attendees);
        void SaveHairColorsLocally(IEnumerable<HairColorModel> hairColors);
        void SaveEyeColorsLocally(IEnumerable<EyeColorModel> eyeColors);
    }
}