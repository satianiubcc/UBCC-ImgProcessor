namespace Process_UBCC_Images
{
    partial class ProcessImg
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
            this.lblSource = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.btnSBrowse = new System.Windows.Forms.Button();
            this.btnDBrowse = new System.Windows.Forms.Button();
            this.fb_DDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.fb_SDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(29, 44);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(40, 13);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "Source";
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(29, 98);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(61, 13);
            this.lblDestination.TabIndex = 1;
            this.lblDestination.Text = "Destination";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(32, 60);
            this.txtSource.Name = "txtSource";
            this.txtSource.ReadOnly = true;
            this.txtSource.Size = new System.Drawing.Size(472, 20);
            this.txtSource.TabIndex = 2;
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(32, 114);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.ReadOnly = true;
            this.txtDestination.Size = new System.Drawing.Size(472, 20);
            this.txtDestination.TabIndex = 3;
            // 
            // btnSBrowse
            // 
            this.btnSBrowse.Location = new System.Drawing.Point(500, 57);
            this.btnSBrowse.Name = "btnSBrowse";
            this.btnSBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnSBrowse.TabIndex = 4;
            this.btnSBrowse.Text = "Browse";
            this.btnSBrowse.UseVisualStyleBackColor = true;
            this.btnSBrowse.Click += new System.EventHandler(this.btnSBrowse_Click);
            // 
            // btnDBrowse
            // 
            this.btnDBrowse.Location = new System.Drawing.Point(500, 112);
            this.btnDBrowse.Name = "btnDBrowse";
            this.btnDBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnDBrowse.TabIndex = 5;
            this.btnDBrowse.Text = "Browse";
            this.btnDBrowse.UseVisualStyleBackColor = true;
            this.btnDBrowse.Click += new System.EventHandler(this.btnDBrowse_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(451, 186);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(124, 44);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.Text = "Copy Missing Images";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // ProcessImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 263);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnDBrowse);
            this.Controls.Add(this.btnSBrowse);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.lblSource);
            this.Name = "ProcessImg";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Button btnSBrowse;
        private System.Windows.Forms.Button btnDBrowse;
        private System.Windows.Forms.FolderBrowserDialog fb_DDialog;
        private System.Windows.Forms.FolderBrowserDialog fb_SDialog;
        private System.Windows.Forms.Button btnCopy;
    }
}

