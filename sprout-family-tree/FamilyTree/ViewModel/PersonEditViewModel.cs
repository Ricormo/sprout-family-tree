using System.Collections.Generic;
using System.Collections.ObjectModel;
using FamilyTree.Class;
using FamilyTree.Domain.Model;

namespace FamilyTree.ViewModel
{
    public class PersonEditViewModel : ViewModelBase
    {
        public PersonModel Person
        {
            get => _person;
            set => SetField(ref _person, value);
        }
        private PersonModel _person = new PersonModel();

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

        public ObservableCollection<PersonViewModel> Children
        {
            get => _children;
            set => SetField(ref _children, value);
        }
        private ObservableCollection<PersonViewModel> _children = new ObservableCollection<PersonViewModel>();

        public List<HairColorModel> HairColors
        {
            get => _hairColors;
            set => SetField(ref _hairColors, value);
        }
        private List<HairColorModel> _hairColors = new List<HairColorModel>();

        public List<EyeColorModel> EyeColors
        {
            get => _eyeColors;
            set => SetField(ref _eyeColors, value);
        }
        private List<EyeColorModel> _eyeColors = new List<EyeColorModel>();

    }
}