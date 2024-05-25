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
    public partial class SuperAdmin_addClients : Form
    {
        private SqlConnection connection;

        public SuperAdmin_addClients()
        {
            InitializeComponent();
            InitializeSqlConnection();
            LoadData();
            datagridSuperClient.ReadOnly = true;
            datagridSuperClient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void InitializeSqlConnection()
        {
            // Initialize the SqlConnection object using the connection string from app.config
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PrecriptionDB"].ConnectionString);
        }

        private void LoadData()
        {
            try
            {
                // Open the connection
                connection.Open();

                // Create a SqlCommand object to execute the stored procedure
                SqlCommand command = new SqlCommand("USP_ViewClientRecords", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Create a SqlDataAdapter to fetch the data
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                // Create a DataTable to hold the fetched data
                DataTable dataTable = new DataTable();

                // Fill the DataTable with the data fetched by the SqlDataAdapter
                adapter.Fill(dataTable);

                // Set the DataSource property of the DataGridView to the filled DataTable
                datagridSuperClient.DataSource = dataTable;

                this.Load += SuperAdmin_addClients_Load;

            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("An error occurred while loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the connection
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        private void PopulateCountryDropDown()
        {
            try
            {
                // Open the connection
                connection.Open();

                // Create a SqlCommand object to execute the query
                SqlCommand command = new SqlCommand("SELECT country_name FROM tbl_Countries", connection);

                // Create a SqlDataReader to read the results
                SqlDataReader reader = command.ExecuteReader();

                // Clear existing items in the dropdown list
                ddlClientCountry.Items.Clear();

                // Iterate through the results and add them to the dropdown list
                while (reader.Read())
                {
                    // Get the country name from the current row
                    string countryName = reader["country_name"].ToString();

                    // Add the country name to the dropdown list
                    ddlClientCountry.Items.Add(countryName);
                }

                // Close the reader
                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("An error occurred while populating country dropdown: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the connection
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }


        private void btnInsertClient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClientName.Text) || string.IsNullOrWhiteSpace(txtClientAddress.Text) || string.IsNullOrWhiteSpace(txtClientCity.Text) || string.IsNullOrWhiteSpace(txtClientPincode.Text) || ddlClientCountry.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields before inserting a client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // Open the connection
                connection.Open();

                // Prepare the insert command using the stored procedure
                SqlCommand command = new SqlCommand("USP_InsertClientRecords", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Fetch the maximum client_id from the tbl_Client table
                int maxClientId;
                using (SqlCommand getMaxClientIdCommand = new SqlCommand("SELECT MAX(client_id) FROM tbl_Client", connection))
                {
                    object maxClientIdObj = getMaxClientIdCommand.ExecuteScalar();
                    if (maxClientIdObj != DBNull.Value)
                    {
                        maxClientId = Convert.ToInt32(maxClientIdObj);
                    }
                    else
                    {
                        maxClientId = 0;
                    }
                }
                // Increment the maximum client_id by 1 for the new record
                int newClientId = maxClientId + 1;

                command.Parameters.AddWithValue("@client_id", newClientId);
                command.Parameters.AddWithValue("@client_name", txtClientName.Text);
                command.Parameters.AddWithValue("@client_address", txtClientAddress.Text);
                command.Parameters.AddWithValue("@client_city", txtClientCity.Text);
                command.Parameters.AddWithValue("@client_country", ddlClientCountry.SelectedItem != null ? ddlClientCountry.SelectedItem.ToString() : "");
                command.Parameters.AddWithValue("@client_pincode", txtClientPincode.Text);
                command.Parameters.AddWithValue("@IsActive", 1);
                command.Parameters.AddWithValue("@CreatedOn", DateTime.Now);
                command.Parameters.AddWithValue("@CreatedBy", "admin");
                //command.Parameters.AddWithValue("@ModifiedOn", DateTime.Now);
                //command.Parameters.AddWithValue("@ModifiedBy", "admin");

                // Execute the insert command
                int rowsAffected = command.ExecuteNonQuery();

                // Show success message
                MessageBox.Show("Client inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload data in DataGridView
                LoadData();
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the connection
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void SuperAdmin_addClients_Load(object sender, EventArgs e)
        {
            PopulateCountryDropDown();
        }

        private void datagridSuperClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = datagridSuperClient.Rows[e.RowIndex];

                // Populate textboxes and combobox with the data from the selected row
                txtClientName.Text = selectedRow.Cells["client_name"].Value.ToString();
                txtClientAddress.Text = selectedRow.Cells["client_address"].Value.ToString();
                txtClientCity.Text = selectedRow.Cells["client_city"].Value.ToString();
                ddlClientCountry.SelectedItem = selectedRow.Cells["client_country"].Value.ToString();
                txtClientPincode.Text = selectedRow.Cells["client_pincode"].Value.ToString();
                // Check if the value of "IsActive" column is not null
                if (selectedRow.Cells["IsActive"].Value != DBNull.Value)
                {
                    string isActiveValue = selectedRow.Cells["IsActive"].Value.ToString();

                    // Check if the isActiveValue matches any item in ddlIsActive ComboBox
                    if (ddlIsActive.Items.Contains(isActiveValue))
                    {
                        ddlIsActive.SelectedItem = isActiveValue;
                    }
                    else
                    {
                        ddlIsActive.Items.Add(isActiveValue);
                        ddlIsActive.SelectedItem = isActiveValue;
                    }
                }
                else
                {
                    ddlIsActive.SelectedItem = "No";
                }
            }
        }

        private void btnUpdateClient_Click(object sender, EventArgs e)
        {
            if (datagridSuperClient.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtClientName.Text) || string.IsNullOrWhiteSpace(txtClientAddress.Text) || string.IsNullOrWhiteSpace(txtClientCity.Text) || string.IsNullOrWhiteSpace(txtClientPincode.Text) || ddlClientCountry.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields before updating the client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Open the connection
                connection.Open();

                // Prepare the update command using the stored procedure
                SqlCommand command = new SqlCommand("USP_UpdateClientRecord", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Fetch the client ID from the selected row
                int clientId = Convert.ToInt32(datagridSuperClient.SelectedRows[0].Cells["client_id"].Value);

                command.Parameters.AddWithValue("@client_id", clientId);
                command.Parameters.AddWithValue("@client_name", txtClientName.Text);
                command.Parameters.AddWithValue("@client_address", txtClientAddress.Text);
                command.Parameters.AddWithValue("@client_city", txtClientCity.Text);
                command.Parameters.AddWithValue("@client_country", ddlClientCountry.SelectedItem != null ? ddlClientCountry.SelectedItem.ToString() : "");
                command.Parameters.AddWithValue("@client_pincode", txtClientPincode.Text);
                command.Parameters.AddWithValue("@IsActive", ddlIsActive.SelectedItem.ToString() == "Yes" ? 1 : 0);
                command.Parameters.AddWithValue("@modifiedon", DateTime.Now); 
                command.Parameters.AddWithValue("@modifiedby", "Admin");

                // Add other parameters as needed

                // Execute the update command
                int rowsAffected = command.ExecuteNonQuery();

                // Show success message
                MessageBox.Show("Client updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload data in DataGridView
                LoadData();
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}