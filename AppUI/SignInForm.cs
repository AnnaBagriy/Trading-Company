using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                incorrectEmailLabel.Visible = false;
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (passwordTextBox.BackColor == TextBoxErrorBackColor && emailTextBox.Focused)
            {
                passwordTextBox.BackColor = TextBoxDefaultBackColor;
                incorrectPasswordLabel.Visible = false;
            }
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            var email = emailTextBox.Text;
            var password = passwordTextBox.Text;

            UserDTO user = null;

            try
            {
                user = _userBLL.GetUserSignIn(email, password);
            }
            catch (NullReferenceException)
            {
                emailTextBox.BackColor = TextBoxErrorBackColor;
                incorrectEmailLabel.Visible = true;
            }
            catch (AuthenticationException)
            {
                passwordTextBox.BackColor = TextBoxErrorBackColor;
                incorrectPasswordLabel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured.\n{ex.Message}");
            }

            if (user != null)
            {
                MessageBox.Show($"Welcome, {user.FirstName}!");
            }
        }
    }
}
