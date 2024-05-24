namespace My_DVLD_Project
{
    partial class ShowDetainedLicenseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowDetainedLicenseForm));
            this.LinkShowLicense = new System.Windows.Forms.LinkLabel();
            this.btnDetained = new System.Windows.Forms.Button();
            this.linkShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFineFees = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbCreatedBy = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lbLicenseID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.lbDetainedDate = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.lbDetaineID = new System.Windows.Forms.Label();
            this.lbDetaineDate = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbReplaceOrLoste = new System.Windows.Forms.Label();
            this.ctrlFindLicenseByFilter1 = new My_DVLD_Project.ctrlFindLicenseByFilter();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // LinkShowLicense
            // 
            this.LinkShowLicense.AutoSize = true;
            this.LinkShowLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkShowLicense.Location = new System.Drawing.Point(659, 480);
            this.LinkShowLicense.Name = "LinkShowLicense";
            this.LinkShowLicense.Size = new System.Drawing.Size(127, 18);
            this.LinkShowLicense.TabIndex = 15;
            this.LinkShowLicense.TabStop = true;
            this.LinkShowLicense.Text = "Show Licenses ";
            this.LinkShowLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkShowLicense_LinkClicked);
            // 
            // btnDetained
            // 
            this.btnDetained.BackColor = System.Drawing.Color.White;
            this.btnDetained.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetained.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnDetained.FlatAppearance.BorderSize = 2;
            this.btnDetained.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetained.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetained.Location = new System.Drawing.Point(960, 449);
            this.btnDetained.Name = "btnDetained";
            this.btnDetained.Size = new System.Drawing.Size(112, 61);
            this.btnDetained.TabIndex = 14;
            this.btnDetained.Text = "Detained";
            this.btnDetained.UseVisualStyleBackColor = false;
            this.btnDetained.Click += new System.EventHandler(this.btnIssueReplacment_Click);
            // 
            // linkShowLicensesHistory
            // 
            this.linkShowLicensesHistory.AutoSize = true;
            this.linkShowLicensesHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkShowLicensesHistory.Location = new System.Drawing.Point(655, 449);
            this.linkShowLicensesHistory.Name = "linkShowLicensesHistory";
            this.linkShowLicensesHistory.Size = new System.Drawing.Size(181, 18);
            this.linkShowLicensesHistory.TabIndex = 13;
            this.linkShowLicensesHistory.TabStop = true;
            this.linkShowLicensesHistory.Text = "Show Licenses History";
            this.linkShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkShowLicensesHistory_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFineFees);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.lbCreatedBy);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.lbLicenseID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.pictureBox8);
            this.groupBox1.Controls.Add(this.lbDetainedDate);
            this.groupBox1.Controls.Add(this.pictureBox9);
            this.groupBox1.Controls.Add(this.lbDetaineID);
            this.groupBox1.Controls.Add(this.lbDetaineDate);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(649, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 320);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Information For Replasment License";
            // 
            // txtFineFees
            // 
            this.txtFineFees.Location = new System.Drawing.Point(220, 129);
            this.txtFineFees.Name = "txtFineFees";
            this.txtFineFees.Size = new System.Drawing.Size(100, 23);
            this.txtFineFees.TabIndex = 119;
            this.txtFineFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFineFees_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(166, 121);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 118;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 117;
            this.label2.Text = "Fine Fees :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(166, 236);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 115;
            this.pictureBox2.TabStop = false;
            // 
            // lbCreatedBy
            // 
            this.lbCreatedBy.AutoSize = true;
            this.lbCreatedBy.ForeColor = System.Drawing.Color.Red;
            this.lbCreatedBy.Location = new System.Drawing.Point(218, 253);
            this.lbCreatedBy.Name = "lbCreatedBy";
            this.lbCreatedBy.Size = new System.Drawing.Size(35, 17);
            this.lbCreatedBy.TabIndex = 114;
            this.lbCreatedBy.Text = "???";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(165, 170);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(34, 31);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 112;
            this.pictureBox4.TabStop = false;
            // 
            // lbLicenseID
            // 
            this.lbLicenseID.AutoSize = true;
            this.lbLicenseID.ForeColor = System.Drawing.Color.Red;
            this.lbLicenseID.Location = new System.Drawing.Point(217, 182);
            this.lbLicenseID.Name = "lbLicenseID";
            this.lbLicenseID.Size = new System.Drawing.Size(35, 17);
            this.lbLicenseID.TabIndex = 111;
            this.lbLicenseID.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 17);
            this.label4.TabIndex = 113;
            this.label4.Text = "CreatedByuserId :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 17);
            this.label6.TabIndex = 110;
            this.label6.Text = "License ID :";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(165, 75);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(34, 31);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 106;
            this.pictureBox8.TabStop = false;
            // 
            // lbDetainedDate
            // 
            this.lbDetainedDate.AutoSize = true;
            this.lbDetainedDate.ForeColor = System.Drawing.Color.Red;
            this.lbDetainedDate.Location = new System.Drawing.Point(217, 89);
            this.lbDetainedDate.Name = "lbDetainedDate";
            this.lbDetainedDate.Size = new System.Drawing.Size(35, 17);
            this.lbDetainedDate.TabIndex = 105;
            this.lbDetainedDate.Text = "???";
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(165, 29);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(34, 31);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 103;
            this.pictureBox9.TabStop = false;
            // 
            // lbDetaineID
            // 
            this.lbDetaineID.AutoSize = true;
            this.lbDetaineID.ForeColor = System.Drawing.Color.Red;
            this.lbDetaineID.Location = new System.Drawing.Point(217, 43);
            this.lbDetaineID.Name = "lbDetaineID";
            this.lbDetaineID.Size = new System.Drawing.Size(35, 17);
            this.lbDetaineID.TabIndex = 102;
            this.lbDetaineID.Text = "???";
            // 
            // lbDetaineDate
            // 
            this.lbDetaineDate.AutoSize = true;
            this.lbDetaineDate.Location = new System.Drawing.Point(24, 92);
            this.lbDetaineDate.Name = "lbDetaineDate";
            this.lbDetaineDate.Size = new System.Drawing.Size(113, 17);
            this.lbDetaineDate.TabIndex = 104;
            this.lbDetaineDate.Text = "Detaine Date :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(43, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 17);
            this.label12.TabIndex = 101;
            this.label12.Text = "Detaine ID :";
            // 
            // lbReplaceOrLoste
            // 
            this.lbReplaceOrLoste.AutoSize = true;
            this.lbReplaceOrLoste.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReplaceOrLoste.ForeColor = System.Drawing.Color.Red;
            this.lbReplaceOrLoste.Location = new System.Drawing.Point(275, -75);
            this.lbReplaceOrLoste.Name = "lbReplaceOrLoste";
            this.lbReplaceOrLoste.Size = new System.Drawing.Size(222, 25);
            this.lbReplaceOrLoste.TabIndex = 10;
            this.lbReplaceOrLoste.Text = "Replacement For Lost\r\n";
            // 
            // ctrlFindLicenseByFilter1
            // 
            this.ctrlFindLicenseByFilter1._Type = 0;
            this.ctrlFindLicenseByFilter1.Location = new System.Drawing.Point(6, 29);
            this.ctrlFindLicenseByFilter1.Name = "ctrlFindLicenseByFilter1";
            this.ctrlFindLicenseByFilter1.Size = new System.Drawing.Size(647, 512);
            this.ctrlFindLicenseByFilter1.TabIndex = 9;
            this.ctrlFindLicenseByFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlFindLicenseByFilter1_OnLicenseSelected);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(842, 449);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 61);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(704, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Detained License ";
            // 
            // ShowDetainedLicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 541);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.LinkShowLicense);
            this.Controls.Add(this.btnDetained);
            this.Controls.Add(this.linkShowLicensesHistory);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbReplaceOrLoste);
            this.Controls.Add(this.ctrlFindLicenseByFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowDetainedLicenseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowDetainedLicenseForm";
            this.Load += new System.EventHandler(this.ShowDetainedLicenseForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel LinkShowLicense;
        private System.Windows.Forms.Button btnDetained;
        private System.Windows.Forms.LinkLabel linkShowLicensesHistory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbCreatedBy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lbLicenseID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label lbDetainedDate;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label lbDetaineID;
        private System.Windows.Forms.Label lbDetaineDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbReplaceOrLoste;
        private ctrlFindLicenseByFilter ctrlFindLicenseByFilter1;
        private System.Windows.Forms.TextBox txtFineFees;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
    }
}