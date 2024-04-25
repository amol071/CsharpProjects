using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrescriptionManagementSoftware
{
    public partial class Main : Form
    {
        private SqlConnection connection;
        public Main(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection; // Initialize connection
            SetFormName();

            this.FormClosing += Main_FormClosing;

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

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
