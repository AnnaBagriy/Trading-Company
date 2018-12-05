using AutoMapper;
using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Models;

namespace WPF.ViewModels
{
    public class UserDetailsViewModel : INotifyPropertyChanged
    {
        private IMapper _mapper;
        private UserBLL _userBLL;
        private User _user;

        public User User {
            get { return _user; }
            set {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public UserDetailsViewModel(User user)
        {
            _user = user;
            _userBLL = new UserBLL();
            _mapper = new Mapper(
                new MapperConfiguration(c => c.AddProfiles(typeof(User), typeof(UserDTO))));
        }

        internal void SaveUser(User user)
        {
            var mappedUser = _mapper.Map<UserDTO>(user);

            if (_user == null)
            {
                _userBLL.UpdateUser(mappedUser);
            }
            else
            {
                _userBLL.AddUser(mappedUser);
            }
        }
    }
}
