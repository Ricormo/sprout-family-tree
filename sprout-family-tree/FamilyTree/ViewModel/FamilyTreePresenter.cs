﻿using FamilyTree.Class;
using FamilyTree.Database.Model;
using FamilyTree.Database.Service;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Input;

namespace FamilyTree.ViewModel
{
    public class FamilyTreePresenter : ViewModelBase
    {
        private IFileService _fileService;

        public FamilyTreePresenter(IFileService fileService)
        {
            _fileService = 
                fileService ?? throw new ArgumentNullException(nameof(fileService));

            LoadData();
            SelectedPerson = People.FirstOrDefault();
        }

        private void LoadData()
        {
            People = new ObservableCollection<PersonViewModel>(_fileService.GetPeople(""));
            Events = new ObservableCollection<EventModel>(_fileService.GetEvents(""));
            Attendees = _fileService.GetAttendees("").ToList();
        }

        private void InitializePerson()
        {
            var eventIds = Attendees
                .Where(a => a.PersonId == SelectedPerson.Id)
                .Select(a => a.EventId).ToList();

            SelectedPerson.Events = Events
                .Where(e => eventIds.Contains(e.EventId))
                .OrderBy(e => e.StartTime).ToList();

            var parents = People
                .Where(p =>
                    p.Id == SelectedPerson.FatherId
                    || p.Id == SelectedPerson.MotherId)
                    .ToList();

            var children = People
                .Where(p =>
                    p.FatherId == SelectedPerson.Id
                    || p.MotherId == SelectedPerson.Id)
                    .ToList();

            var childrenParents = children
                .SelectMany(c => new List<long?> { c.MotherId, c.FatherId })
                .Where(p => p != SelectedPerson.Id)
                .Distinct();

            var partners = People
                .Where(p => childrenParents.Contains(p.Id)).ToList();
        }

        private void AddPerson()
        {
            EditedPerson = new PersonViewModel();
            IsAddingPerson = true;
            IsEditingPerson = true;
        }

        private void EditPerson()
        {
            EditedPerson = new PersonViewModel
            {
                Id = SelectedPerson.Id,
                FirstName = SelectedPerson.FirstName,
                LastName = SelectedPerson.LastName,
                Sex = SelectedPerson.Sex,
                Appearance = SelectedPerson.Appearance,
                Birth = SelectedPerson.Birth,
                Death = SelectedPerson.Death,
                Events = SelectedPerson.Events,
                FatherId = SelectedPerson.FatherId,
                MotherId = SelectedPerson.MotherId,
                Family = SelectedPerson.Family
            };
            IsEditingPerson = true;
        }

        private void SavePerson()
        {
            if (IsAddingPerson)
            {
                SelectedPerson = EditedPerson;
                People.Add(SelectedPerson);
            }
            else
                SelectedPerson = EditedPerson;

            IsEditingPerson = false;
            IsAddingPerson = false;
        }

        private void CancelSave()
        {
            IsEditingPerson = false;
        }

        public void HandleFilesDrop(string[] files)
        {
            foreach (var file in files)
            {
                _fileService.ParseFile(file);
            }            
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

        public ObservableCollection<PersonViewModel> People
        {
            get => _people;
            set => SetField(ref _people, value);
        }
        private ObservableCollection<PersonViewModel> _people = new ObservableCollection<PersonViewModel>();

        public PersonViewModel SelectedPerson
        {
            get => _selectedPerson;
            set {
                SetField(ref _selectedPerson, value);
                InitializePerson();
            }
        }
        private PersonViewModel _selectedPerson = new PersonViewModel();

        public PersonViewModel EditedPerson
        {
            get => _editedPerson;
            set
            {
                SetField(ref _editedPerson, value);
                InitializePerson();
            }
        }
        private PersonViewModel _editedPerson = new PersonViewModel();

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
            (_addPersonCommand ?? new CommandHandler(() => AddPerson(), true));
        private ICommand _addPersonCommand;

        public ICommand EditPersonCommand =>
            (_editPersonCommand ?? new CommandHandler(() => EditPerson(), true));
        private ICommand _editPersonCommand;

        public ICommand SavePersonCommand =>
            (_savePersonCommand ?? new CommandHandler(() => SavePerson(), true));
        private ICommand _savePersonCommand;

        public ICommand CancelSaveCommand =>
            (_cancelSaveCommand ?? new CommandHandler(() => CancelSave(), true));
        private ICommand _cancelSaveCommand;
    }
}