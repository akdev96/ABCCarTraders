using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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

            // Confirm Password Match
            if (iptPassword.Text != iptRePassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Define connection string (replace with your actual connection string)
            string connectionString = "Server=DEVNODE\\SQLEXPRESS;Database=ABCCarTraders;Trusted_Connection=True;";

            // Retrieve form values
            string firstName = iptFirstName.Text;
            string lastName = iptLastName.Text;
            string email = iptEmail.Text;
            string username = iptUsername.Text;
            string password = iptPassword.Text;

            string regData = firstName + ' ' + lastName + ' ' + email + ' ' + username;

            MessageBox.Show(regData, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Password Visibility
            bool showPassword = regShowPass.Checked;

            iptPassword.PasswordChar = showPassword ? '\0' : '*';
            iptRePassword.PasswordChar = showPassword ? '\0' : '*';
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
    }
}
