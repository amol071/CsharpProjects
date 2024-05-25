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

namespace PrescriptionManagementSoftware.SuperAdmin
{
    public partial class SuperAdminMain : Form
    {
        public SuperAdminMain()
        {
            InitializeComponent();
        }

        private void btnLogin_super_Click(object sender, EventArgs e)
        {
            string username = txtUsernameSuper.Text;
            string password = txtPasswordSuper.Text;

            try
            {
                // Create a SqlConnection object using the connection string from your app.config
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PrecriptionDB"].ConnectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Query to check if the provided username and password are valid
                    string query = "SELECT COUNT(*) FROM tbl_SuperAdmin WHERE username = @Username AND password = @Password AND IsActive = 1";

                    // Create a SqlCommand object to execute the query
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters for username and password
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Execute the query
                        int count = (int)command.ExecuteScalar();

                        // Check if a record with the provided username and password exists
                        if (count > 0)
                        {
                            // Successful login
                            MessageBox.Show("Login successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Hide the SuperAdminMain form
                            this.Hide();

                            // Show the SuperAdmin_addClients form
                            SuperAdmin_addClients addClientsForm = new SuperAdmin_addClients();
                            addClientsForm.ShowDialog();

                            // Close the SuperAdminMain form after showing the addClientsForm
                            this.Close();
                        }
                        else
                        {
                            // Invalid username or password
                            MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnClear_super_Click(object sender, EventArgs e)
        {
            txtUsernameSuper.Text = "";
            txtPasswordSuper.Text = "";
        }
    }
}