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
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Collections;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace ABCCarTraders
{
    public partial class AdminPortal : Form
    {
        private BindingSource bindingSource = new BindingSource();
        public AdminPortal()
        {
            InitializeComponent();
            loadUserData(); // Load data to the grid
            loadVehicleData();
            usersDataGrid.CellClick += usersDataGrid_CellClick;
            vehicleDataGrid.CellClick += vehicleDataGrid_CellClick;
        }

        //Users
        //Load user data
        private void loadUserData() // Load all customers from the customer table into the DataGridView
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
                    usersDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    // Modify the visible column headers
                    usersDataGrid.Columns["id"].HeaderText = "User ID";
                    usersDataGrid.Columns["first_name"].HeaderText = "First Name";
                    usersDataGrid.Columns["last_name"].HeaderText = "Last Name";
                    usersDataGrid.Columns["email"].HeaderText = "Email Address";
                    usersDataGrid.Columns["username"].HeaderText = "Username";
                    usersDataGrid.Columns["role"].HeaderText = "User Role";
                    usersDataGrid.Columns["date_registered"].HeaderText = "Date Registered";

                    con.Close();
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

        //Render User data on table click
        private void usersDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is valid (not the header row)
            if (e.RowIndex >= 0) // Ensure it's not a header click
            {
                // Get the selected row
                DataGridViewRow selectedRow = usersDataGrid.Rows[e.RowIndex];

                // Populate the text fields with the data from the selected row
                iptId.ReadOnly = true;
                iptCreatedOn.ReadOnly = true;
                iptId.Text = selectedRow.Cells["id"].Value?.ToString();
                iptFirstName.Text = selectedRow.Cells["first_name"].Value?.ToString();
                iptLastName.Text = selectedRow.Cells["last_name"].Value?.ToString();
                iptEmail.Text = selectedRow.Cells["email"].Value?.ToString();
                iptUsername.Text = selectedRow.Cells["username"].Value?.ToString();
                iptRole.Text = selectedRow.Cells["role"].Value?.ToString();
                iptCreatedOn.Text = selectedRow.Cells["date_registered"].Value?.ToString();
            }
        }

        //Add User
        public void AddUser()
        {
            try
            {
                string connectionString = "Data Source=DEVNODE\\SQLEXPRESS;Initial Catalog=ABCCarTraders;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

                // Use 'using' to ensure the connection and commands are properly disposed of
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Step 1: Get the last userID
                    string getLastUserIDQuery = "SELECT TOP 1 id FROM [users] ORDER BY id DESC";
                    using (SqlCommand getLastUserIDCmd = new SqlCommand(getLastUserIDQuery, con))
                    {
                        object result = getLastUserIDCmd.ExecuteScalar();
                        int newUserID = 1; // Default if no users exist

                        if (result != null)
                        {
                            // Convert lastUserID to int and increment
                            int lastUserID = Convert.ToInt32(result);
                            newUserID = lastUserID + 1;
                        }

                        // Step 2: Insert user data into the database with the new userID
                        string query = @"INSERT INTO [users] (id, first_name, last_name, email, username, password, role, date_registered, status_is_active)
                            VALUES (@id, @first_name, @last_name, @email, @username, @password, @role, @date_registered, @status_is_active)";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            // Adding parameters with appropriate data types
                            cmd.Parameters.AddWithValue("@id", newUserID);
                            cmd.Parameters.AddWithValue("@first_name", iptFirstName.Text);
                            cmd.Parameters.AddWithValue("@last_name", iptLastName.Text);
                            cmd.Parameters.AddWithValue("@email", iptEmail.Text);
                            cmd.Parameters.AddWithValue("@username", iptUsername.Text);
                            cmd.Parameters.AddWithValue("@password", EncryptPassword(iptRePasswd.Text)); // Encrypt the password
                            cmd.Parameters.AddWithValue("@role", "customer"); // Default role is Customer
                            cmd.Parameters.AddWithValue("@date_registered", DateTime.Now); // Current date and time
                            cmd.Parameters.AddWithValue("@status_is_active", 1); // Active by default

                            // Execute the insert command
                            cmd.ExecuteNonQuery();
                        }
                    }
                    con.Close();
                }

                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadUserData();
                //this.Hide();
                //mainForm loginForm = new mainForm();
                //loginForm.Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database connection failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        //Update User
        private void UpdateUser()
        {
            // Validations
            if (string.IsNullOrWhiteSpace(iptUsername.Text) || iptUsername.Text.Length < 4 || !Regex.IsMatch(iptUsername.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Invalid Username - Provide a username with more than 4 English characters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(iptEmail.Text))
            {
                MessageBox.Show("Email cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connectionString = "Data Source=DEVNODE\\SQLEXPRESS;Initial Catalog=ABCCarTraders;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"UPDATE [users] 
                                     SET first_name = @first_name, 
                                         last_name = @last_name, 
                                         email = @email, 
                                         username = @username, 
                                         password = @password, 
                                         status_is_active = @status_is_active 
                                     WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Add parameters with appropriate data types
                        cmd.Parameters.AddWithValue("@id", iptId.Text);
                        cmd.Parameters.AddWithValue("@first_name", iptFirstName.Text);
                        cmd.Parameters.AddWithValue("@last_name", iptLastName.Text);
                        cmd.Parameters.AddWithValue("@email", iptEmail.Text);
                        cmd.Parameters.AddWithValue("@username", iptUsername.Text);
                        cmd.Parameters.AddWithValue("@password", EncryptPassword(iptPasswd.Text)); // Encrypt the password
                        cmd.Parameters.AddWithValue("@status_is_active", 1); // Adjust as necessary

                        // Execute the update command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if any row was affected (updated)
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadUserData();
                        }
                        else
                        {
                            MessageBox.Show("No user found with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    con.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database connection failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            UpdateUser();
        }

        //Delete User
        private void DeleteUser(int userId)
        {
            try
            {
                // Validate the user ID
                if (userId <= 0)
                {
                    MessageBox.Show("Please select a valid user to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string connectionString = "Data Source=DEVNODE\\SQLEXPRESS;Initial Catalog=ABCCarTraders;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Define the delete query
                    string query = "DELETE FROM [users] WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Add parameter for the user ID
                        cmd.Parameters.AddWithValue("@id", userId);

                        // Execute the delete command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if any row was affected (deleted)
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No user found with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    con.Close();
                }

                loadUserData(); // Reload data in the DataGridView after deletion
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database connection failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (usersDataGrid.SelectedRows.Count > 0)
            {
                // Get the ID of the selected user
                int selectedUserId = Convert.ToInt32(usersDataGrid.SelectedRows[0].Cells["id"].Value);
                DeleteUser(selectedUserId); // Call the delete method
            }
            else
            {
                MessageBox.Show("Please select a user to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //User search button
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                string kwd = textBox5.Text.Trim();
                string connectionString = "Data Source=DEVNODE\\SQLEXPRESS;Initial Catalog=ABCCarTraders;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

                // Define the query with a parameter placeholder
                string query = "SELECT id, first_name, last_name, email, username, role, date_registered FROM users WHERE status_is_active = 1 AND first_name LIKE @kwd OR last_name LIKE @kwd OR username LIKE @kwd";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Create a SqlCommand with the query and connection
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Add the @kwd parameter with wildcard for partial match
                        cmd.Parameters.AddWithValue("@kwd", "%" + kwd + "%");

                        // Pass the SqlCommand to SqlDataAdapter
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            // Bind the DataTable to the DataGridView
                            bindingSource.DataSource = dt;
                            usersDataGrid.DataSource = bindingSource;
                            usersDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

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
                    con.Close();
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

        //Clear Form Button
        private void button3_Click(object sender, EventArgs e)
        {

            iptId.Text = "";
            iptFirstName.Text = "";
            iptLastName.Text = "";
            iptEmail.Text = "";
            iptUsername.Text = "";
            iptPasswd.Text = "";
            iptRePasswd.Text = "";
            iptRole.Text = "";
            iptCreatedOn.Text = "";
        }

        //Encrypt Password
        private string EncryptPassword(string password)
        {
            // encryption to MD5

            byte[] data = System.Text.Encoding.UTF8.GetBytes(password);
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] hash = md5.ComputeHash(data);
                return Convert.ToBase64String(hash);
            }
        }

        //Dashboard Tab Navigations
        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            loadUserData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }
        //

        //Inventory
        //Vehicles

        //Load vehicle list
        private void loadVehicleData() // Load all customers from the customer table into the DataGridView
        {
            try
            {
                string connectionString = "Data Source=DEVNODE\\SQLEXPRESS;Initial Catalog=ABCCarTraders;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
                //string query = "SELECT userID, username, NIC, address, telephone, email, role, status FROM customer"; // No need for PW
                //only active and deactice customers(delete customers dont show),pw dosent needed
                string query = "SELECT id, brand, model, manufactured_year, chassie_no, condition, image, body_type, mileage, quantity, stock_price, sale_price FROM vehicle_inventory";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlDataAdapter dv = new SqlDataAdapter(query, con);
                    DataTable dvt = new DataTable();
                    dv.Fill(dvt);

                    bindingSource.DataSource = dvt; // Bind the DataTable to the BindingSource
                    vehicleDataGrid.DataSource = bindingSource; // Bind the BindingSource to the DataGridView
                    vehicleDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    // Modify the visible column headers
                    vehicleDataGrid.Columns["id"].HeaderText = "Vehicle ID";
                    vehicleDataGrid.Columns["brand"].HeaderText = "Brand";
                    vehicleDataGrid.Columns["model"].HeaderText = "Model";
                    vehicleDataGrid.Columns["manufactured_year"].HeaderText = "YoM";
                    vehicleDataGrid.Columns["chassie_no"].HeaderText = "Chassie No";
                    vehicleDataGrid.Columns["condition"].HeaderText = "Condition";
                    vehicleDataGrid.Columns["image"].HeaderText = "Image";
                    vehicleDataGrid.Columns["body_type"].HeaderText = "Body Type";
                    vehicleDataGrid.Columns["mileage"].HeaderText = "Mileage (KM)";
                    vehicleDataGrid.Columns["quantity"].HeaderText = "Quantity";
                    vehicleDataGrid.Columns["stock_price"].HeaderText = "Stock Price";
                    vehicleDataGrid.Columns["sale_price"].HeaderText = "Sale Price";
                    con.Close();
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


        //Add Vehicle
        public void AddVehicle()
        {
            try
            {
                string connectionString = "Data Source=DEVNODE\\SQLEXPRESS;Initial Catalog=ABCCarTraders;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

                // Use 'using' to ensure the connection and commands are properly disposed of
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Step 1: Get the last userID
                    string getLastVehicleIDQuery = "SELECT TOP 1 id FROM [vehicle_inventory] ORDER BY id DESC";
                    using (SqlCommand getLastVehicleIDCmd = new SqlCommand(getLastVehicleIDQuery, con))
                    {
                        object result = getLastVehicleIDCmd.ExecuteScalar();
                        int newVehicleID = 1; // Default if no users exist

                        if (result != null)
                        {
                            // Convert lastUserID to int and increment
                            int lastVehicleID = Convert.ToInt32(result);
                            newVehicleID = lastVehicleID + 1;
                        }

                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat); // Save the image to the MemoryStream
                            byte[] imageBytes = ms.ToArray(); // Convert the MemoryStream to a byte array

                            // Step 2: Insert user data into the database with the new userID
                            string query = @"INSERT INTO [vehicle_inventory] (id, brand, model, manufactured_year, chassie_no, condition, image, body_type, mileage, quantity, stock_price, sale_price)
                            VALUES (@id, @brand, @model, @manufactured_year, @chassie_no, @condition, @image, @body_type, @mileage, @quantity, @stock_price, @sale_price)";
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                // Adding parameters with appropriate data types
                                cmd.Parameters.AddWithValue("@id", newVehicleID);
                                cmd.Parameters.AddWithValue("@brand", ipt_vi_brand.Text);
                                cmd.Parameters.AddWithValue("@model", ipt_vi_model.Text);
                                cmd.Parameters.AddWithValue("@manufactured_year", ipt_vi_yom.Text);
                                cmd.Parameters.AddWithValue("@chassie_no", ipt_vi_chassieno.Text);
                                cmd.Parameters.AddWithValue("@condition", ipt_vi_chassieno.Text);
                                cmd.Parameters.AddWithValue("@image", imageBytes);
                                cmd.Parameters.AddWithValue("@body_type", ipt_vi_bodytype.Text);
                                cmd.Parameters.AddWithValue("@mileage", ipt_vi_mileage.Text);
                                cmd.Parameters.AddWithValue("@quantity", ipt_vi_quantity.Text);
                                cmd.Parameters.AddWithValue("@stock_price", ipt_vi_stockprice.Text);
                                cmd.Parameters.AddWithValue("@sale_price", ipt_vi_saleprice.Text);

                                // Execute the insert command
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    con.Close();
                }

                MessageBox.Show("Vehicle Added successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadVehicleData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database connection failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddV_Click(object sender, EventArgs e)
        {
            AddVehicle();
        }

        private void btnUploadImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set the filter for image files
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select an Image File";

                // Show the dialog and check if the user selected a file
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                
                    string filePath = openFileDialog.FileName;

                    //pictureBox1.Image = Image.FromFile(filePath);
                    pictureBox1.Image = System.Drawing.Image.FromFile(filePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;


                    //labelFilePath.Text = filePath; // Assuming you have a label to show the path
                }
            }
        }

        //View Vehicle
        private void vehicleDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is valid (not the header row)
            if (e.RowIndex >= 0) // Ensure it's not a header click
            {
                // Get the selected row
                DataGridViewRow selectedRow = vehicleDataGrid.Rows[e.RowIndex];

                // Populate the text fields with the data from the selected row
                ipt_vi_id.ReadOnly = true;
                ipt_vi_id.Text = selectedRow.Cells["id"].Value?.ToString();
                ipt_vi_brand.Text = selectedRow.Cells["brand"].Value?.ToString();
                ipt_vi_model.Text = selectedRow.Cells["model"].Value?.ToString();
                ipt_vi_yom.Text = selectedRow.Cells["manufactured_year"].Value?.ToString();
                ipt_vi_chassieno.Text = selectedRow.Cells["chassie_no"].Value?.ToString();
                ipt_vi_condition.Text = selectedRow.Cells["condition"].Value?.ToString();
                ipt_vi_bodytype.Text = selectedRow.Cells["body_type"].Value?.ToString();
                ipt_vi_mileage.Text = selectedRow.Cells["mileage"].Value?.ToString();
                ipt_vi_quantity.Text = selectedRow.Cells["quantity"].Value?.ToString();
                ipt_vi_stockprice.Text = selectedRow.Cells["stock_price"].Value?.ToString();
                ipt_vi_saleprice.Text = selectedRow.Cells["sale_price"].Value?.ToString();

                ipt_vi_model.Text = selectedRow.Cells["model"].Value?.ToString();

                var imageData = vehicleDataGrid.CurrentRow.Cells["image"].Value as byte[];
                if (imageData != null)
                {
                    // Convert byte array to an Image and display it in PictureBox
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Adjust image display mode as needed
                    }
                }
                else
                {
                    MessageBox.Show("No image data available in the selected cell.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

    }
}
