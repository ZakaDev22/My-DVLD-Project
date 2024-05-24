namespace My_DVLD_Project
{
    partial class ShowPersonLicenseHistoryForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowPersonLicenseHistoryForm));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LicensesTapControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbLocalRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.djvLocalLicense = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbInternationalRecords = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.djvInternationalLicense = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlPersonInfoByFilter1 = new My_DVLD_Project.ctrlPersonInfoByFilter();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.LicensesTapControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.djvLocalLicense)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.djvInternationalLicense)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(292, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage License History";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LicensesTapControl);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 416);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(810, 258);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver History";
            // 
            // LicensesTapControl
            // 
            this.LicensesTapControl.Controls.Add(this.tabPage1);
            this.LicensesTapControl.Controls.Add(this.tabPage2);
            this.LicensesTapControl.Location = new System.Drawing.Point(18, 26);
            this.LicensesTapControl.Name = "LicensesTapControl";
            this.LicensesTapControl.SelectedIndex = 0;
            this.LicensesTapControl.Size = new System.Drawing.Size(786, 226);
            this.LicensesTapControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbLocalRecords);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.djvLocalLicense);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(778, 198);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbLocalRecords
            // 
            this.lbLocalRecords.AutoSize = true;
            this.lbLocalRecords.ForeColor = System.Drawing.Color.Red;
            this.lbLocalRecords.Location = new System.Drawing.Point(92, 170);
            this.lbLocalRecords.Name = "lbLocalRecords";
            this.lbLocalRecords.Size = new System.Drawing.Size(15, 15);
            this.lbLocalRecords.TabIndex = 3;
            this.lbLocalRecords.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "# Records :";
            // 
            // djvLocalLicense
            // 
            this.djvLocalLicense.AllowUserToAddRows = false;
            this.djvLocalLicense.AllowUserToDeleteRows = false;
            this.djvLocalLicense.AllowUserToOrderColumns = true;
            this.djvLocalLicense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.djvLocalLicense.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.djvLocalLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.djvLocalLicense.ContextMenuStrip = this.contextMenuStrip1;
            this.djvLocalLicense.Location = new System.Drawing.Point(9, 42);
            this.djvLocalLicense.Name = "djvLocalLicense";
            this.djvLocalLicense.ReadOnly = true;
            this.djvLocalLicense.Size = new System.Drawing.Size(763, 116);
            this.djvLocalLicense.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Local License History :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbInternationalRecords);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.djvInternationalLicense);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(778, 198);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "International";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbInternationalRecords
            // 
            this.lbInternationalRecords.AutoSize = true;
            this.lbInternationalRecords.ForeColor = System.Drawing.Color.Red;
            this.lbInternationalRecords.Location = new System.Drawing.Point(92, 171);
            this.lbInternationalRecords.Name = "lbInternationalRecords";
            this.lbInternationalRecords.Size = new System.Drawing.Size(15, 15);
            this.lbInternationalRecords.TabIndex = 7;
            this.lbInternationalRecords.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "# Records :";
            // 
            // djvInternationalLicense
            // 
            this.djvInternationalLicense.AllowUserToAddRows = false;
            this.djvInternationalLicense.AllowUserToDeleteRows = false;
            this.djvInternationalLicense.AllowUserToOrderColumns = true;
            this.djvInternationalLicense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.djvInternationalLicense.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.djvInternationalLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.djvInternationalLicense.ContextMenuStrip = this.contextMenuStrip1;
            this.djvInternationalLicense.Location = new System.Drawing.Point(9, 43);
            this.djvInternationalLicense.Name = "djvInternationalLicense";
            this.djvInternationalLicense.ReadOnly = true;
            this.djvInternationalLicense.Size = new System.Drawing.Size(763, 116);
            this.djvInternationalLicense.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "International License History :";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(727, 670);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 52);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlPersonInfoByFilter1
            // 
            this.ctrlPersonInfoByFilter1.FilterByIDEdite = false;
            this.ctrlPersonInfoByFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonInfoByFilter1.Location = new System.Drawing.Point(14, 37);
            this.ctrlPersonInfoByFilter1.Name = "ctrlPersonInfoByFilter1";
            this.ctrlPersonInfoByFilter1.PersonID = 0;
            this.ctrlPersonInfoByFilter1.SelectedIndex = 0;
            this.ctrlPersonInfoByFilter1.Size = new System.Drawing.Size(810, 399);
            this.ctrlPersonInfoByFilter1.TabIndex = 0;
            this.ctrlPersonInfoByFilter1.Load += new System.EventHandler(this.ctrlPersonInfoByFilter1_Load);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseDetailsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(233, 58);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showLicenseDetailsToolStripMenuItem.Image")));
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(232, 32);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // ShowPersonLicenseHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 723);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlPersonInfoByFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowPersonLicenseHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowPersonLicenseHistoryForm";
            this.Load += new System.EventHandler(this.ShowPersonLicenseHistoryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.LicensesTapControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.djvLocalLicense)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.djvInternationalLicense)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlPersonInfoByFilter ctrlPersonInfoByFilter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl LicensesTapControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lbLocalRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView djvLocalLicense;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lbInternationalRecords;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView djvInternationalLicense;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
    }
}