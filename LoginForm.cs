using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.SqlClient;

namespace ABCCarTraders
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();

            // make password characters hidden
            txb_password.PasswordChar = '*';

            // setting default value in login role dropdown
            comboBox1.SelectedIndex = 1;

            txb_userName.Text = "akdev";
            txb_password.Text = "Logmein001?";

        }

        public static class UserSession
        {
            // Static properties to store user information to access in any calss
            public static string UserName { get; set; }
            public static string UserID { get; set; }
            public static DateTime LoginDate { get; set; }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            // Check for null values in username and password fields
            if (string.IsNullOrWhiteSpace(txb_userName.Text))
            {
                MessageBox.Show("Please enter your username.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txb_password.Text))
            {
                MessageBox.Show("Please enter your password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hash the entered password
            string hashedPassword = HashPassword(txb_password.Text);

            // Connect to the database
            try
            {
                string connectionString = "Data Source=DEVNODE\\SQLEXPRESS;Initial Catalog=ABCCarTraders;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

                // Use 'using' to ensure the connection and commands are properly disposed of
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Query to fetch role and userID based on username and password
                    string query = "SELECT [role], id FROM [users] WHERE status_is_active=@status_is_active AND username=@username AND password=@password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@status_is_active", 1); // only active customers can login
                    cmd.Parameters.AddWithValue("@username", txb_userName.Text); // check username
                    cmd.Parameters.AddWithValue("@password", hashedPassword); // Use the hashed password

                    // Execute the query and get the role and userID
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string role = reader["role"].ToString();
                        string userID = reader["id"].ToString();

                        // Set the session variables
                        UserSession.UserName = txb_userName.Text;
                        UserSession.UserID = userID;
                        UserSession.LoginDate = DateTime.Now;

                        // Display message based on role
                        if (role == "customer")
                        {
                            this.Hide();//hide until exit form user dash board
                            CustomerPortal customerPortal = new CustomerPortal();
                            customerPortal.Show();
                            MessageBox.Show("Welcome, Customer!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (role == "admin")
                        {
                            this.Hide();//hide until exit form admin dash board
                            
                            AdminPortal adminPortal = new AdminPortal();
                            adminPortal.Show();
                            MessageBox.Show("Welcome, Admin!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            this.Hide();//if not user or admin, this for other user , now we dont have aditional feature 
                            MessageBox.Show("Welcome, User!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        // Login failed message
                        MessageBox.Show("Login unsuccessful. Please check your username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

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

        private string HashPassword(string password)
        {
            byte[] data = Encoding.UTF8.GetBytes(password);
            using (var md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(data);
                return Convert.ToBase64String(hash);
            }
        }

        private void txb_userName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
