using System;
using System.ComponentModel;

namespace WPF.Models
{
    public class User : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _email;
        private DateTime? _dateOfBirth;
        private bool _isActivated;
        private bool _isBlocked;

        public int UserId { get; set; }
        public string Password { get; set; }
        public string KeyPasswordWord { get; set; }
        public bool? IsFemale { get; set; }
        public string CardNumber { get; set; }
        public bool IsAdmin { get; set; }

        public string FirstName {
            get { return _firstName; }
            set {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName {
            get { return _lastName; }
            set {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string PhoneNumber {
            get { return _phoneNumber; }
            set {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public string Email {
            get { return _email; }
            set {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public DateTime? DateOfBirth {
            get { return _dateOfBirth; }
            set {
                _dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }

        public bool IsActivated {
            get { return _isActivated; }
            set {
                _isActivated = value;
                OnPropertyChanged(nameof(IsActivated));
            }
        }
        public bool IsBlocked {
            get { return _isBlocked; }
            set {
                _isBlocked = value;
                OnPropertyChanged(nameof(IsBlocked));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
