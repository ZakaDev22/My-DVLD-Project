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
    public partial class NewInternationalDrivingLicense : Form
    {
        private clsApplications _application;
        private clsInternationalLicense _InternationalLicense;

        private int PersonID = -1;

        public NewInternationalDrivingLicense()
        {
            InitializeComponent();
        }

        private void NewInternationalDrivingLicense_Load(object sender, EventArgs e)
        {
            lbApplicationDate.Text = DateTime.Now.ToShortDateString();
            lbIssueDate.Text = DateTime.Now.ToShortDateString();
            lbFees.Text = clsApplicationTypes.Find(6).ApplicationFees.ToString();
            lbCreatedBy.Text = clsGlobal._User.UserName;

            lbExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();

            linkShowLicenseInfo.Enabled = false;
            linkShowLicensesHistory.Enabled = false;
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlLocalLicenseByFilter1_Load(object sender, EventArgs e)
        {

        }

        private void btnIsuue_Click(object sender, EventArgs e)
        {

           
           
              
                _application = new clsApplications();

                _application.ApplicationTypeID = 6;
                _application.ApplicationPersonID = clsApplications.Find(clsLicense.FindByLicenseID(ctrlFindLicenseByFilter1._LicenseID).ApplicationID).ApplicationPersonID;
                _application.ApplicationDate = DateTime.Now;
                _application.LastStatusDate = DateTime.Now;
                _application.ApplicationStatus = "Completed";
                _application.PaidFees = clsApplicationTypes.Find(6).ApplicationFees;
                _application.CreateByUserID = clsGlobal._User.UserID;

                if(_application.Save())
                {
                     _InternationalLicense = new clsInternationalLicense();

                    _InternationalLicense.ApplicationID = _application.ApplicationID;
                    _InternationalLicense.IssueDate = DateTime.Now;
                    _InternationalLicense.ExpirationDate = _InternationalLicense.IssueDate.AddYears(1);
                   _InternationalLicense.DriverID = clsLicense.FindByLicenseID(ctrlFindLicenseByFilter1._LicenseID).DriverID;
                    _InternationalLicense.IssuedUsingLocalLicenseID = ctrlFindLicenseByFilter1._LicenseID;
                    _InternationalLicense.CreateByUserID = clsGlobal._User.UserID;
                    _InternationalLicense.IsActive = true;


                if (_InternationalLicense.Save())
                    {
                        MessageBox.Show($" International License  Added Successfully. With ID = {_InternationalLicense.InternationalLicenseID}", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                        linkShowLicenseInfo.Enabled = true;
                        btnIsuue.Enabled = false;
                        lbIntLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
                        lbIntLicenseAppID.Text = _application.ApplicationID.ToString();
                        lbApplicationDate.Text = _application.ApplicationDate.ToShortDateString();
                        lbIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
                        lbExpirationDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();
                    }
                    else
                    {
                        MessageBox.Show("Failed. International License Was Not Added ", "Error",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Failed. Application  Was Not Added ", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

               
          }

        private void ctrlFindLicenseByFilter1_OnLicenseSelected(int obj)
        {
            int IsActive = obj;


            if (IsActive == 1)
            {
                btnIsuue.Enabled = true;

            }
            else
            {
                btnIsuue.Enabled = false;
            }

            clsLicense _License = clsLicense.FindByLicenseID(ctrlFindLicenseByFilter1._LicenseID);

            if (_License != null)
            {
                lbApplicationDate.Text = DateTime.Now.ToShortDateString();
                lbIssueDate.Text = DateTime.Now.ToShortDateString();

                lbExpirationDate.Text = DateTime.Now.AddYears(clsLicenseClasses.FindByID(_License.LicenseClasseID).DefaultValidityLength).ToShortDateString();

                lbFees.Text = _License.PaidFees.ToString();

                lbLocalLicenseID.Text = _License.LicenseID.ToString();

                lbCreatedBy.Text = clsGlobal._User.UserName;

                PersonID = clsApplications.Find(_License.ApplicationID).ApplicationPersonID;

                linkShowLicensesHistory.Enabled = true;

            }
        }

        private void linkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowInternationaLicenseInfoForm frm = new ShowInternationaLicenseInfoForm(_InternationalLicense.InternationalLicenseID);
            frm.ShowDialog();
        }

        private void linkShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            ShowPersonLicenseHistoryForm frm = new ShowPersonLicenseHistoryForm(PersonID);
            frm.ShowDialog();
        }
    }

       
}

