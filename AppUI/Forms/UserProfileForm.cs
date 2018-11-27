using BLL;
using BLL.Strings;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TradingCompany.DAL;
using UI;
using Unity;
using Unity.Resolution;

namespace AppUI.Forms
{
    public partial class UserProfileForm : Form
    {
        UserDTO _user;
        List<AddressDTO> _addresses;
        ActivatingDataDTO _activatingData;
        BlockingDataDTO _blockingData;

        UserBLL _userBL = new UserBLL();
        AddressBL _addressBL = new AddressBL();
        ActivatingDataBL _activatingDataBL = new ActivatingDataBL();
        BlockingDataBL _blockingDataBL = new BlockingDataBL();

        public UserProfileForm(UserDTO user)
        {
            InitializeComponent();

            _user = user;
            _addresses = _addressBL.GetByUserId(_user.UserId)?.Data;
            _activatingData = _activatingDataBL.GetDataByUser(user)?.Data;
            _blockingData = _blockingDataBL.GetDataByUser(user)?.Data;

            userDTOBindingSource.Add(_user);
            _addresses.ForEach(address => addressDTOBindingSource.Add(address));

            if (_blockingData != null)
            {
                blockingDataDTOBindingSource.Add(_blockingData);
            }
            if (_activatingData != null)
            {
                activatingDataDTOBindingSource.Add(_activatingData);
            }

            InitProfile();
            InitAddresses();
        }

        void InitAddresses()
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            foreach (var adr in _addresses)
            {
                var a = new ListViewItem(new[] 
                { adr.Country, adr.City, adr.Street, adr.HouseNumber.ToString(), adr.ZipCode });
          
                listView1.Items.Add(a);
            }
        }

        void InitProfile()
        {
            textBox1.Text = _user.FirstName;
            textBox2.Text = _user.LastName;
            textBox3.Text = _user.PhoneNumber;
            textBox4.Text = _user.Email;
            textBox5.Text = _user.DateOfBirth.ToString();
            textBox6.Text = _user.IsFemale == true ? "Female" : "Male";

            checkBox1.AutoCheck = false;

            checkBox1.Checked = _user.IsAdmin;
            checkBox2.Checked = _user.IsActivated;
            checkBox3.Checked = _user.IsBlocked;

            groupBox1.Visible = _user.IsActivated;
            groupBox2.Visible = _user.IsBlocked;

            button1.Visible = !_user.IsActivated;
            button2.Visible = !_user.IsBlocked;

            if (_activatingData != null)
            {
                var admin1 = _userBL.GetUserByID(_activatingData.AdminId).Data;
                textBox7.Text = admin1.FirstName + " " + admin1.LastName;
                label15.Text = _activatingData.ActivatingDate.ToString();
            }

            if (_blockingData != null)
            {
                var admin2 = _userBL.GetUserByID(_blockingData.AdminId).Data;
                textBox8.Text = admin2.FirstName + " " + admin2.LastName;
                textBox9.Text = _blockingData.Reason;
                textBox10.Text = _blockingData.TermInHours.ToString();
                checkBox4.Checked = _blockingData.BlockAndDelete ?? false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Hide();

            var menu = Program.Container.Resolve<AdministrationMenuForm>();
            menu.ShowDialog();

            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
            {
                var confirmActivationMessage = $"Are you sure you want to activate {_user.FirstName} {_user.LastName}?";

                var res = MessageBox.Show(confirmActivationMessage,
                    ErrorMessages.ConfirmationTitle, MessageBoxButtons.OKCancel);

                if (res == DialogResult.OK)
                {
                    _activatingData = new ActivatingDataDTO() { AdminId = 15, UserId = _user.UserId, ActivatingDate = DateTime.Now };
                    _user.IsActivated = true;

                    _userBL.UpdateActivatingData(_user, _activatingData);
                }
                if (res == DialogResult.Cancel)
                {
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!checkBox3.Checked)
            {
                var menu = Program.Container.Resolve<BlockingUserForm>(new ParameterOverride("user", _user));
                menu.ShowDialog();

                return;
            }
            if (checkBox3.Checked)
            {
                groupBox2.Visible = true;
                button2.Visible = false;
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
    }
}
