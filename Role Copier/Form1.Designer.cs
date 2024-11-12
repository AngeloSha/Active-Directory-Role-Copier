namespace ADRoleCopier
{
    partial class Form1
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
            txtSource = new TextBox();
            txtDestination = new TextBox();
            btnCopyRoles = new Button();
            lblSource = new Label();
            lblDestination = new Label();
            lstLog = new ListBox();
            SuspendLayout();
            // 
            // txtSource
            // 
            txtSource.Location = new Point(114, 26);
            txtSource.Name = "txtSource";
            txtSource.Size = new Size(205, 23);
            txtSource.TabIndex = 0;
            // 
            // txtDestination
            // 
            txtDestination.Location = new Point(114, 64);
            txtDestination.Name = "txtDestination";
            txtDestination.Size = new Size(205, 23);
            txtDestination.TabIndex = 1;
            // 
            // btnCopyRoles
            // 
            btnCopyRoles.Location = new Point(114, 103);
            btnCopyRoles.Name = "btnCopyRoles";
            btnCopyRoles.Size = new Size(205, 28);
            btnCopyRoles.TabIndex = 2;
            btnCopyRoles.Text = "Copy Roles";
            btnCopyRoles.UseVisualStyleBackColor = true;
            btnCopyRoles.Click += btnCopyRoles_Click;
            // 
            // lblSource
            // 
            lblSource.AutoSize = true;
            lblSource.Location = new Point(30, 29);
            lblSource.Name = "lblSource";
            lblSource.Size = new Size(72, 15);
            lblSource.TabIndex = 3;
            lblSource.Text = "Source User:";
            // 
            // lblDestination
            // 
            lblDestination.AutoSize = true;
            lblDestination.Location = new Point(13, 67);
            lblDestination.Name = "lblDestination";
            lblDestination.Size = new Size(96, 15);
            lblDestination.TabIndex = 4;
            lblDestination.Text = "Destination User:";
            // 
            // lstLog
            // 
            lstLog.FormattingEnabled = true;
            lstLog.ItemHeight = 15;
            lstLog.Location = new Point(16, 151);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(621, 124);
            lstLog.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(757, 292);
            Controls.Add(lstLog);
            Controls.Add(lblDestination);
            Controls.Add(lblSource);
            Controls.Add(btnCopyRoles);
            Controls.Add(txtDestination);
            Controls.Add(txtSource);
            Name = "Form1";
            Text = "AD Role Copier";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Button btnCopyRoles;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.ListBox lstLog;
    }
}