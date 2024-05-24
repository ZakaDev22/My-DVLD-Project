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
    public partial class IssueLocalDrivingLicenseFirstTimeForm : Form
    {
        private int _LocalLicenseID = -1;
        private int _PassedTests = 0;

        private clsLicense _License;
        private clsDrivers _Driver;
        private clsApplications _Application;

        public IssueLocalDrivingLicenseFirstTimeForm(int LocalDrivingLicenseID,int PassedTests)
        {
            InitializeComponent();

            _PassedTests = PassedTests;
            _LocalLicenseID = LocalDrivingLicenseID;
        }

        private void IssueLocalDrivingLicenseFirstTimeForm_Load(object sender, EventArgs e)
        {
            ctrlLicenseInformation1.LoedLicenseInformation(_LocalLicenseID, _PassedTests);
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
          

            int PersonID = clsApplications.Find(clsLocalLicense.Find(_LocalLicenseID).ApplicationID).ApplicationPersonID;

            // check if This Person A Driver in The Sestem. if No Add Driver   , if Yes Add License Without Driver
            if(clsDrivers.IsDriverExiste(PersonID))
            {
                _Driver = clsDrivers.Find(PersonID);

                if (_Driver == null)
                {
                    MessageBox.Show(" Driver Was Not Found ❓❓ \n this form will close now", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            else
            {

                _Driver = new clsDrivers();

                _Driver.PersonID = PersonID;
                _Driver.CreatedDate = DateTime.Now;
                _Driver.CreatedByUserID = clsGlobal._User.UserID;

                if (_Driver.Save())
                {
                    MessageBox.Show("Adding Driver Done Successfully.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Adding Driver Was Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

            _License = new clsLicense();

            _License.Notes = txtNotes.Text;
            _License.ApplicationID = clsLocalLicense.Find(_LocalLicenseID).ApplicationID;
            _License.LicenseClasseID = clsLocalLicense.Find(_LocalLicenseID).LicenseClassID;
            _License.IssueDate = DateTime.Now;
            _License.ExpirationDate = DateTime.Now.AddYears( clsLicenseClasses.FindByID(clsLocalLicense.Find(_LocalLicenseID).LicenseClassID).DefaultValidityLength);
            _License.DriverID = _Driver.DriverID;
            _License.CreateByUserID = clsGlobal._User.UserID;
            _License.IssueReason = 1;
            _License.PaidFees = clsLicenseClasses.FindByID(clsLocalLicense.Find(_LocalLicenseID).LicenseClassID).ClassFees;
            _License.IsActive = true;

            if (_License.Save())
            {
                _Application = clsApplications.Find(clsLocalLicense.Find(_LocalLicenseID).ApplicationID);

                _Application.ApplicationStatus = "Completed";
                _Application.Save();

                MessageBox.Show($"Adding License Done Successfully.\n You License ID = {_License.LicenseID}", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Adding License Was Failed.", "Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
