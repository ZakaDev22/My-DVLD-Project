using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_DVLD_Project
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ctrlDriverLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        public bool LoadLicenseInformationByLocalAppID(int LocalDrivingLicenseID)
        {
            bool IsFound = false;

           
                
                clsLicense License = clsLicense.FindByApplicatioID(clsLocalLicense.Find(LocalDrivingLicenseID).ApplicationID);

           if (License != null)
           {

             IsFound = true;

            clsApplications _application = clsApplications.Find(License.ApplicationID);
                clsPeople _people = clsPeople.Find(_application.ApplicationPersonID);

             lbLicenseID.Text = License.LicenseID.ToString();
             lbClassName.Text = clsLicenseClasses.FindByID(License.LicenseClasseID).LicenseClassName.ToString();
             lbDriverName.Text = _people.FullName();
             lbNationalNo.Text = _people.NationalNo.ToString();
             lbGender.Text =     _people.Gendor.ToString();
             lbIssueDate.Text = License.IssueDate.ToShortDateString();
             lbNotes.Text = License.Notes.ToString();
             lbDateofBirth.Text = _people.DateOfBirth.ToShortDateString();
             lbDriverID.Text = License.DriverID.ToString();
             lbExpirationDate.Text = License.ExpirationDate.ToShortDateString();
             
                if(License.IsActive)
                {
                    lbIsActive.Text = "Yes ✔";
                }
                else
                {
                    lbIsActive.Text = "No ❌";
                }

                // 1-FirstTime, 2-Renew, 3-Replacement for Damaged, 4- Replacement for Lost.

                switch(License.IssueReason)
                {
                    case 1:
                        lbIssueReason.Text = "FirstTime";
                        break;

                    case 2:
                        lbIssueReason.Text = "Renew";
                        break;

                    case 3:
                        lbIssueReason.Text = "Replacement for Damaged";
                        break;

                    case 4:
                        lbIssueReason.Text = "Replacement for Lost.";
                        break;
                }

                if(_people.ImagePath != "")
                {
                    pcDriverPicture.ImageLocation = _people.ImagePath;
                }
               
                if(clsDetainedLicenses.isDetainedLicense(License.LicenseID))
                {
                    lbIsDetained.Text = "Yes";
                }
                else
                {
                    lbIsDetained.Text = "No";
                }
               
            }

                return IsFound;
        }

        public bool LoadLicenseInformationByLicenseID(int LicenseID)
        {
            bool IsFound = false;



            clsLicense License = clsLicense.FindByLicenseID(LicenseID);

            if (License != null)
            {

                IsFound = true;

                clsApplications _application = clsApplications.Find(License.ApplicationID);
                clsPeople _people = clsPeople.Find(_application.ApplicationPersonID);

                lbLicenseID.Text = License.LicenseID.ToString();
                lbClassName.Text = clsLicenseClasses.FindByID(License.LicenseClasseID).LicenseClassName.ToString();
                lbDriverName.Text = _people.FullName();
                lbNationalNo.Text = _people.NationalNo.ToString();
                lbGender.Text = _people.Gendor.ToString();
                lbIssueDate.Text = License.IssueDate.ToShortDateString();
                lbNotes.Text = License.Notes.ToString();
                lbDateofBirth.Text = _people.DateOfBirth.ToShortDateString();
                lbDriverID.Text = License.DriverID.ToString();
                lbExpirationDate.Text = License.ExpirationDate.ToShortDateString();
                lbIsDetained.Text = "No";

                if (License.IsActive)
                {
                    lbIsActive.Text = "Yes ✔";
                }
                else
                {
                    lbIsActive.Text = "No ❌";
                }

                // 1-FirstTime, 2-Renew, 3-Replacement for Damaged, 4- Replacement for Lost.

                switch (License.IssueReason)
                {
                    case 1:
                        lbIssueReason.Text = "FirstTime";
                        break;

                    case 2:
                        lbIssueReason.Text = "Renew";
                        break;

                    case 3:
                        lbIssueReason.Text = "Replacement for Damaged";
                        break;

                    case 4:
                        lbIssueReason.Text = "Replacement for Lost.";
                        break;
                }

                if (_people.ImagePath != "")
                {
                    pcDriverPicture.ImageLocation = _people.ImagePath;
                }


                if (clsDetainedLicenses.isDetainedLicense(License.LicenseID))
                {
                    lbIsDetained.Text = "Yes";
                }
                else
                {
                    lbIsDetained.Text = "No";
                }

            }

            return IsFound;
        }


    }
}
