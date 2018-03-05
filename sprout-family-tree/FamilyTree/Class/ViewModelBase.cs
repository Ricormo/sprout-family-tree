using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FamilyTree.Class
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T fields, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(fields, value)) return false;
            fields = value;
            OnPropertyChanged(propertyName);
            return true;
        }        
    }
}