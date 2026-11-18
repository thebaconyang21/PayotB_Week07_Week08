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
    public partial class ucProductListing : UserControl
    {

        string[] units = { "Piece", "Box", "Kilogram" };

        public class ProductItem
        {
            public string Description { get; set; }
            public double Amount { get; set; }
            public string Unit { get; set; }
        }

        List<ProductItem> shopingList = new List<ProductItem>();
        public ucProductListing()
        {
            InitializeComponent();

            dgvItem.Columns.Clear();

            dgvItem.Columns.Add("Description", "Description");
            dgvItem.Columns.Add("Amount", "Amount");
            dgvItem.Columns.Add("Unit", "Unit");

            dgvItem.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvItem.MultiSelect = false;
            dgvItem.AllowUserToAddRows = false;

            dgvItem.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            this.Load += ucProductListing_Load;
            btnAdd.Click += btnAdd_Click;
            btnDelete.Click += btnDelete_Click;
        }

        private void ucProductListing_Load(object sender, EventArgs e)
        {
            // Load units into ComboBox
            cmbUnit.Items.Clear();
            cmbUnit.Items.AddRange(units);
            cmbUnit.SelectedIndex = 0;

            updateGUI();
        }

        // Update ListBox
        private void updateGUI()
        {
            dgvItem.Rows.Clear();

            foreach (ProductItem item in shopingList)
            {
                dgvItem.Rows.Add(
                    item.Description,
                    item.Amount,
                    item.Unit
                );
            }

            lblPrompt.Text = shopingList.Count +
                " item(s) in your shopping list.";
        }

        // Add item
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string item = txtDescription.Text.Trim();

            double amount;

            if (item == "")
            {
                MessageBox.Show("Please enter an item description.");
                txtDescription.Focus();
                return;
            }

            if (!double.TryParse(txtAmount.Text, out amount)
                || amount <= 0)
            {
                MessageBox.Show("Please enter a valid amount.");
                txtAmount.Focus();
                return;
            }

            if (cmbUnit.SelectedItem == null)
            {
                MessageBox.Show("Please select a unit.");
                return;
            }

            string unit = cmbUnit.SelectedItem.ToString();

            ProductItem newItem = new ProductItem()
            {
                Description = item,
                Amount = amount,
                Unit = unit
            };

            shopingList.Add(newItem);

            updateGUI();

            txtDescription.Clear();
            txtAmount.Clear();
            cmbUnit.SelectedIndex = 0;

            txtDescription.Focus();
        }

        // Delete selected item
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvItem.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to delete.");
                return;
            }

            int selectedIndex =
                dgvItem.SelectedRows[0].Index;

            shopingList.RemoveAt(selectedIndex);

            updateGUI();
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
