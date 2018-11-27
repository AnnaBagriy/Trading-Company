using BLL;
using BLL.Strings;
using DTO;
using System;
using System.Drawing;
using System.Windows.Forms;
using TradingCompany.DAL;

namespace AppUI
{
    public partial class BlockingUserForm : Form
    {
        #region Common UI

        private readonly Color TextBoxErrorBackColor = Color.Maroon;
        private readonly Color TextBoxDefaultBackColor = Color.White;

        #endregion

        BlockingDataDTO _blockingDataDTO;
        UserDTO _user;

        UserBLL _userBLL = new UserBLL();

        public BlockingUserForm(UserDTO user)
        {
            InitializeComponent();

            _user = user;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(reasonTextBox.Text) &&!string.IsNullOrWhiteSpace(termTextBox.Text))
            {
                reasonTextBox.BackColor = TextBoxErrorBackColor;
            }
            else if (string.IsNullOrWhiteSpace(termTextBox.Text)&&!string.IsNullOrWhiteSpace(reasonTextBox.Text))
            {
                termTextBox.BackColor = TextBoxErrorBackColor;
            }
            else if(string.IsNullOrWhiteSpace(reasonTextBox.Text)&& string.IsNullOrWhiteSpace(termTextBox.Text))
            {
                reasonTextBox.BackColor = TextBoxErrorBackColor;
                termTextBox.BackColor = TextBoxErrorBackColor;
            }
            else
            {
                int term = 0;
                var isSuccess = int.TryParse(termTextBox.Text, out term);

                if (isSuccess)
                {
                    var confirmBlockingTitle = $"Are you sure you want to block {_user.FirstName} {_user.LastName}?";
                    var res = MessageBox.Show(confirmBlockingTitle,
                         ErrorMessages.ConfirmationTitle, MessageBoxButtons.OK);

                    if (res == DialogResult.OK)
                    {
                        _blockingDataDTO = new BlockingDataDTO()
                        {
                            Reason = reasonTextBox.Text,
                            TermInHours = term,
                            AdminId = 15,
                            BlockAndDelete = ifDeleteCheckBox.Checked,
                            UserId = _user.UserId
                        };
                        _user.IsBlocked = true;
                        
                        _userBLL.UpdateBlockingData(_user, _blockingDataDTO);

                        Close();
                    }
                    if (res == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }
        }

        private void reasonTextBox_TextChanged(object sender, EventArgs e)
        {
            if (reasonTextBox.BackColor == TextBoxErrorBackColor && reasonTextBox.Focused)
            {
                reasonTextBox.BackColor = TextBoxDefaultBackColor;
            }
        }

        private void termTextBox_TextChanged(object sender, EventArgs e)
        {
            if (termTextBox.BackColor == TextBoxErrorBackColor && termTextBox.Focused)
            {
                termTextBox.BackColor = TextBoxDefaultBackColor;
            }
        }
    }
}