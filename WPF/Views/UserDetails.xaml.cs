using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF.Models;
using WPF.ViewModels;

namespace WPF.Views
{
    /// <summary>
    /// Interaction logic for UserDetails.xaml
    /// </summary>
    public partial class UserDetails : Window
    {
        private UserDetailsViewModel _viewModel;

        public User User {
            get;
            set;
        }

        public UserDetails(UserDetailsViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;

            User = _viewModel.User;

            InitializeComponent();
        }

        private void SaveButtonClicked(object sender, RoutedEventArgs e)
        {
            if (User.DateOfBirth.ToString() == "" ||
                User.FirstName == "" ||
                User.LastName == "" ||
                User.PhoneNumber == "" ||
                User.Email == "")
            {
                var message = "Values cannot be empty";
                var title = "Error";

                var result = MessageBox.Show(message, title, MessageBoxButton.OK);
            }
        }

        private void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            var message = "Are you sure you want to exit editing mode?";
            var title = "Warning";

            var result = MessageBox.Show(message, title, MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                Close();
            }
        }

        private void IsActivatedCheckboxTouchEntered(object sender, RoutedEventArgs e)
        {
            var isActivated = ((CheckBox)sender).IsChecked;
        }

        private void IsBlockedCheckboxTouchEntered(object sender, RoutedEventArgs e)
        {

        }
    }
}
