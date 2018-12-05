using AutoMapper;
using BLL;
using DTO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using WPF.Models;

namespace WPF.ViewModels
{
    public class UserListViewModel : INotifyPropertyChanged
    {
        private UserBLL _clerk;
        private IMapper _mapper;
        private ObservableCollection<User> _userList;

        public ObservableCollection<User> UserList {
            get { return _userList; }
            set {
                _userList = value;
                OnPropertyChanged(nameof(UserList));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public UserListViewModel()
        {
            _clerk = new UserBLL();
            _mapper = new Mapper(
            new MapperConfiguration(c => c.AddProfiles(typeof(List<UserDTO>), typeof(List<User>))));

            Update();
        }

        public void Update()
        {
            var users = _mapper.Map<List<User>>(_clerk.GetAllUsers().Data);
            UserList = new ObservableCollection<User>(users);
        }
    }
}