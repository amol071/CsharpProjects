using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WPF1
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=DESKTOP-J1PK3L5\\SQLEXPRESS;Initial Catalog=CRUD;User ID=admin;Password=admin;";

        public Form1()
        {
            InitializeComponent();
            LoadLabelsAndControlsFromDatabase();
        }

        private void LoadLabelsAndControlsFromDatabase()
        {
            try
            {
                // Open connection to SQL Server
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Retrieve column names and data types from a sample table
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM UsersTbl", connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.FillSchema(dataTable, SchemaType.Source);

                    // Create labels and corresponding controls dynamically based on column names and data types
                    int y = 20; // Starting Y position for labels
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        Label label = new Label();
                        label.Text = column.ColumnName;
                        label.AutoSize = true;

                        // Add label to TableLayoutPanel row 1
                        tableLayoutPanel1.Controls.Add(label, 0, tableLayoutPanel1.RowCount - 1);

                        // Create corresponding control (TextBox or DateTimePicker)
                        Control control;
                        if (column.DataType == typeof(DateTime))
                        {
                            DateTimePicker dateTimePicker = new DateTimePicker();
                            dateTimePicker.Format = DateTimePickerFormat.Short;
                            control = dateTimePicker;
                        }
                        else
                        {
                            TextBox textBox = new TextBox();
                            control = textBox;

                            if (column.ColumnName == "Id")
                            {
                                textBox.Enabled = false;
                            }
                        }
                        control.Width = 150; // Adjust width as needed

                        // Add control to TableLayoutPanel row 1
                        tableLayoutPanel1.Controls.Add(control, 1, tableLayoutPanel1.RowCount - 1);

                        // Increase RowCount of TableLayoutPanel
                        tableLayoutPanel1.RowCount++;
                    }

                    // Add Update and Delete buttons
                    Button updateButton = new Button();
                    updateButton.Text = "Update";
                    //updateButton.Click += UpdateButton_Click; // Add event handler for updating
                    tableLayoutPanel1.Controls.Add(updateButton, 0, tableLayoutPanel1.RowCount);
                    tableLayoutPanel1.SetColumnSpan(updateButton, 2); // Make the button span across both columns

                    Button deleteButton = new Button();
                    deleteButton.Text = "Delete";
                    //deleteButton.Click += DeleteButton_Click; // Add event handler for deleting
                    tableLayoutPanel1.Controls.Add(deleteButton, 0, tableLayoutPanel1.RowCount);
                    tableLayoutPanel1.SetColumnSpan(deleteButton, 2); // Make the button span across both columns

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
