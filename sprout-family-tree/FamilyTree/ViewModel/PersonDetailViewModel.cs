using System.Collections.ObjectModel;
using FamilyTree.Class;
using FamilyTree.Domain.Model;

namespace FamilyTree.ViewModel
{
    public class PersonDetailViewModel : ViewModelBase
    {
        public PersonModel Person
        {
            get => _person;
            set => SetField(ref _person, value);
        }
        private PersonModel _person = new PersonModel();

        public ObservableCollection<EventModel> Events
        {
            get => _events;
            set => SetField(ref _events, value);
        }
        private ObservableCollection<EventModel> _events = new ObservableCollection<EventModel>();

        public PersonModel Father
        {
            get => _father;
            set => SetField(ref _father, value);
        }
        private PersonModel _father = new PersonModel();

        public PersonModel Mother
        {
            get => _mother;
            set => SetField(ref _mother, value);
        }
        private PersonModel _mother = new PersonModel();

        public ObservableCollection<PersonModel> Children
        {
            get => _children;
            set => SetField(ref _children, value);
        }
        private ObservableCollection<PersonModel> _children = new ObservableCollection<PersonModel>();

    }
}
