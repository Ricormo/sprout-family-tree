using FamilyTree.Class;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using AutoMapper;
using FamilyTree.Domain.Model;
using FamilyTree.Domain.Service;

namespace FamilyTree.ViewModel
{
    public class FamilyTreePresenter : ViewModelBase
    {
        private readonly IFileService _fileService;

        public FamilyTreePresenter(IFileService fileService)
        {
            _fileService =
                fileService ?? throw new ArgumentNullException(nameof(fileService));

            LoadData();
            SelectedPerson = People.FirstOrDefault();
            InitializePerson(SelectedPerson);
        }

        public PersonDetailViewModel DetailViewModel
        {
            get => _detailViewModel;
            set => SetField(ref _detailViewModel, value);
        }
        private PersonDetailViewModel _detailViewModel = new PersonDetailViewModel();

        public PersonEditViewModel EditViewModel
        {
            get => _editViewModel;
            set => SetField(ref _editViewModel, value);
        }
        private PersonEditViewModel _editViewModel = new PersonEditViewModel();

        private PersonViewModel InitializePerson(PersonModel person)
        {
            var selectedPerson = Mapper.Map<PersonModel, PersonViewModel>(person);
            DetailViewModel.Person = person;

            var eventIds = Attendees
                .Where(a => a.PersonId == selectedPerson.Id)
                .Select(a => a.EventId).Distinct();
            selectedPerson.Events = Events
                .Where(e => eventIds.Contains(e.Id))
                .OrderBy(e => e.StartTime).ToList();
            DetailViewModel.Events = new ObservableCollection<EventModel>(Events
                .Where(e => eventIds.Contains(e.Id))
                .OrderBy(e => e.StartTime).ToList());


            var father = People
                .FirstOrDefault(p => p.Id == SelectedPerson.FatherId);

            DetailViewModel.Father = father;
            EditViewModel.Father = father;

            var mother = People
                .FirstOrDefault(p => p.Id == SelectedPerson.MotherId);

            DetailViewModel.Mother = mother;
            EditViewModel.Mother = mother;

            var children = People
                .Where(p =>
                    p.FatherId == SelectedPerson.Id
                    || p.MotherId == SelectedPerson.Id)
                .ToList();

            DetailViewModel.Children = new ObservableCollection<PersonModel>(children);

            //    var childrenParents = children
            //        .SelectMany(c => new List<long?> { c.MotherId, c.FatherId })
            //        .Where(p => p != SelectedPerson.Id)
            //        .Distinct();

            //    var partners = People
            //        .Where(p => childrenParents.Contains(p.Id)).ToList();

            //    //Children = new ObservableCollection<PersonViewModel>(People
            //    //    .Where(p =>
            //    //        p.FatherId == SelectedPerson.Id
            //    //        || p.MotherId == SelectedPerson.Id)
            //    //    .ToList());
            //}

            return selectedPerson;
        }

        private void LoadData()
        {
            Events = new ObservableCollection<EventModel>(_fileService.GetEvents());
            Attendees = _fileService.GetAttendees().ToList();
            EditViewModel.EyeColors = _fileService.GetEyeColors().ToList();
            EditViewModel.HairColors = _fileService.GetHairColors().ToList();
            People = new ObservableCollection<PersonModel>(_fileService.GetPeople().ToList());
        }
        
        private void SaveDataLocally()
        {
            foreach (var person in People)
            {
                //InitializePerson(person);
            }
            //_fileService.SaveFamilyTreeLocally(People);
            _fileService.SavePeopleLocally(People
                .Select(p => new PersonModel
                {
                    Id = p.Id,
                    Appearance = p.Appearance,
                    FatherId = p.FatherId,
                    MotherId = p.MotherId
                }));
        }

        public void HandleFilesDrop(string[] files)
        {
            foreach (var file in files)
            {
                //_fileService.ParseFile(file);
            }
        }




        private void AddPerson()
        {
            EditViewModel.Person = new PersonModel();
            IsAddingPerson = true;
            IsEditingPerson = true;
        }

        private void EditPerson()
        {
            EditViewModel.Person = People
                .FirstOrDefault(p => p.Id == SelectedPerson.Id);
            IsEditingPerson = true;
        }

        private void SavePerson()
        {
            if (IsAddingPerson)
                People.Add(EditViewModel.Person);

            SelectedPerson = EditViewModel.Person;
            //DetailViewModel.Person = EditViewModel.Person;
            InitializePerson(EditViewModel.Person);
            IsEditingPerson = false;
            IsAddingPerson = false;
        }

        private void CancelSave()
        {
            IsEditingPerson = false;
        }

        public bool IsEditingPerson
        {
            get => _isEditingPerson;
            set => SetField(ref _isEditingPerson, value);
        }
        private bool _isEditingPerson;

        public bool IsAddingPerson
        {
            get => _isAddingPerson;
            set => SetField(ref _isAddingPerson, value);
        }
        private bool _isAddingPerson;

        public ObservableCollection<PersonViewModel> PeopleList
        {
            get => _peopleList;
            set => SetField(ref _peopleList, value);
        }
        private ObservableCollection<PersonViewModel> _peopleList = new ObservableCollection<PersonViewModel>();

        public ObservableCollection<PersonModel> People
        {
            get => _people;
            set => SetField(ref _people, value);
        }
        private ObservableCollection<PersonModel> _people = new ObservableCollection<PersonModel>();

        public PersonModel SelectedPerson
        {
            get => _selectedPerson;
            set {
                SetField(ref _selectedPerson, value);
                InitializePerson(People.FirstOrDefault(p => p.Id == value.Id));
            }
        }
        private PersonModel _selectedPerson = new PersonModel();

        public List<AttendeeModel> Attendees
        {
            get => _attendees;
            set => SetField(ref _attendees, value);
        }
        private List<AttendeeModel> _attendees = new List<AttendeeModel>();

        public ObservableCollection<EventModel> Events
        {
            get => _events;
            set => SetField(ref _events, value);
        }
        private ObservableCollection<EventModel> _events = new ObservableCollection<EventModel>();
        
        public EventModel SelectedEvent
        {
            get => _selectedEvent;
            set => SetField(ref _selectedEvent, value);
        }
        private EventModel _selectedEvent = new EventModel();
        
        public ICommand AddPersonCommand =>
            _addPersonCommand ?? new CommandHandler(AddPerson, true);
        private readonly ICommand _addPersonCommand;

        public ICommand EditPersonCommand =>
            _editPersonCommand ?? new CommandHandler(EditPerson, true);
        private readonly ICommand _editPersonCommand;

        public ICommand SavePersonCommand =>
            _savePersonCommand ?? new CommandHandler(SavePerson, true);
        private readonly ICommand _savePersonCommand;

        public ICommand CancelSaveCommand =>
            _cancelSaveCommand ?? new CommandHandler(CancelSave, true);
        private readonly ICommand _cancelSaveCommand;
    }
}