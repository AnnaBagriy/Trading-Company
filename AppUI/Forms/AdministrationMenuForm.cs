using AppUI.Forms;
using BLL;
using BLL.Strings;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UI;
using Unity;
using Unity.Resolution;

namespace AppUI
{
    public partial class AdministrationMenuForm : Form
    {
        private UserBLL _userBLL;
        private List<UserDTO> users;

        public AdministrationMenuForm()
        {
            InitializeComponent();

            _userBLL = new UserBLL();

            users = _userBLL.GetAllUsers().Data;
            users.ForEach(user => userDTOBindingSource.Add(user));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            userDTOBindingSource.Clear();

            userDTOBindingSource.Add(sender as UserDTO);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                if (userDTOBindingSource.List != users)
                {
                    userDTOBindingSource.Clear();
                    users.ForEach(user => userDTOBindingSource.Add(user));
                }

                return;
            }

            var u = _userBLL.GetUsersByPersonalData(searchTextBox.Text).Data;

            userDTOBindingSource.Clear();
            u.ForEach(user => userDTOBindingSource.Add(user));
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            var selectedUser = users.ElementAt(dataGridView1.SelectedRows[0].Index);

            userDTOBindingSource.Clear();
            userDTOBindingSource.Add(selectedUser);

            if (selectedUser != null)
            {
                Hide();

                var menu = Program.Container.Resolve<UserProfileForm>(new ParameterOverride("user", selectedUser));
                menu.ShowDialog();

                return;
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show(ErrorMessages.ConfirmSignOut, ErrorMessages.SignOutTitle, MessageBoxButtons.OKCancel);

            if (res == DialogResult.OK)
            {
                Hide();

                var menu = Program.Container.Resolve<SignInForm>();
                menu.ShowDialog();

                return;
            }
            else
            {
                return;
            }
        }

        #region Sorting

        private void OrderColumns(string sortingKey, string orderBy = "asc")
        {
            if (orderBy == "asc")
            {
                userDTOBindingSource.DataSource = users.OrderBy(s => s.GetType()?.GetProperty(sortingKey)?.GetValue(s)).ToList();
            }
            else
            {
                userDTOBindingSource.DataSource = users.OrderByDescending(s => s.GetType()?.GetProperty(sortingKey)?.GetValue(s)).ToList();
            }

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            OrderColumns("FirstName", "asc");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            OrderColumns("FirstName", "des");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            OrderColumns("LastName", "asc");
        }

        private void label11_Click(object sender, EventArgs e)
        {
            OrderColumns("LastName", "des");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            OrderColumns("Email", "asc");
        }

        private void label15_Click(object sender, EventArgs e)
        {
            OrderColumns("Email", "des");
        }

        private void label6_Click(object sender, EventArgs e)
        {
            OrderColumns("DateOfBirth", "asc");
        }

        private void label16_Click(object sender, EventArgs e)
        {
            OrderColumns("DateOfBirth", "des");
        }

        private void label7_Click(object sender, EventArgs e)
        {
            OrderColumns("IsFemale", "asc");
        }

        private void label14_Click(object sender, EventArgs e)
        {
            OrderColumns("IsFemale", "des");
        }

        private void label8_Click(object sender, EventArgs e)
        {
            OrderColumns("IsAdmin", "asc");
        }

        private void label13_Click(object sender, EventArgs e)
        {
            OrderColumns("IsAdmin", "des");
        }

        private void label9_Click(object sender, EventArgs e)
        {
            OrderColumns("IsActivated", "asc");
        }

        private void label18_Click(object sender, EventArgs e)
        {
            OrderColumns("IsActivated", "des");
        }

        private void label10_Click(object sender, EventArgs e)
        {
            OrderColumns("IsBlocked", "asc");
        }

        private void label17_Click(object sender, EventArgs e)
        {
            OrderColumns("IsBlocked", "des");
        }

        #endregion
    }
}
