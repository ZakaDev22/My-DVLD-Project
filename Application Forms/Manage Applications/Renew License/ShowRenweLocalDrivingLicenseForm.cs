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
    public partial class ShowRenweLocalDrivingLicenseForm : Form
    {
        private short ApplicationFees;
        private int PersonID = -1;


        private  clsApplications _Application;
         private     clsLicense _NewLicense;

        public ShowRenweLocalDrivingLicenseForm()
        {
            InitializeComponent();
        }

        private void ShowRenweLocalDrivingLicenseForm_Load(object sender, EventArgs e)
        {
             ApplicationFees = clsApplicationTypes.Find(2).ApplicationFees;

            linkShowLicense.Enabled = false;
            linkShowLicensesHistory.Enabled = false;
            btnRenew.Enabled = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
             _Application = new clsApplications();
             _NewLicense = new clsLicense();

            clsLicense _OldLicense = clsLicense.FindByLicenseID(ctrlFindExpiredLicenseByFilter1._LicenseID);

            if (_OldLicense != null)
            {


                _Application.ApplicationStatus = "New";
                _Application.ApplicationDate = DateTime.Now;
                _Application.LastStatusDate  = DateTime.Now;
                _Application.ApplicationPersonID = PersonID;
                _Application.ApplicationTypeID = 2;
                _Application.CreateByUserID = clsGlobal._User.UserID;
                _Application.PaidFees = ApplicationFees;

                if (_Application.Save())
                {
                    _NewLicense.ApplicationID = _Application.ApplicationID;
                    _NewLicense.CreateByUserID = clsGlobal._User.UserID;
                    _NewLicense.IssueDate = DateTime.Now;
                    _NewLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClasses.FindByID(_OldLicense.LicenseClasseID).DefaultValidityLength);
                    _NewLicense.DriverID = _OldLicense.DriverID;
                    _NewLicense.IsActive = true;
                    _NewLicense.IssueReason = 2;
                    _NewLicense.LicenseClasseID = _OldLicense.LicenseClasseID;
                    _NewLicense.Notes = "Nice";
                    _NewLicense.PaidFees = clsLicenseClasses.FindByID(_OldLicense.LicenseClasseID).ClassFees;

                    if (_NewLicense.Save())
                    {
                        MessageBox.Show("Success, Adding a New License Done Successfully.", "Success",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lbRenewlAppID.Text = _NewLicense.ApplicationID.ToString();
                        lbRenewLicenseID.Text = _NewLicense.LicenseID.ToString();
                        linkShowLicense.Enabled = true;

                        _OldLicense.IsActive = false;

                       if( _OldLicense.Save())
                        {

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

        private void linkShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DriverLicenseInfoForm frm = new DriverLicenseInfoForm(_NewLicense.LicenseID,2);
            frm.ShowDialog();
        }

        private void linkShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (PersonID != -1)
            {
                ShowPersonLicenseHistoryForm frm = new ShowPersonLicenseHistoryForm(PersonID);
                frm.ShowDialog();
            }
        }

        private void ctrlFindExpiredLicenseByFilter1_OnLicenseSelected(int obj)
        {
            int IsExpired = obj;
            

            if (IsExpired == 1)
            {
                btnRenew.Enabled = true;

            }
            else
            {
                btnRenew.Enabled = false;
            }

            clsLicense _License = clsLicense.FindByLicenseID(ctrlFindExpiredLicenseByFilter1._LicenseID);

            if (_License != null)
            {
                lbApplicationDate.Text = DateTime.Now.ToShortDateString();
                lbIssueDate.Text = DateTime.Now.ToShortDateString();

                lbExpirationDate.Text = DateTime.Now.AddYears(clsLicenseClasses.FindByID(_License.LicenseClasseID).DefaultValidityLength).ToShortDateString();

                lbApplicationFeess.Text = ApplicationFees.ToString();
                lbLicenseFees.Text = _License.PaidFees.ToString();

                lbOldLicenseID.Text = _License.LicenseID.ToString();

                lbCreatedByUser.Text = clsGlobal._User.UserName;

                lbTotalFees.Text = (ApplicationFees + _License.PaidFees).ToString();

                linkShowLicensesHistory.Enabled = true;

                PersonID = clsApplications.Find(_License.ApplicationID).ApplicationPersonID;
            }
        }
    }
}
