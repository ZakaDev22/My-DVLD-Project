using DVLD_BusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace My_DVLD_Project
{
    public partial class NewLocalDrivingLicensForm : Form
    {
        private short Fees = 15;
        private int _LocalDVLDID = 0;

        clsApplications _Application;
        clsLocalLicense _LocalLicense;

        enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode;

        public NewLocalDrivingLicensForm(int LocalDVL_ID)
        {
            InitializeComponent();

            _LocalDVLDID = LocalDVL_ID;

            if (_LocalDVLDID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
            }
        }

        private void _FillLicenseClassesInComboBox()
        {
            DataTable LicenseClassesTable = clsLicenseClasses.GetAllLicense();

            foreach (DataRow Row in LicenseClassesTable.Rows)
            {
                cbLicenseClassNames.Items.Add(Row["ClassName"]);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int PersonID = ctrlPersonInfoByFilter1.PersonID;
            int LicenseclassID = clsLicenseClasses.FindByName(cbLicenseClassNames.Text).LicenseClassID;

            if (clsDrivers.IsDriverExiste(PersonID))
            {
                clsDrivers Driver = clsDrivers.Find(PersonID);

               if(Driver != null)
                {
                    if(clsLicense.IsThisPersonHasThisLicense(Driver.DriverID,LicenseclassID))
                    {
                        MessageBox.Show(" Person Already Have a License With  \n The Same Applied Driving Class \n  Please Choose different Driving Class",
                                           "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return;
                    }
                }

            }
          
                _Application.ApplicationPersonID = PersonID;
                _Application.ApplicationDate = DateTime.Now;
                _Application.LastStatusDate = DateTime.Now;
                _Application.CreateByUserID = clsGlobal._User.UserID;
                _Application.ApplicationTypeID = 1;
                _Application.ApplicationStatus = "New";
                _Application.PaidFees = Fees;


                if (_Application.Save())
                {

                    _LocalLicense.ApplicationID = _Application.ApplicationID;
                    _LocalLicense.LicenseClassID = clsLicenseClasses.FindByName(cbLicenseClassNames.Text).LicenseClassID;


                    // the Bug Is Her ..
                    if (_LocalLicense.Save())
                    {
                        lbApplicationID.Text = _LocalLicense.LocalDrivingLicenseApplicationID.ToString();

                        if (_Mode == enMode.AddNew)
                        {
                            MessageBox.Show("  New Local License Was Added Successfully. ");
                        }
                        else
                        {
                            MessageBox.Show(" Local Driving License Was Updated Successfully. ");
                        }

                        lbNewEditeLicenseApplication.Text = "Update Local License Application";
                    }
                    else
                    {
                        MessageBox.Show(" Add New Local License Was Feiled ");
                    }
                }
                else
                {
                    MessageBox.Show(" Add New Application  Was Failed ❌ ");
                }
            
        }

        private void NewLocalDrivingLicensForm_Load(object sender, EventArgs e)
        {
            _FillLicenseClassesInComboBox();


            if (_Mode == enMode.AddNew)
            {
                

                _LocalLicense = new clsLocalLicense();
                _Application = new clsApplications();

                
                cbLicenseClassNames.SelectedIndex = 0;

                lbApplicationDate.Text = DateTime.Now.ToShortDateString();
                lbApplicationFees.Text = Fees.ToString();
                lbCreatedBy.Text = clsGlobal._User.UserName.ToString();

                return;
            }

            _LocalLicense =  clsLocalLicense.Find(_LocalDVLDID);

            if(_LocalLicense != null)
            {

                lbApplicationID.Text = _LocalLicense.LocalDrivingLicenseApplicationID.ToString();

                _Application = clsApplications.Find(_LocalLicense.ApplicationID);

                if (_Application != null)
                {
                    ctrlPersonInfoByFilter1.LoadToUpdatePersonByID(_Application.ApplicationPersonID);

                    cbLicenseClassNames.Text = clsLicenseClasses.FindByID(_Application.ApplicationTypeID).LicenseClassName.ToString();

                    lbApplicationDate.Text = _Application.ApplicationDate.ToString();
                    lbApplicationFees.Text = _Application.PaidFees.ToString();
                    lbCreatedBy.Text = _Application.CreateByUserID.ToString();
                }
                else
                {
                    MessageBox.Show($"This Application With {_LocalLicense.ApplicationID} Was Not Found \n this Form Will Close Now ");
                    this.Close();
                }

            }
            else
            {

                MessageBox.Show($"This Application With {_LocalDVLDID} Was Not Found \n this Form Will Close Now ");
                this.Close();
            }


        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
