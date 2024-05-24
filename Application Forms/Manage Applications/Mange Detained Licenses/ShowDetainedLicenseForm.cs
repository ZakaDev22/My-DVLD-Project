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
using static System.Net.Mime.MediaTypeNames;

namespace My_DVLD_Project
{
    public partial class ShowDetainedLicenseForm : Form
    {

        private int PersonID = -1;
        clsDetainedLicenses _DetainedLicense;

        public ShowDetainedLicenseForm()
        {
            InitializeComponent();
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssueReplacment_Click(object sender, EventArgs e)
        {
           
           if(MessageBox.Show("Are You Sure You Want To detained This License ?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question)
                                 == DialogResult.Yes)
            {
                _DetainedLicense = new clsDetainedLicenses();

                clsLicense _License = clsLicense.FindByLicenseID(ctrlFindLicenseByFilter1._LicenseID);
                if (_License != null)
                {



                    _DetainedLicense.CreatedByUserID = clsGlobal._User.UserID;
                    _DetainedLicense.DetainDate = DateTime.Now;
                    _DetainedLicense.LicenseID = _License.LicenseID;

                    if(!String.IsNullOrWhiteSpace(txtFineFees.Text))
                    {
                        _DetainedLicense.FineFees = Convert.ToInt16(txtFineFees.Text);

                    }
                    else
                    {
                        _DetainedLicense.FineFees = 0;

                    }

                    _DetainedLicense.IsReleased = false;

                    if (_DetainedLicense.Save())
                    {
                        MessageBox.Show("Success, Detained  License Done Successfully.", "Success",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lbDetaineID.Text = _DetainedLicense.DetainID.ToString();
                        LinkShowLicense.Enabled = true;
                        btnDetained.Enabled = false;

                    }
                    else
                    {
                        MessageBox.Show("Error, Adding a New License Failed .", "Warning",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Error,  License Was Not Found .", "Warning",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           else
            {
                MessageBox.Show("Info,Detained  License Was Canceled .", "Warning",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        
        }

        private void ctrlFindLicenseByFilter1_OnLicenseSelected(int obj)
        {
            int IsLicenseActive = obj;


            if (IsLicenseActive == 1)
            {
                btnDetained.Enabled = true;
            }
            else
            {
                btnDetained.Enabled = false;
            }

            clsLicense _License = clsLicense.FindByLicenseID(ctrlFindLicenseByFilter1._LicenseID);

            if (_License != null)
            {
                lbDetainedDate.Text = DateTime.Now.ToShortDateString();



                lbLicenseID.Text = _License.LicenseID.ToString();


                linkShowLicensesHistory.Enabled = true;

                PersonID = clsApplications.Find(_License.ApplicationID).ApplicationPersonID;
            }
        }

        private void ShowDetainedLicenseForm_Load(object sender, EventArgs e)
        {
            ctrlFindLicenseByFilter1._Type = 3;

            btnDetained.Enabled = false;
            linkShowLicensesHistory.Enabled = false;
            LinkShowLicense.Enabled = false;

            lbDetainedDate.Text= DateTime.Now.ToShortDateString();
            lbCreatedBy.Text = clsGlobal._User.UserName;
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
    }
}
