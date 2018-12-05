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
using Unity;
using Unity.Container;
using Unity.Resolution;

namespace WPF.Views
{
    /// <summary>
    /// Interaction logic for UserList.xaml
    /// </summary>
    public partial class UserList : Window
    {
        public UserListViewModel _viewModel;
        CollectionViewSource _userCollection;

        public UserList(UserListViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();

            _userCollection = (CollectionViewSource)(Resources["UserCollection"]);
            _userCollection.Filter += _userCollection_Filter;
        }

        private void _userCollection_Filter(object sender, FilterEventArgs e)
        {
            var filter = txtFilter.Text;
            var user = e.Item as User;
            if (user.FirstName.Contains(filter) || user.LastName.Contains(filter))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        private void dgStudents_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            var item = (User)grid.SelectedItem;
            var detailsViewModel = App.Container.Resolve<UserDetailsViewModel>(new ParameterOverride("user", item));
            UserDetails sdView = new UserDetails(detailsViewModel);
            sdView.ShowDialog();
            if (sdView.DialogResult.HasValue && sdView.DialogResult.Value)
            {
                _viewModel.Update();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _userCollection.View.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var detailsViewModel = App.Container.Resolve<UserDetailsViewModel>();
            UserDetails sdView = new UserDetails(detailsViewModel);
            sdView.ShowDialog();
            if (sdView.DialogResult.HasValue && sdView.DialogResult.Value)
            {
                _viewModel.Update();
            }
        }
    }
}
