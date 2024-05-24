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
    public partial class ShowRelaeseLicenseForm : Form
    {


        private int PersonID = -1;
        clsApplications _Application;
        clsDetainedLicenses _DetainedLicense;
        private short ApplicationFees = 0;

        private enum EnMode { New =0, Update = 1 };
        private EnMode _Mode = EnMode.New;

        private int _LicenseID = -1;
        


        public ShowRelaeseLicenseForm(int LicenseID)
        {
            InitializeComponent();

            _LicenseID = LicenseID;

            if(_LicenseID == -1)
            {
                _Mode = EnMode.New;
            }
            else
            {
                _Mode = EnMode.Update;
            }
        }

        private void ShowRelaeseLicenseForm_Load(object sender, EventArgs e)
        {
            ctrlFindLicenseByFilter1._Type = 4;

            ApplicationFees = clsApplicationTypes.Find(5).ApplicationFees;

            btnRelaese.Enabled = false;
            linkShowLicensesHistory.Enabled = false;
            LinkShowLicense.Enabled = false;

            if(_Mode == EnMode.Update)
            {
                ctrlFindLicenseByFilter1.LoadCtrlForUpdate(_LicenseID);
            }

        }

        private void linkShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowPersonLicenseHistoryForm frm = new ShowPersonLicenseHistoryForm(PersonID);
            frm.ShowDialog();

        }

        private void LinkShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DriverLicenseInfoForm frm = new DriverLicenseInfoForm(ctrlFindLicenseByFilter1._LicenseID, 2);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRelaese_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Are You Sure You Want To Release This License ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                  == DialogResult.Yes)
            {
                _Application = new clsApplications();

                _DetainedLicense = clsDetainedLicenses.FindByDetainedLicenseID(ctrlFindLicenseByFilter1._LicenseID);



                // the bug Is Here

                if (_DetainedLicense != null)
                {


                    _Application.ApplicationStatus = "New";
                    _Application.ApplicationDate = DateTime.Now;
                    _Application.LastStatusDate = DateTime.Now;
                    _Application.ApplicationPersonID = PersonID;
                    _Application.CreateByUserID = clsGlobal._User.UserID;

                    _Application.PaidFees = ApplicationFees;
                    _Application.ApplicationTypeID = 5;


                    if (_Application.Save())
                    {
                        _DetainedLicense.ReleaseApplicationID = _Application.ApplicationID;
                        _DetainedLicense.ReleasedByUserID = clsGlobal._User.UserID;
                        _DetainedLicense.ReleaseDate = DateTime.Now;
                        _DetainedLicense.IsReleased = true;

                        lbApplicationID.Text = _Application.ApplicationID.ToString();

                        if (_DetainedLicense.Save())
                        {
                            MessageBox.Show("Success, Release License Done Successfully.", "Success",
                                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lbDetaineID.Text = _DetainedLicense.DetainID.ToString();

                            LinkShowLicense.Enabled = true;

                            btnRelaese.Enabled = false;

                        }
                        else
                        {
                            MessageBox.Show("Error, Realease   License Failed .", "Warning",
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
                    MessageBox.Show("Error, License Was Not Found .", "Warning",
                                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Info,Relaese  License Was Canceled .", "Warning",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void ctrlFindLicenseByFilter1_OnLicenseSelected(int obj)
        {
            int IsLicenseActive = obj;


            if (IsLicenseActive == 1)
            {
                btnRelaese.Enabled = true;
            }
            else
            {
                btnRelaese.Enabled = false;
            }

            clsDetainedLicenses _DLicense = clsDetainedLicenses.FindByDetainedLicenseID(ctrlFindLicenseByFilter1._LicenseID);

            if (_DLicense != null)
            {
                lbDetainedDate.Text = _DLicense.DetainID.ToString();
                lbFineFees.Text = _DLicense.FineFees.ToString();
                lbLicenseID.Text = _DLicense.LicenseID.ToString();

                lbApplicationFees.Text = ApplicationFees.ToString();

                lbCreatedBy.Text = clsUser.Find(_DLicense.CreatedByUserID).UserName;

                lbTotal.Text = (ApplicationFees + _DLicense.FineFees).ToString();


                linkShowLicensesHistory.Enabled = true;

                PersonID = clsApplications.Find(clsLicense.FindByLicenseID(_DLicense.LicenseID).ApplicationID).ApplicationPersonID;
            }
        }
    }
}
