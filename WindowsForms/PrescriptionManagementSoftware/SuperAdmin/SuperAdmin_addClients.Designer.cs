namespace PrescriptionManagementSoftware.SuperAdmin
{
    partial class SuperAdmin_addClients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            datagridSuperClient = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtClientName = new TextBox();
            txtClientAddress = new TextBox();
            txtClientCity = new TextBox();
            txtClientPincode = new TextBox();
            btnInsertClient = new Button();
            btnUpdateClient = new Button();
            btnDeleteClient = new Button();
            ddlClientCountry = new ComboBox();
            label3 = new Label();
            ddlIsActive = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)datagridSuperClient).BeginInit();
            SuspendLayout();
            // 
            // datagridSuperClient
            // 
            datagridSuperClient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagridSuperClient.Location = new Point(12, 409);
            datagridSuperClient.Name = "datagridSuperClient";
            datagridSuperClient.RowTemplate.Height = 25;
            datagridSuperClient.Size = new Size(1238, 190);
            datagridSuperClient.TabIndex = 0;
            datagridSuperClient.CellClick += datagridSuperClient_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 100);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 1;
            label1.Text = "Client Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(611, 100);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 2;
            label2.Text = "Client Full Address";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(611, 175);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 4;
            label4.Text = "Client City";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(611, 204);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 5;
            label5.Text = "Client Country";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(611, 234);
            label6.Name = "label6";
            label6.Size = new Size(84, 15);
            label6.TabIndex = 6;
            label6.Text = "Client Pincode";
            // 
            // txtClientName
            // 
            txtClientName.Location = new Point(133, 97);
            txtClientName.Name = "txtClientName";
            txtClientName.Size = new Size(416, 23);
            txtClientName.TabIndex = 8;
            // 
            // txtClientAddress
            // 
            txtClientAddress.Location = new Point(721, 88);
            txtClientAddress.Multiline = true;
            txtClientAddress.Name = "txtClientAddress";
            txtClientAddress.Size = new Size(492, 78);
            txtClientAddress.TabIndex = 9;
            // 
            // txtClientCity
            // 
            txtClientCity.Location = new Point(721, 172);
            txtClientCity.Name = "txtClientCity";
            txtClientCity.Size = new Size(492, 23);
            txtClientCity.TabIndex = 10;
            // 
            // txtClientPincode
            // 
            txtClientPincode.Location = new Point(721, 234);
            txtClientPincode.Name = "txtClientPincode";
            txtClientPincode.Size = new Size(492, 23);
            txtClientPincode.TabIndex = 12;
            // 
            // btnInsertClient
            // 
            btnInsertClient.Location = new Point(436, 380);
            btnInsertClient.Name = "btnInsertClient";
            btnInsertClient.Size = new Size(115, 23);
            btnInsertClient.TabIndex = 13;
            btnInsertClient.Text = "Insert";
            btnInsertClient.UseVisualStyleBackColor = true;
            btnInsertClient.Click += btnInsertClient_Click;
            // 
            // btnUpdateClient
            // 
            btnUpdateClient.Location = new Point(557, 380);
            btnUpdateClient.Name = "btnUpdateClient";
            btnUpdateClient.Size = new Size(115, 23);
            btnUpdateClient.TabIndex = 14;
            btnUpdateClient.Text = "Update";
            btnUpdateClient.UseVisualStyleBackColor = true;
            btnUpdateClient.Click += btnUpdateClient_Click;
            // 
            // btnDeleteClient
            // 
            btnDeleteClient.Location = new Point(678, 380);
            btnDeleteClient.Name = "btnDeleteClient";
            btnDeleteClient.Size = new Size(115, 23);
            btnDeleteClient.TabIndex = 15;
            btnDeleteClient.Text = "Delete";
            btnDeleteClient.UseVisualStyleBackColor = true;
            // 
            // ddlClientCountry
            // 
            ddlClientCountry.FormattingEnabled = true;
            ddlClientCountry.Location = new Point(721, 201);
            ddlClientCountry.Name = "ddlClientCountry";
            ddlClientCountry.Size = new Size(492, 23);
            ddlClientCountry.TabIndex = 16;
            ddlClientCountry.Text = "Select Country";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(611, 269);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 17;
            label3.Text = "Client Active";
            // 
            // ddlIsActive
            // 
            ddlIsActive.FormattingEnabled = true;
            ddlIsActive.Items.AddRange(new object[] { "True", "False" });
            ddlIsActive.Location = new Point(721, 263);
            ddlIsActive.Name = "ddlIsActive";
            ddlIsActive.Size = new Size(170, 23);
            ddlIsActive.TabIndex = 18;
            ddlIsActive.Text = "Select Active";
            // 
            // SuperAdmin_addClients
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 611);
            Controls.Add(ddlIsActive);
            Controls.Add(label3);
            Controls.Add(ddlClientCountry);
            Controls.Add(btnDeleteClient);
            Controls.Add(btnUpdateClient);
            Controls.Add(btnInsertClient);
            Controls.Add(txtClientPincode);
            Controls.Add(txtClientCity);
            Controls.Add(txtClientAddress);
            Controls.Add(txtClientName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(datagridSuperClient);
            Name = "SuperAdmin_addClients";
            Text = "Super Admin: Client Management";
            Load += SuperAdmin_addClients_Load;
            ((System.ComponentModel.ISupportInitialize)datagridSuperClient).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView datagridSuperClient;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtClientName;
        private TextBox txtClientAddress;
        private TextBox txtClientCity;
        private TextBox txtClientPincode;
        private Button btnInsertClient;
        private Button btnUpdateClient;
        private Button btnDeleteClient;
        private ComboBox ddlClientCountry;
        private Label label3;
        private ComboBox ddlIsActive;
    }
}