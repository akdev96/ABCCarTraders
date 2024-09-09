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

namespace ABCCarTraders
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm loginForm = new mainForm();
            loginForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validations
            // User name validation
            if (string.IsNullOrWhiteSpace(iptUsername.Text) || iptUsername.Text.Length < 4 || !Regex.IsMatch(iptUsername.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Invalid Username - Provide a username with more than 4 english characters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Password validation
            if (string.IsNullOrWhiteSpace(iptPassword.Text) || string.IsNullOrWhiteSpace(iptRePassword.Text))
            {
                MessageBox.Show("Please confirm your password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Password minimum length 6
            if (iptPassword.Text.Length < 6)
            {
                MessageBox.Show("Password is too short. Make sure it's at least 6 characters long.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Password must contain uppercase, special character, and number
            if (!Regex.IsMatch(iptPassword.Text, @"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$"))
            {
                MessageBox.Show("Password must contain at least one uppercase letter, one number, and one special character.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm Password Match
            if (iptPassword.Text != iptRePassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                            cmd.Parameters.AddWithValue("@password", EncryptPassword(iptPassword.Text)); // Encrypt the password
                            cmd.Parameters.AddWithValue("@role", "customer"); // Default role is Customer
                            cmd.Parameters.AddWithValue("@date_registered", DateTime.Now); // Current date and time
                            cmd.Parameters.AddWithValue("@status_is_active", 1); // Active by default

                            // Execute the insert command
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                mainForm loginForm = new mainForm();
                loginForm.Show();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Password Visibility
            bool showPassword = chkShowPass.Checked;

            iptPassword.PasswordChar = showPassword ? '\0' : '*';
            iptRePassword.PasswordChar = showPassword ? '\0' : '*';
        }

        private string EncryptPassword(string password)
        {
            //  encryption to MD5

            byte[] data = System.Text.Encoding.UTF8.GetBytes(password);
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] hash = md5.ComputeHash(data);
                return Convert.ToBase64String(hash);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminPortal adminPortal = new AdminPortal();
            adminPortal.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CustomerPortal customerPortal = new CustomerPortal();
            customerPortal.Show();
        }

        private void iptFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void iptUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            mainForm loginForm = new mainForm();
            loginForm.Show();
        }
    }
}
