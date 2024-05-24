using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_DVLD_Project
{
    public partial class ShowReplaceLicenseForDamageOrLostForm : Form
    {
        private short ApplicationLostFees = 0;
        private short ApplicationDamageFees = 0;
        private short ApplicatioType = 0;

        private int PersonID = -1;
        private byte IssueReason = 0;
        private clsApplications _Application;
        private clsLicense _NewLicense;


        public ShowReplaceLicenseForDamageOrLostForm()
        {
            InitializeComponent();
        }

        private void rbDamageLicense_CheckedChanged(object sender, EventArgs e)
        {
            if(rbDamageLicense.Checked)
            {
                lbReplaceOrLoste.Text = " Replacement For Damage";
                lbApplicationFeess.Text = ApplicationDamageFees.ToString();
                IssueReason = 3;
                ApplicatioType = 4;
            }
            else
            {
                lbReplaceOrLoste.Text = " Replacement For Lost";
                lbApplicationFeess.Text = ApplicationLostFees.ToString();
                IssueReason = 4;
                ApplicatioType = 3;
            }
        }

        private void ShowReplaceLicenseForDamageOrLostForm_Load(object sender, EventArgs e)
        {
            ctrlFindLicenseByFilter1._Type = 2;

            rbDamageLicense.Checked = true;
            IssueReason = 3;
            ApplicatioType = 4;

            ApplicationDamageFees = clsApplicationTypes.Find(4).ApplicationFees;
            ApplicationLostFees = clsApplicationTypes.Find(3).ApplicationFees;

            LinkShowLicense.Enabled = false;
            linkShowLicensesHistory.Enabled = false;
            btnIssueReplacment.Enabled = false;

            lbCreatedBy.Text = clsGlobal._User.UserName;
            lbApplicationDate.Text = DateTime.Now.ToString();
            lbApplicationFeess.Text = ApplicationDamageFees.ToString();
        }

        private void ctrlFindLicenseByFilter1_OnLicenseSelected(int obj)
        {
            // Evente Here

            int IsLicenseActive = obj;


            if (IsLicenseActive == 1)
            {
                btnIssueReplacment.Enabled = true;
            }
            else
            {
                btnIssueReplacment.Enabled = false;
            }

            clsLicense _License = clsLicense.FindByLicenseID(ctrlFindLicenseByFilter1._LicenseID);

            if (_License != null)
            {
                lbApplicationDate.Text = DateTime.Now.ToShortDateString();



                lbOldLicenseID.Text = _License.LicenseID.ToString();

                lbCreatedBy.Text = clsGlobal._User.UserName;


                linkShowLicensesHistory.Enabled = true;

                PersonID = clsApplications.Find(_License.ApplicationID).ApplicationPersonID;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPersonLicenseHistoryForm frm = new ShowPersonLicenseHistoryForm(PersonID);
            frm.ShowDialog();
        }

        private void LinkShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DriverLicenseInfoForm frm = new DriverLicenseInfoForm(_NewLicense.LicenseID, 2);
            frm.ShowDialog();
        }

        private void btnIssueReplacment_Click(object sender, EventArgs e)
        {
            _Application = new clsApplications();
            _NewLicense = new clsLicense();

            clsLicense _OldLicense = clsLicense.FindByLicenseID(ctrlFindLicenseByFilter1._LicenseID);

            if (_OldLicense != null)
            {


                _Application.ApplicationStatus = "New";
                _Application.ApplicationDate = DateTime.Now;
                _Application.LastStatusDate = DateTime.Now;
                _Application.ApplicationPersonID = PersonID;
                _Application.CreateByUserID = clsGlobal._User.UserID;

                if (rbDamageLicense.Checked)
                {
                    _Application.PaidFees = ApplicationDamageFees;
                    _Application.ApplicationTypeID = ApplicatioType;

                }
                else
                {
                    _Application.PaidFees = ApplicationLostFees;
                    _Application.ApplicationTypeID = ApplicatioType;

                }


                if (_Application.Save())
                {
                    _NewLicense.ApplicationID = _Application.ApplicationID;
                    _NewLicense.CreateByUserID = clsGlobal._User.UserID;
                    _NewLicense.IssueDate = DateTime.Now;
                    _NewLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClasses.FindByID(_OldLicense.LicenseClasseID).DefaultValidityLength);
                    _NewLicense.DriverID = _OldLicense.DriverID;
                    _NewLicense.IsActive = true;
                    _NewLicense.IssueReason = IssueReason;
                    _NewLicense.LicenseClasseID = _OldLicense.LicenseClasseID;
                    _NewLicense.Notes = "Nice";
                    _NewLicense.PaidFees = clsLicenseClasses.FindByID(_OldLicense.LicenseClasseID).ClassFees;

                    if (_NewLicense.Save())
                    {
                        MessageBox.Show("Success, Adding a New License Done Successfully.", "Success",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lbLRenewlAppID.Text = _NewLicense.ApplicationID.ToString();
                        lbReplacmentLicenseID.Text = _NewLicense.LicenseID.ToString();
                        LinkShowLicense.Enabled = true;

                        _OldLicense.IsActive = false;

                        if (_OldLicense.Save())
                        {
                            // Success.
                        }
                        else
                        {
                            MessageBox.Show("Error, Old License Was Not Updated   .", "Warning",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Error, Adding a New License Failed .", "Warning",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {

                    MessageBox.Show("Error, Adding a New Application Failed .", "Warning",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Error,Old License Was Not Found .", "Warning",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIssueReplacment_MouseEnter(object sender, EventArgs e)
        {
            btnIssueReplacment.BackColor = Color.YellowGreen;
        }

        private void btnIssueReplacment_MouseLeave(object sender, EventArgs e)
        {
            btnIssueReplacment.BackColor = Color.White;
        }
    }
}
