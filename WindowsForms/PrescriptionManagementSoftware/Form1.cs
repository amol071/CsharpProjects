using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PrescriptionManagementSoftware
{
    public partial class Form1 : Form
    {
        private SqlConnection connection;

        public Form1()
        {
            InitializeComponent();
            InitializeSqlConnection();
            this.FormClosing += Form1_FormClosing; // Subscribe to the FormClosing event
        }

        private void InitializeSqlConnection()
        {
            // Retrieve the connection string from app.config
            string connectionString = ConfigurationManager.ConnectionStrings["PrecriptionDB"].ConnectionString;

            try
            {
                // Open a connection to the database
                connection = new SqlConnection(connectionString);
                connection.Open();

                // If the connection is successful, update ToolStripStatusLabel text to "Connected" with green color
                toolStripStatusLabel1.Text = "Connected";
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Green;

                // Call SetFormName after connecting to the database
                SetFormName();
            }
            catch (Exception ex)
            {
                // If there's an error, update ToolStripStatusLabel text to "Connection Error" with red color
                toolStripStatusLabel1.Text = "Connection Error";
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;

                // Display a message box with the error message
                MessageBox.Show("Error connecting to database: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetFormName()
        {
            // Retrieve the client ID from app.config
            string clientId = ConfigurationManager.AppSettings["ClientId"];

            // Query to retrieve the client name based on the client ID
            string query = "SELECT client_name FROM tbl_Client WHERE client_id = @ClientId";

            // Create a command to execute the query
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add the client ID parameter to the command
                command.Parameters.AddWithValue("@ClientId", clientId);

                try
                {
                    // Execute the query and retrieve the client name
                    string clientName = (string)command.ExecuteScalar();

                    // Set the form name to the client name
                    this.Text = "PMS System - " + clientName;
                }
                catch (Exception ex)
                {
                    // Handle any exceptions
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if the SQL connection is open
            if (connection != null && connection.State == ConnectionState.Open)
            {
                // Close the SQL connection
                connection.Close();
            }
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Check if the username or password fields are blank
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the event handler
            }

            // Query to check if the username and password exist in tbl_User
            string query = "SELECT COUNT(*) FROM tbl_User WHERE username = @Username AND password = @Password";

            // Create a command to execute the query
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add parameters for username and password
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    // Execute the query to check if the user exists
                    int count = (int)command.ExecuteScalar();

                    // If count is greater than 0, user exists
                    if (count > 0)
                    {
                        // Close Form1
                        this.Hide();

                        // Open Main form
                        Main mainForm = new Main(connection); // Pass the connection to Main form
                        mainForm.Show(); // Show Main form
                    }
                    else
                    {
                        // Show error message if username or password is incorrect
                        MessageBox.Show("Invalid username or password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear the text in txtUsername and txtPassword textboxes
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
