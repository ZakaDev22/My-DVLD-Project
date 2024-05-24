using DVLD_BusinessLayer;
using My_DVLD_Project.Properties;
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
    public partial class TestAppointmentForm : Form
    {
        private int _TestAppiontmentID = -1;
        private int LocalID = -1;
        private clsTestAppointements _TestAppointement;
        private clsApplications _Applications;

        private int _testType = 0;
        private int _IsFailed = 0;
        private int _Trial = 0;

        enum enMode { AddNew=0,Update=1};
        enMode _Mode;
        public TestAppointmentForm(int LocalD_ID, int AppointmentID,int TestType,int IsFailed,int Trial)
        {
            InitializeComponent();

            _TestAppiontmentID = AppointmentID;
            LocalID = LocalD_ID;
           _testType = TestType;
            _IsFailed = IsFailed;
            _Trial = Trial;

            if(AppointmentID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
            }

        }

        private void TestsForm_Load(object sender, EventArgs e)
        {

            gbRetakeTestInfo.Enabled = false;
            lbDVLappID.Text = LocalID.ToString();
            lbLicenseClassName.Text = clsLicenseClasses.FindByID(clsLocalLicense.Find(LocalID).LicenseClassID).LicenseClassName;

            lbApplicantName.Text = clsPeople.Find(clsApplications.Find(clsLocalLicense.Find(LocalID).ApplicationID).ApplicationPersonID).FullName();

            int TypeFees = clsTestTypes.Find(_testType).TestTypeFees;
            lbFees.Text = TypeFees.ToString();

           lbTrial.Text = _Trial.ToString();

            lbTotal.Text = TypeFees.ToString();

           

            if ( _Mode == enMode.AddNew )
            {
               _TestAppointement = new clsTestAppointements();

                if (_IsFailed != -1)
                {
                    _Applications = new clsApplications();
                    _Applications.ApplicationTypeID = 7;
                    _Applications.ApplicationDate = DateTime.Now;
                    _Applications.LastStatusDate = DateTime.Now;
                    _Applications.ApplicationStatus = "New";
                    _Applications.ApplicationPersonID = clsApplications.Find(clsLocalLicense.Find(LocalID).ApplicationID).ApplicationPersonID;
                    _Applications.CreateByUserID = clsGlobal._User.UserID;
                    _Applications.PaidFees = clsApplicationTypes.Find(7).ApplicationFees;

                    if (_Applications.Save())
                    {
                        _TestAppointement.RetakeTestApplicationID = _Applications.ApplicationID;

                        gbRetakeTestInfo.Enabled = true;
                        int ApplicationFees = clsApplications.Find(clsLocalLicense.Find(LocalID).ApplicationID).PaidFees;
                        lbRAppFees.Text = ApplicationFees.ToString();
                        lbTotal.Text = (TypeFees + ApplicationFees).ToString();
                        lbRAppTestID.Text = _Applications.ApplicationID.ToString();
                    }
                    else
                    {
                        _TestAppointement.RetakeTestApplicationID = -1;
                    }


                }
                else
                {
                    _TestAppointement.RetakeTestApplicationID = -1;

                }

                return;
            }

            _TestAppointement = clsTestAppointements.Find(_TestAppiontmentID);

            if (_TestAppointement == null)
            {
                MessageBox.Show($"this Form Will Be Closed Because  Contact With {_TestAppiontmentID} Is Not Found :-( ");
                this.Close();
                return;
            }

            if(_TestAppointement.IsLocked)
            {
                dateTimePicker1.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                dateTimePicker1.Enabled = true;
                btnSave.Enabled = true;
            }
            
            lbDate.Text =_TestAppointement.AppointmentDate.ToShortDateString();

            lbFees.Text = clsTestTypes.Find(_testType).TestTypeFees.ToString();

            lbTotal.Text = _TestAppointement.PaidFees.ToString();

            lbRAppTestID.Text = _TestAppointement.RetakeTestApplicationID.ToString();

            if (_testType == 1)
            {
                lbTitle.Text = "Vision Test Appointment";
                pcTestPicture.Image = Resources.eye;
                this.Text = lbTitle.Text;
            }
            else if (_testType == 2)
            {
                lbTitle.Text = "Written Test Appointment";
                pcTestPicture.Image = Resources.Whriten;
                this.Text = lbTitle.Text;
            }
            else if (_testType == 3)
            {
                lbTitle.Text = "Driving Test Appointment";
                pcTestPicture.Image = Resources.driver_info;
                this.Text = lbTitle.Text;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _TestAppointement.AppointmentDate = dateTimePicker1.Value;
            _TestAppointement.LocalDrivingLicenseID = LocalID;
            _TestAppointement.PaidFees = Convert.ToInt16(lbTotal.Text);
            _TestAppointement.TestTypeID = _testType;
            _TestAppointement.CreateByUserID = clsGlobal._User.UserID;
            _TestAppointement.IsLocked = false;

           


            if (_TestAppointement.Save())
            {
                MessageBox.Show("Data Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Error! : Data Is Not Saved Successfully.");
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
