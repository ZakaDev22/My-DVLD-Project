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
    public partial class ctrlShowInternationalLicenseInfo : UserControl
    {
        public ctrlShowInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        private void ctrlShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public bool LoadInternationalLicenseInfoByIntLicenseID(int internationalLicenseID)
        {
            bool IsFound = false;

            if(internationalLicenseID == -1)
            {
                MessageBox.Show("Failed. International License ID = -1 \n This Form Will Close  ", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            clsInternationalLicense _InternationalLicense = clsInternationalLicense.FindByInternationalLicenseID(internationalLicenseID);

            if (_InternationalLicense != null)
            {

                IsFound = true;

                clsApplications _application = clsApplications.Find(_InternationalLicense.ApplicationID);
                clsPeople _people = clsPeople.Find(_application.ApplicationPersonID);

                lbLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
                lbIntLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
                lbDriverName.Text = _people.FullName();
                lbNationalNo.Text = _people.NationalNo.ToString();
                lbGender.Text = _people.Gendor.ToString();
                lbIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
                lbDateofBirth.Text = _people.DateOfBirth.ToShortDateString();
                lbDriverID.Text = _InternationalLicense.DriverID.ToString();
                lbExpirationDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();
                lbApplicationID.Text = _InternationalLicense.ApplicationID.ToString();

                if (_InternationalLicense.IsActive)
                {
                    lbIsActive.Text = "Yes ✔";
                }
                else
                {
                    lbIsActive.Text = "No ❌";
                }

              
                if (_people.ImagePath != "")
                {
                    pcDriverPicture.ImageLocation = _people.ImagePath;
                }


            }

            return IsFound;
        }
    }
}
