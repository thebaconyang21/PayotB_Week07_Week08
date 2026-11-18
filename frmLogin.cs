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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            btnLogin.Click += btnLogin_Click;
            btnSignup.Click += btnSignup_Click;

            checkBox1.CheckedChanged += checkBox1_CheckedChanged;

            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter your username and password.");
                return;
            }

            // Check registered users
            User foundUser = null;

            foreach (User user in UserStore.Users)
            {
                if (user.Username.Equals(
                    username, StringComparison.OrdinalIgnoreCase)
                    && user.Password == password)
                {
                    foundUser = user;
                    break;
                }
            }

            if (foundUser != null)
            {
                MessageBox.Show(
                    "Welcome, " + foundUser.Fullname + "!");

                frmInventory inventory = new frmInventory();
                inventory.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show(
                    "Invalid username or password!",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            frmSignup signup = new frmSignup();
            signup.Show();

            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
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
