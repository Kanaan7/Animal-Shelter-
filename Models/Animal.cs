
using System.ComponentModel;

namespace Assignment2._1.Models
{
    public class Animal : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _type;
        private int _age;
        private string _gender;
        private string _description;
        private bool _isAdopted;

        public int Id
        {
            get => _id;
            set
            {
                if (_id == value) return;
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Type
        {
            get => _type;
            set
            {
                if (_type == value) return;
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (_age == value) return;
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public string Gender
        {
            get => _gender;
            set
            {
                if (_gender == value) return;
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (_description == value) return;
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public bool IsAdopted
        {
            get => _isAdopted;
            set
            {
                if (_isAdopted == value) return;
                _isAdopted = value;
                OnPropertyChanged(nameof(IsAdopted));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
