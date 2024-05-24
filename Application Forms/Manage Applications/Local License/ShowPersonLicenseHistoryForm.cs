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
    public partial class ShowPersonLicenseHistoryForm : Form
    {
        private int _PersonID = -1;

        public ShowPersonLicenseHistoryForm(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;

            if(_PersonID == -1)
            {
                MessageBox.Show("Error Person Was Not Found This Form Will Close Now","Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void ShowPersonLicenseHistoryForm_Load(object sender, EventArgs e)
        {
            ctrlPersonInfoByFilter1.LoadToUpdatePersonByID(_PersonID);

            _refreshLocalDataGridView();

            _refreshInternationalDataGridView();
        }

        private void _refreshLocalDataGridView()
        {
            djvLocalLicense.DataSource = clsLicense.GetPersonLicenseHistory(_PersonID) ;
            lbLocalRecords.Text = djvLocalLicense.RowCount.ToString() ;
        }

        private void _refreshInternationalDataGridView()
        {
             djvInternationalLicense.DataSource = clsInternationalLicense.GetPersonInternationalLicenseHistory(_PersonID);
              lbInternationalRecords.Text = djvInternationalLicense.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlPersonInfoByFilter1_Load(object sender, EventArgs e)
        {

        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseseID = -1;

            if (LicensesTapControl.SelectedIndex == 0)
            {
                LicenseseID = (int)djvLocalLicense.CurrentRow.Cells[0].Value;
                DriverLicenseInfoForm frm = new DriverLicenseInfoForm(LicenseseID, 2);
                frm.ShowDialog();
            }
            else
            {
                LicenseseID = (int)djvInternationalLicense.CurrentRow.Cells[0].Value;
                ShowInternationaLicenseInfoForm frm = new ShowInternationaLicenseInfoForm(LicenseseID);
                frm.ShowDialog();
            }
        }
    }
}
