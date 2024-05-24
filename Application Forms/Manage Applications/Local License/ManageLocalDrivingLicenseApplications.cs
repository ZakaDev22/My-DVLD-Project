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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace My_DVLD_Project
{
    public partial class ManageLocalDrivingLicenseApplications : Form
    {
        private DataTable _dataTable = new DataTable();
        public ManageLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewLocalDrivingLicensForm frm = new NewLocalDrivingLicensForm(-1);
            frm.ShowDialog();

            _RefreshDataGrideView();
        }

        private void ManageLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterBy.Visible = false;
            _RefreshDataGrideView();
        }

        private void _RefreshDataGrideView()
        {
            _dataTable = clsLocalLicense.GetAllLocalLicense_View();
            dataGridView1.DataSource = _dataTable;
            lbRecords.Text = dataGridView1.RowCount.ToString();
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            DataView dv = _dataTable.DefaultView;

            if (cbFilterBy.SelectedIndex == 1)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    dv.RowFilter = $"LocalDrivingLicenseApplicationID = {txtFilterBy.Text} ";
                }
               else
                {
                    _RefreshDataGrideView();
                }
            }
            else if (cbFilterBy.SelectedIndex == 2)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    dv.RowFilter = "NationalNo Like '%" + txtFilterBy.Text + "%'";
                }
                else
                {
                    _RefreshDataGrideView();
                }

            }
            else if (cbFilterBy.SelectedIndex == 3)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    dv.RowFilter = "FullName Like '%" + txtFilterBy.Text + "%'";
                }
                else
                {
                    _RefreshDataGrideView();
                }

            }
            else if (cbFilterBy.SelectedIndex == 4)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    dv.RowFilter = "Status Like '%" + txtFilterBy.Text + "%'";
                }
                else
                {
                    _RefreshDataGrideView();
                }

            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.SelectedIndex == 0)
            {
                txtFilterBy.Visible = false;
                _RefreshDataGrideView();
                return;
            }
            else
            {
                txtFilterBy.Visible = true;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.SelectedIndex == 1)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dataGridView1.CurrentRow.Cells[0].Value;

         

            if (MessageBox.Show("Are You Sure ❗ You Want To Cancel This Application. ❓❓", "Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                clsApplications App = clsApplications.Find(clsLocalLicense.Find(ID).ApplicationID);

                if (App != null)
                {

                    App.ApplicationStatus = "Cancelled";

                    if (App.Save())
                    {
                        MessageBox.Show("Application was Canceled Successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Application was  Not Canceled ❌.");
                    }
                }
                else
                {
                    MessageBox.Show(" Local Application was  Not Found ❗❗");
                }
            }

            _RefreshDataGrideView();
        }

        private void sechduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            int PassedTests = (int)dataGridView1.CurrentRow.Cells[5].Value;

            VisionTestAppointement frm = new VisionTestAppointement(ID,PassedTests);
            frm.ShowDialog();

            _RefreshDataGrideView();
        }

        private void sechToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int PassedTests = (int)dataGridView1.CurrentRow.Cells[5].Value;
            string Status = (string)dataGridView1.CurrentRow.Cells[6].Value;


            if (Status == "Cancelled")
            {
                issueDrivingLicense.Enabled = false;
                showLicense.Enabled = false;
                SechduleTestsMenue.Enabled = false;
                EditeApplicationMenue.Enabled = false;
                DeleteApplicationMenue.Enabled = true;
                CancelApplicationMenue.Enabled = false;
                return;
            }


            if (PassedTests == 3 && Status != "Completed")
            {

                SechduleTestsMenue.Enabled = false;
                EditeApplicationMenue.Enabled = true;
                DeleteApplicationMenue.Enabled = true;
                CancelApplicationMenue.Enabled = true;

                issueDrivingLicense.Enabled = true;
                showLicense.Enabled = false;

                return;

            }
            else if (PassedTests == 3 && Status == "Completed")
            {

                SechduleTestsMenue.Enabled = false;
                EditeApplicationMenue.Enabled = false;
                DeleteApplicationMenue.Enabled = false;
                CancelApplicationMenue.Enabled = false;

                issueDrivingLicense.Enabled = false;
                showLicense.Enabled = true;

                return;
            }

            else if (PassedTests != 3 && Status == "New")
            {
                SechduleTestsMenue.Enabled = true;
                EditeApplicationMenue.Enabled = true;
                DeleteApplicationMenue.Enabled = true;
                CancelApplicationMenue.Enabled = true;

                issueDrivingLicense.Enabled = false;
                showLicense.Enabled = false;
            }


            // Control the presentation of the appropriate exam for each stage by passed test Count

            switch (PassedTests)
                {
                    case 0:

                        sechduleWritenTestToolStripMenuItem.Enabled = false;
                        sechduleDrivingTestToolStripMenuItem.Enabled = false;

                        sechduleVisionTestToolStripMenuItem.Enabled = true;
                        break;

                    case 1:

                        sechduleVisionTestToolStripMenuItem.Enabled = false;
                        sechduleDrivingTestToolStripMenuItem.Enabled = false;

                        sechduleWritenTestToolStripMenuItem.Enabled = true;
                        break;

                    case 2:

                        sechduleVisionTestToolStripMenuItem.Enabled = false;
                        sechduleWritenTestToolStripMenuItem.Enabled = false;

                        sechduleDrivingTestToolStripMenuItem.Enabled = true;
                        break;
                }
            

        }

        private void sechduleWritenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            int PassedTests = (int)dataGridView1.CurrentRow.Cells[5].Value;

            VisionTestAppointement frm = new VisionTestAppointement(ID, PassedTests);
            frm.ShowDialog();

            _RefreshDataGrideView();
        }

        private void sechduleDrivingTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            int PassedTests = (int)dataGridView1.CurrentRow.Cells[5].Value;

            VisionTestAppointement frm = new VisionTestAppointement(ID, PassedTests);
            frm.ShowDialog();

            _RefreshDataGrideView();
        }

        private void EditeApplicationMenue_Click(object sender, EventArgs e)
        {
            int ID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            NewLocalDrivingLicensForm frm = new NewLocalDrivingLicensForm(ID);
            frm.ShowDialog();

            _RefreshDataGrideView();
        }

        private void DeleteApplicationMenue_Click(object sender, EventArgs e)
        {
            int LocalLicenseID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            //---------------------------------------------------------------------//

            clsApplications App = clsApplications.Find(clsLocalLicense.Find(LocalLicenseID).ApplicationID);


               if(MessageBox.Show("Are You Sure ❗ You Want To Delete This Application. ❓❓", "Info", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (clsLocalLicense.DeleteLicense(LocalLicenseID))
                {
                    App.ApplicationStatus = "Cancelled";
                    App.Save();
                    MessageBox.Show("License was Deleted Successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("License Deleting Failed .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
              
             _RefreshDataGrideView();
        }

        private void showAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalLicenseID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            int PassedTests = (int)dataGridView1.CurrentRow.Cells[5].Value;

            ShowLicenseApplicationDetailsForm frm = new ShowLicenseApplicationDetailsForm(LocalLicenseID, PassedTests);
            frm.ShowDialog();

        }

        private void issueDrivingLicense_Click(object sender, EventArgs e)
        {
            int LocalLicenseID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            int PassedTests = (int)dataGridView1.CurrentRow.Cells[5].Value;

            IssueLocalDrivingLicenseFirstTimeForm frm = new IssueLocalDrivingLicenseFirstTimeForm(LocalLicenseID, PassedTests);
            frm.ShowDialog();

            _RefreshDataGrideView();
        }

        private void showLicense_Click(object sender, EventArgs e)
        {
            // check Whay ctrlInfo Is Empthy.

            int LocalLicenseAppID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            DriverLicenseInfoForm frm = new DriverLicenseInfoForm(LocalLicenseAppID,1);
            frm.ShowDialog();
        }

        private void showPersonLicense_Click(object sender, EventArgs e)
        {
            // Show Person License History.

            int LocalLicenseAppID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            int PersonID = -1;
                PersonID = clsPeople.Find(clsApplications.Find(clsLocalLicense.Find(LocalLicenseAppID).ApplicationID).ApplicationPersonID).ID;

            ShowPersonLicenseHistoryForm frm = new ShowPersonLicenseHistoryForm(PersonID);
            frm.ShowDialog();
        }
    }
}
