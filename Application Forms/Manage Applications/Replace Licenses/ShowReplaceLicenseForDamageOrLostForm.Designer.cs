namespace My_DVLD_Project
{
    partial class ShowReplaceLicenseForDamageOrLostForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowReplaceLicenseForDamageOrLostForm));
            this.ctrlFindLicenseByFilter1 = new My_DVLD_Project.ctrlFindLicenseByFilter();
            this.lbReplaceOrLoste = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbLosteLicense = new System.Windows.Forms.RadioButton();
            this.rbDamageLicense = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbReplacmentLicenseID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbCreatedBy = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lbOldLicenseID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.lbApplicationFeess = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.lbApplicationDate = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.lbLRenewlAppID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.linkShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIssueReplacment = new System.Windows.Forms.Button();
            this.LinkShowLicense = new System.Windows.Forms.LinkLabel();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlFindLicenseByFilter1
            // 
            this.ctrlFindLicenseByFilter1._Type = 0;
            this.ctrlFindLicenseByFilter1.Location = new System.Drawing.Point(3, 37);
            this.ctrlFindLicenseByFilter1.Name = "ctrlFindLicenseByFilter1";
            this.ctrlFindLicenseByFilter1.Size = new System.Drawing.Size(647, 512);
            this.ctrlFindLicenseByFilter1.TabIndex = 0;
            this.ctrlFindLicenseByFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlFindLicenseByFilter1_OnLicenseSelected);
            // 
            // lbReplaceOrLoste
            // 
            this.lbReplaceOrLoste.AutoSize = true;
            this.lbReplaceOrLoste.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReplaceOrLoste.ForeColor = System.Drawing.Color.Red;
            this.lbReplaceOrLoste.Location = new System.Drawing.Point(280, 9);
            this.lbReplaceOrLoste.Name = "lbReplaceOrLoste";
            this.lbReplaceOrLoste.Size = new System.Drawing.Size(222, 25);
            this.lbReplaceOrLoste.TabIndex = 1;
            this.lbReplaceOrLoste.Text = "Replacement For Lost\r\n";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbLosteLicense);
            this.groupBox2.Controls.Add(this.rbDamageLicense);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(656, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Repalecmete For :";
            // 
            // rbLosteLicense
            // 
            this.rbLosteLicense.AutoSize = true;
            this.rbLosteLicense.Location = new System.Drawing.Point(17, 63);
            this.rbLosteLicense.Name = "rbLosteLicense";
            this.rbLosteLicense.Size = new System.Drawing.Size(57, 21);
            this.rbLosteLicense.TabIndex = 5;
            this.rbLosteLicense.TabStop = true;
            this.rbLosteLicense.Text = "Lost";
            this.rbLosteLicense.UseVisualStyleBackColor = true;
            // 
            // rbDamageLicense
            // 
            this.rbDamageLicense.AutoSize = true;
            this.rbDamageLicense.Location = new System.Drawing.Point(17, 36);
            this.rbDamageLicense.Name = "rbDamageLicense";
            this.rbDamageLicense.Size = new System.Drawing.Size(85, 21);
            this.rbDamageLicense.TabIndex = 4;
            this.rbDamageLicense.TabStop = true;
            this.rbDamageLicense.Text = "Damage";
            this.rbDamageLicense.UseVisualStyleBackColor = true;
            this.rbDamageLicense.CheckedChanged += new System.EventHandler(this.rbDamageLicense_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.lbReplacmentLicenseID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.lbCreatedBy);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.lbOldLicenseID);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.pictureBox6);
            this.groupBox1.Controls.Add(this.lbApplicationFeess);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.pictureBox8);
            this.groupBox1.Controls.Add(this.lbApplicationDate);
            this.groupBox1.Controls.Add(this.pictureBox9);
            this.groupBox1.Controls.Add(this.lbLRenewlAppID);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 542);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 171);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Information For Replasment License";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(548, 126);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 118;
            this.pictureBox1.TabStop = false;
            // 
            // lbReplacmentLicenseID
            // 
            this.lbReplacmentLicenseID.AutoSize = true;
            this.lbReplacmentLicenseID.ForeColor = System.Drawing.Color.Red;
            this.lbReplacmentLicenseID.Location = new System.Drawing.Point(595, 92);
            this.lbReplacmentLicenseID.Name = "lbReplacmentLicenseID";
            this.lbReplacmentLicenseID.Size = new System.Drawing.Size(35, 17);
            this.lbReplacmentLicenseID.TabIndex = 116;
            this.lbReplacmentLicenseID.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(404, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.label2.TabIndex = 117;
            this.label2.Text = "Application Fees :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(159, 126);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 115;
            this.pictureBox2.TabStop = false;
            // 
            // lbCreatedBy
            // 
            this.lbCreatedBy.AutoSize = true;
            this.lbCreatedBy.ForeColor = System.Drawing.Color.Red;
            this.lbCreatedBy.Location = new System.Drawing.Point(202, 140);
            this.lbCreatedBy.Name = "lbCreatedBy";
            this.lbCreatedBy.Size = new System.Drawing.Size(35, 17);
            this.lbCreatedBy.TabIndex = 114;
            this.lbCreatedBy.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 17);
            this.label4.TabIndex = 113;
            this.label4.Text = "CreatedByuserId :";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(547, 31);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(34, 31);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 112;
            this.pictureBox4.TabStop = false;
            // 
            // lbOldLicenseID
            // 
            this.lbOldLicenseID.AutoSize = true;
            this.lbOldLicenseID.ForeColor = System.Drawing.Color.Red;
            this.lbOldLicenseID.Location = new System.Drawing.Point(595, 40);
            this.lbOldLicenseID.Name = "lbOldLicenseID";
            this.lbOldLicenseID.Size = new System.Drawing.Size(35, 17);
            this.lbOldLicenseID.TabIndex = 111;
            this.lbOldLicenseID.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(413, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 17);
            this.label6.TabIndex = 110;
            this.label6.Text = "Old License ID :";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(548, 78);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(34, 31);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 109;
            this.pictureBox6.TabStop = false;
            // 
            // lbApplicationFeess
            // 
            this.lbApplicationFeess.AutoSize = true;
            this.lbApplicationFeess.ForeColor = System.Drawing.Color.Red;
            this.lbApplicationFeess.Location = new System.Drawing.Point(595, 140);
            this.lbApplicationFeess.Name = "lbApplicationFeess";
            this.lbApplicationFeess.Size = new System.Drawing.Size(35, 17);
            this.lbApplicationFeess.TabIndex = 107;
            this.lbApplicationFeess.Text = "???";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(353, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(184, 17);
            this.label13.TabIndex = 108;
            this.label13.Text = "Replacment License ID :";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(159, 78);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(34, 31);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 106;
            this.pictureBox8.TabStop = false;
            // 
            // lbApplicationDate
            // 
            this.lbApplicationDate.AutoSize = true;
            this.lbApplicationDate.ForeColor = System.Drawing.Color.Red;
            this.lbApplicationDate.Location = new System.Drawing.Point(202, 92);
            this.lbApplicationDate.Name = "lbApplicationDate";
            this.lbApplicationDate.Size = new System.Drawing.Size(35, 17);
            this.lbApplicationDate.TabIndex = 105;
            this.lbApplicationDate.Text = "???";
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(159, 32);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(34, 31);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 103;
            this.pictureBox9.TabStop = false;
            // 
            // lbLRenewlAppID
            // 
            this.lbLRenewlAppID.AutoSize = true;
            this.lbLRenewlAppID.ForeColor = System.Drawing.Color.Red;
            this.lbLRenewlAppID.Location = new System.Drawing.Point(202, 43);
            this.lbLRenewlAppID.Name = "lbLRenewlAppID";
            this.lbLRenewlAppID.Size = new System.Drawing.Size(35, 17);
            this.lbLRenewlAppID.TabIndex = 102;
            this.lbLRenewlAppID.Text = "???";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 17);
            this.label10.TabIndex = 104;
            this.label10.Text = "Application Date :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(42, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 17);
            this.label12.TabIndex = 101;
            this.label12.Text = "L.R.L.Appl.ID :";
            // 
            // linkShowLicensesHistory
            // 
            this.linkShowLicensesHistory.AutoSize = true;
            this.linkShowLicensesHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkShowLicensesHistory.Location = new System.Drawing.Point(656, 347);
            this.linkShowLicensesHistory.Name = "linkShowLicensesHistory";
            this.linkShowLicensesHistory.Size = new System.Drawing.Size(181, 18);
            this.linkShowLicensesHistory.TabIndex = 5;
            this.linkShowLicensesHistory.TabStop = true;
            this.linkShowLicensesHistory.Text = "Show Licenses History";
            this.linkShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkShowLicensesHistory_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(717, 652);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 61);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssueReplacment
            // 
            this.btnIssueReplacment.BackColor = System.Drawing.Color.White;
            this.btnIssueReplacment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIssueReplacment.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnIssueReplacment.FlatAppearance.BorderSize = 2;
            this.btnIssueReplacment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueReplacment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueReplacment.Location = new System.Drawing.Point(717, 573);
            this.btnIssueReplacment.Name = "btnIssueReplacment";
            this.btnIssueReplacment.Size = new System.Drawing.Size(112, 61);
            this.btnIssueReplacment.TabIndex = 7;
            this.btnIssueReplacment.Text = "Issue Replacment";
            this.btnIssueReplacment.UseVisualStyleBackColor = false;
            this.btnIssueReplacment.Click += new System.EventHandler(this.btnIssueReplacment_Click);
            this.btnIssueReplacment.MouseEnter += new System.EventHandler(this.btnIssueReplacment_MouseEnter);
            this.btnIssueReplacment.MouseLeave += new System.EventHandler(this.btnIssueReplacment_MouseLeave);
            // 
            // LinkShowLicense
            // 
            this.LinkShowLicense.AutoSize = true;
            this.LinkShowLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkShowLicense.Location = new System.Drawing.Point(656, 401);
            this.LinkShowLicense.Name = "LinkShowLicense";
            this.LinkShowLicense.Size = new System.Drawing.Size(127, 18);
            this.LinkShowLicense.TabIndex = 8;
            this.LinkShowLicense.TabStop = true;
            this.LinkShowLicense.Text = "Show Licenses ";
            this.LinkShowLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkShowLicense_LinkClicked);
            // 
            // ShowReplaceLicenseForDamageOrLostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 716);
            this.Controls.Add(this.LinkShowLicense);
            this.Controls.Add(this.btnIssueReplacment);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.linkShowLicensesHistory);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbReplaceOrLoste);
            this.Controls.Add(this.ctrlFindLicenseByFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowReplaceLicenseForDamageOrLostForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replace License For Damage Or Lost";
            this.Load += new System.EventHandler(this.ShowReplaceLicenseForDamageOrLostForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlFindLicenseByFilter ctrlFindLicenseByFilter1;
        private System.Windows.Forms.Label lbReplaceOrLoste;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbLosteLicense;
        private System.Windows.Forms.RadioButton rbDamageLicense;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbReplacmentLicenseID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbCreatedBy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lbOldLicenseID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label lbApplicationFeess;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label lbApplicationDate;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label lbLRenewlAppID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.LinkLabel linkShowLicensesHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssueReplacment;
        private System.Windows.Forms.LinkLabel LinkShowLicense;
    }
}