using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDepartment.CommonLibrary
{
    internal class Person : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _displayName;
        private string? _position;
        private string? _email;
        private string _department;

        public Person(string firstName, string lastName, string displayName, string? position, string email, string department)
        {
            _firstName = firstName;
            _lastName = lastName;
            _displayName = displayName;
            _position = position;
            _email = email;
            _department = department;
            TitleBefore = SetTitleBefore(); // tieto by mali niekedy vracat aj null ale zatial nevracaju nikdy null, ked tak potom odstranit, aj vsetky ostatne argumenty
            TitleAfter = SetTitleAfter();

        }

        public string FirstName 
        {   
            get => _firstName;
            set 
            {   
                _firstName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_firstName)));
            }
        
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_lastName)));
            }

        }
        public string DisplayName
        {
            get => _displayName;
            set
            {
                _displayName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_displayName)));
            }

        }
        public readonly string? TitleBefore;
        public readonly string? TitleAfter;
        public string Position
        {
            get
            {
                if (_position == null)
                {
                    return "undefined Position";
                }
                return _position;
            }
            set
            {
                _position = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_position)));
            }

        }
        public string Email
        {
            get
            {
                if (_email == null)
                {
                    return "undefined email";
                }
                return _email;
            }
            set
            {
                _email = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_email)));
            }

        }
        public string Department
        {
            get => _department;
            set
            {
                _department = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_department)));
            }

        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public string ToFormattedString() 
        {
            return $"{DisplayName, -40}{Email}";
        }
        private string SetTitleBefore() {
            string[] slices = DisplayName.Split(' ');
            int indexOfName = 0;
            for (int i = 0; i < slices.Length; i++)
            {
                if (slices[i] == FirstName)
                {

                    indexOfName = i + 1;
                    break;
                }
            }
            return String.Join(' ', slices[0..indexOfName]); // https://learn.microsoft.com/en-us/dotnet/api/system.string.join?view=net-9.0

        }
        private string SetTitleAfter()
        {
            string[] slices = DisplayName.Split(' ');
            if (slices[^1] == LastName) return "";
            int indexOfName = slices.Length - 1;
            for (int i = slices.Length - 1; i >= 0; i--)
            {
                if (slices[i] == LastName + ",")
                {
                    indexOfName = i;
                    break;
                }
            }
            return String.Join(' ', slices[indexOfName..]); // https://learn.microsoft.com/en-us/dotnet/api/system.string.join?view=net-9.0
        }
    }
}
