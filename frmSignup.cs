using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payot_Week06_Week08
{
    public partial class frmSignup : Form
    {
        public frmSignup()
        {
            InitializeComponent();

            btnSignup.Click += btnSignup_Click;
            lnkGoBack.LinkClicked += lnkGoBack_LinkClicked;

            chkShowHide.CheckedChanged += chkShowHide_CheckedChanged;

            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string fullname = txtFullname.Text.Trim();
            string email = txtEmail.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Check empty fields
            if (fullname == "" || email == "" ||
                username == "" || password == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Check existing username
            foreach (User user in UserStore.Users)
            {
                if (user.Username.Equals(
                    username, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Username already exists!");
                    return;
                }
            }

            // Save new user
            User newUser = new User();

            newUser.Fullname = fullname;
            newUser.Email = email;
            newUser.Username = username;
            newUser.Password = password;

            UserStore.Users.Add(newUser);

            MessageBox.Show(
                "Registration successful!",
                "Signup",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Return to Login
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }

        private void lnkGoBack_LinkClicked(
            object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }

        private void chkShowHide_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowHide.Checked)
            {
                // Show password
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // Hide password
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
