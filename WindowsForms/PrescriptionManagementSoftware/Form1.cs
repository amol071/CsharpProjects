using System;
using System.Configuration;
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
    }
}
