using AppUI;
using BLL;
using BLL.Strings;
using DTO;
using System;
using System.Drawing;
using System.Windows.Forms;
using Unity;

namespace UI
{
    public partial class SignInForm : Form
    {
        #region Common UI

        private readonly Color TextBoxErrorBackColor = Color.Maroon;
        private readonly Color TextBoxDefaultBackColor = Color.White;

        #endregion

        private UserBLL _userBLL;

        public SignInForm()
        {
            InitializeComponent();

            _userBLL = new UserBLL();
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            if (emailTextBox.BackColor == TextBoxErrorBackColor && emailTextBox.Focused)
            {
                emailTextBox.BackColor = TextBoxDefaultBackColor;
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (passwordTextBox.BackColor == TextBoxErrorBackColor && emailTextBox.Focused)
            {
                passwordTextBox.BackColor = TextBoxDefaultBackColor;
            }
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            var email = emailTextBox.Text;
            var password = passwordTextBox.Text;

            UserDTO user = null;
            string message = "";
            
            var result = _userBLL.GetUserSignIn(email, password);

            user = result.Data;
            message = result.Message;

            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                emailTextBox.BackColor = TextBoxErrorBackColor;
            }
            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                passwordTextBox.BackColor = TextBoxErrorBackColor;
            }

            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, ErrorMessages.GeneralError, MessageBoxButtons.OK);               
            }

            if (user != null)
            {
                Hide();

                var menu = Program.Container.Resolve<AdministrationMenuForm>();
                menu.ShowDialog();

                return;
            }
        }
    }
}
