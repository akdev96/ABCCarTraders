using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ABCCarTraders
{
    public partial class AdminPortal : Form
    {
        private BindingSource bindingSource = new BindingSource();
        public AdminPortal()
        {
            InitializeComponent();
            LoadData(); // Load data to the grid
            usersDataGrid.CellClick += usersDataGrid_CellClick;
        }

        private void LoadData() // Load all customers from the customer table into the DataGridView
        {
            try
            {
                string connectionString = "Data Source=DEVNODE\\SQLEXPRESS;Initial Catalog=ABCCarTraders;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
                //string query = "SELECT userID, username, NIC, address, telephone, email, role, status FROM customer"; // No need for PW
                //only active and deactice customers(delete customers dont show),pw dosent needed
                string query = "SELECT id, first_name, last_name, email, username, role, date_registered FROM users WHERE status_is_active IN (1)";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    bindingSource.DataSource = dt; // Bind the DataTable to the BindingSource
                    usersDataGrid.DataSource = bindingSource; // Bind the BindingSource to the DataGridView

                    // Modify the visible column headers
                    usersDataGrid.Columns["id"].HeaderText = "User ID";
                    usersDataGrid.Columns["first_name"].HeaderText = "First Name";
                    usersDataGrid.Columns["last_name"].HeaderText = "Last Name";
                    usersDataGrid.Columns["email"].HeaderText = "Email Address";
                    usersDataGrid.Columns["username"].HeaderText = "Username";
                    usersDataGrid.Columns["role"].HeaderText = "User Role";
                    usersDataGrid.Columns["date_registered"].HeaderText = "Date Registered";
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void usersDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell click event here
            try
            {
                if (e.RowIndex >= 0) // Ensure the row index is valid
                {
                    DataGridViewRow row = usersDataGrid.Rows[e.RowIndex];

                    // Load the data from the selected row into the text boxes
                    //AdminManageCustomerNameBox.Text = row.Cells["username"].Value.ToString();
                    //AdminManageCustomerNICBox.Text = row.Cells["NIC"].Value.ToString();
                    //AdminManageCustomerAddressBox.Text = row.Cells["address"].Value.ToString();
                    //AdminManageCustomersTelephoneBox.Text = row.Cells["telephone"].Value.ToString();
                    //AdminManageCustomersEmailBox.Text = row.Cells["email"].Value.ToString();
                    //AdminManageCustomersRoleBox.Text = row.Cells["role"].Value.ToString();//comboRole
                    //AdminMangeCustomerStatusBox.Text = row.Cells["status"].Value.ToString();//comboStatus
                    //AdminManageCustomerUserIDbox.Text = row.Cells["userID"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading customer details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdminPortal_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void usersDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }
    }
}
