namespace PrescriptionManagementSoftware.SuperAdmin
{
    partial class SuperAdminMain
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
            btnLogin_super = new Button();
            btnClear_super = new Button();
            btnCancel_super = new Button();
            label1 = new Label();
            label2 = new Label();
            txtUsernameSuper = new TextBox();
            txtPasswordSuper = new TextBox();
            SuspendLayout();
            // 
            // btnLogin_super
            // 
            btnLogin_super.Location = new Point(12, 259);
            btnLogin_super.Name = "btnLogin_super";
            btnLogin_super.Size = new Size(159, 41);
            btnLogin_super.TabIndex = 0;
            btnLogin_super.Text = "Login";
            btnLogin_super.UseVisualStyleBackColor = true;
            btnLogin_super.Click += btnLogin_super_Click;
            // 
            // btnClear_super
            // 
            btnClear_super.Location = new Point(177, 259);
            btnClear_super.Name = "btnClear_super";
            btnClear_super.Size = new Size(159, 41);
            btnClear_super.TabIndex = 1;
            btnClear_super.Text = "Clear";
            btnClear_super.UseVisualStyleBackColor = true;
            btnClear_super.Click += btnClear_super_Click;
            // 
            // btnCancel_super
            // 
            btnCancel_super.Location = new Point(342, 259);
            btnCancel_super.Name = "btnCancel_super";
            btnCancel_super.Size = new Size(159, 41);
            btnCancel_super.TabIndex = 2;
            btnCancel_super.Text = "Cancel";
            btnCancel_super.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 116);
            label1.Name = "label1";
            label1.Size = new Size(132, 15);
            label1.TabIndex = 3;
            label1.Text = "Super Admin Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 148);
            label2.Name = "label2";
            label2.Size = new Size(129, 15);
            label2.TabIndex = 4;
            label2.Text = "Super Admin Password";
            // 
            // txtUsernameSuper
            // 
            txtUsernameSuper.Location = new Point(206, 113);
            txtUsernameSuper.Name = "txtUsernameSuper";
            txtUsernameSuper.Size = new Size(295, 23);
            txtUsernameSuper.TabIndex = 5;
            // 
            // txtPasswordSuper
            // 
            txtPasswordSuper.Location = new Point(206, 145);
            txtPasswordSuper.Name = "txtPasswordSuper";
            txtPasswordSuper.Size = new Size(295, 23);
            txtPasswordSuper.TabIndex = 6;
            // 
            // SuperAdminMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 312);
            Controls.Add(txtPasswordSuper);
            Controls.Add(txtUsernameSuper);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel_super);
            Controls.Add(btnClear_super);
            Controls.Add(btnLogin_super);
            Name = "SuperAdminMain";
            Text = "Super Admin Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin_super;
        private Button btnClear_super;
        private Button btnCancel_super;
        private Label label1;
        private Label label2;
        private TextBox txtUsernameSuper;
        private TextBox txtPasswordSuper;
    }
}