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
    public partial class ctrlLicenseInformation : UserControl
    {
        public ctrlLicenseInformation()
        {
            InitializeComponent();
        }

        private void lnkViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int ID = Convert.ToInt32(lbApplicationID.Text);
            clsApplications App = clsApplications.Find(ID);
            PersonDetailsFrom frm = new PersonDetailsFrom(App.ApplicationPersonID);
            frm.ShowDialog();

        }

        public bool LoedLicenseInformation(int ID,int PassedTests)
        {
            bool IsFound = false;

            clsLocalLicense localLicense = clsLocalLicense.Find(ID);

            if (localLicense != null)
            {
                IsFound = true;

                lbDVLAppID.Text = localLicense.LocalDrivingLicenseApplicationID.ToString();
                lbLicenseClassName.Text = clsLicenseClasses.FindByID(localLicense.LicenseClassID).LicenseClassName.ToString();
                lbPassedTests.Text = $"{PassedTests}/3";

                clsApplications applications = clsApplications.Find(localLicense.ApplicationID);

                lbApplicationID.Text = applications.ApplicationID.ToString();
                lbDate.Text = applications.ApplicationDate.ToString();
                lbLastStatusDate.Text = applications.LastStatusDate.ToString();
                lbStatus.Text = applications.ApplicationStatus.ToString();
                lbFees.Text = applications.PaidFees.ToString();
                lbType.Text = clsApplicationTypes.Find(applications.ApplicationTypeID).ApplicationTypeTitle.ToString();
                lbApplicant.Text = clsPeople.Find(applications.ApplicationPersonID).FullName().ToString();
                lbCreatedBy.Text = clsUser.Find(applications.CreateByUserID).UserName.ToString();

            }


            return IsFound;
        }
    }
}
