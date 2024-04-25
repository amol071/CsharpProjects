namespace PrescriptionManagementSoftware
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            exitToolStripMenuItem = new ToolStripMenuItem();
            btnLogin = new Button();
            btnClear = new Button();
            btnCancel = new Button();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 40F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(101, 66);
            label1.Name = "label1";
            label1.Size = new Size(305, 72);
            label1.TabIndex = 0;
            label1.Text = "Login Panel";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 182);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 211);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(111, 179);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(295, 23);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(111, 208);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(295, 23);
            txtPassword.TabIndex = 4;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 302);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(450, 22);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(450, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(38, 20);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(24, 252);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(102, 29);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(132, 252);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(102, 29);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(240, 252);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(102, 29);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 324);
            Controls.Add(btnCancel);
            Controls.Add(btnClear);
            Controls.Add(btnLogin);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Button btnLogin;
        private Button btnClear;
        private Button btnCancel;
    }
}