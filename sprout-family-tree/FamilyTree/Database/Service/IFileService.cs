using FamilyTree.Database.Model;
using FamilyTree.ViewModel;
using System.Collections.Generic;

namespace FamilyTree.Database.Service
{
    public interface IFileService
    {
        IEnumerable<object> ParseFile(string fileName);

        IEnumerable<PersonViewModel> GetPeople(string fileName);
        
        IEnumerable<EventModel> GetEvents(string fileName);

        IEnumerable<AttendeeModel> GetAttendees(string fileName);

        IEnumerable<HairColorModel> GetHairColors();

        IEnumerable<EyeColorModel> GetEyeColors();

        void ExportFiles(IEnumerable<PersonViewModel> people);

        void ExportReadableFiles(IEnumerable<PersonViewModel> people);
    }
}