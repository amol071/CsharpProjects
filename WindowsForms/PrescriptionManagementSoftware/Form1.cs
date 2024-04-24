using System.Configuration;
using System.Data.SqlClient;

namespace PrescriptionManagementSoftware
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetFormName();
        }

        private void SetFormName()
        {
            // Retrieve the client ID from app.config
            string clientId = ConfigurationManager.AppSettings["ClientId"];

            // Retrieve the connection string from app.config
            string connectionString = ConfigurationManager.ConnectionStrings["PrecriptionDB"].ConnectionString;

            // Query to retrieve the client name based on the client ID
            string query = "SELECT client_name FROM tbl_Client WHERE client_id = @ClientId";

            // Create a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a command to execute the query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the client ID parameter to the command
                    command.Parameters.AddWithValue("@ClientId", clientId);

                    try
                    {
                        // Open the connection
                        connection.Open();

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
}