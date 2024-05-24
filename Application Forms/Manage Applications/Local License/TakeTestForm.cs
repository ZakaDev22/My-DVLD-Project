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
    public partial class TakeTestForm : Form
    {
        private int _TestAppiontmentID = -1;
        private int LocalID = -1;
        private int _Trial = 0;
        private clsTestAppointements _Appointement;
        private clsTests _Test;

        private int _TestType = 0;
       
        public TakeTestForm(int LocalD_ID,int AppointmentID,int TestTypes,int Trial)
        {
            InitializeComponent();

            _TestAppiontmentID = AppointmentID;
            LocalID = LocalD_ID;
            
            _TestType = TestTypes;

            _Trial = Trial;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TakeTestForm_Load(object sender, EventArgs e)
        {
            lbDVLappID.Text = LocalID.ToString();

            lbTrial.Text = _Trial.ToString();

            lbLicenseClassName.Text = clsLicenseClasses.FindByID(clsLocalLicense.Find(LocalID).LicenseClassID).LicenseClassName;

            lbApplicantName.Text = clsPeople.Find(clsApplications.Find(clsLocalLicense.Find(LocalID).ApplicationID).ApplicationPersonID).FullName();

            lbFees.Text = clsTestTypes.Find(1).TestTypeFees.ToString();
             
            _Appointement = clsTestAppointements.Find(_TestAppiontmentID);

            lbDate.Text = _Appointement.AppointmentDate.ToShortDateString();

            lbFees.Text = clsTestTypes.Find(1).TestTypeFees.ToString();

            _Test = new clsTests();

            if (_TestType == 1)
            {
                lbTitle.Text = "Vision Test Appointment";
                pcTestPicture.Image = Resources.eye;
                this.Text = lbTitle.Text;
            }
            else if (_TestType == 2)
            {
                lbTitle.Text = "Written Test Appointment";
                pcTestPicture.Image = Resources.Whriten;
                this.Text = lbTitle.Text;
            }
            else if (_TestType == 3)
            {
                lbTitle.Text = "Driving Test Appointment";
                pcTestPicture.Image = Resources.driver_info;
                this.Text = lbTitle.Text;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(rbPass.Checked)
            {
                _Test.TestResult = true;
            }
            else
            {
                _Test.TestResult= false;
            }

            _Test.Notes = txtNotes.Text;

            _Test.TestAppointmentsID = _Appointement.TestAppointmentsID;

            _Test.CreatedByUserID = clsGlobal._User.UserID;

            if(_Test.Save())
            {
                _Appointement.IsLocked = true;

                _Appointement.Save();

                lbTestID.Text = _Test.TestID.ToString();

                MessageBox.Show("Test saved Successfully.");
            }
            else
            {
                MessageBox.Show("Test Was Not Saved.");
            }
        }
    }
}
