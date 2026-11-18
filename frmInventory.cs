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
    public partial class frmInventory : Form
    {
        public frmInventory()
        {
            InitializeComponent();

            // Connect menu click events
            homeToolStripMenuItem.Click += homeToolStripMenuItem_Click;
            productListToolStripMenuItem.Click += productListToolStripMenuItem_Click;
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;

            // Display Home when the form opens
            ShowHome();
        }

        // Display a UserControl inside pnlContent
        private void ShowPage(UserControl page)
        {
            pnlContent.Controls.Clear();

            page.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(page);
        }

        // Home menu
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHome();
        }

        private void ShowHome()
        {
            pnlContent.Controls.Clear();

            Label lblHome = new Label();

            lblHome.Text = "WELCOME TO INVENTORY MANAGEMENT SYSTEM";
            lblHome.Dock = DockStyle.Fill;
            lblHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblHome.Font = new System.Drawing.Font(
                "Arial", 16, System.Drawing.FontStyle.Bold);

            pnlContent.Controls.Add(lblHome);
        }

        // Product List menu
        private void productListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPage(new ucProductListing());
        }

        // Exit menu
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Exit Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
