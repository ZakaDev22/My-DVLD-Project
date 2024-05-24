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
    public partial class ShowManageDetaineLicensesForm : Form
    {
        private DataTable dataTable;


        public ShowManageDetaineLicensesForm()
        {
            InitializeComponent();
        }

        private void _RefreshDataGrideView()
        {
            dataTable = clsDetainedLicenses.GetAllDetainedLicenses();
            dataGridView1.DataSource = dataTable;
            lbRecords.Text = dataGridView1.RowCount.ToString();
        }

        private void ShowManageDetaineLicensesForm_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterBy.Visible = false;
            cbIsRelease.Visible = false;
            _RefreshDataGrideView();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
            {
                txtFilterBy.Visible = false;
                cbIsRelease.Visible = false;
                _RefreshDataGrideView();
                return;
            }
            else
            {
                if(cbFilterBy.SelectedIndex != 2)
                  txtFilterBy.Visible = true;
            }

            if (cbFilterBy.SelectedIndex == 2)
            {
                txtFilterBy.Visible = false;

                cbIsRelease.Visible = true;
                cbIsRelease.SelectedIndex = 0;
            }
            else
            {
                if(cbFilterBy.SelectedIndex != 0)
                txtFilterBy.Visible = true;
                cbIsRelease.Visible = false;
            }
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 5)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dataTable.DefaultView;

            if (cbFilterBy.SelectedIndex == 1)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    dv.RowFilter = $"DetainID = {txtFilterBy.Text} ";
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
                    dv.RowFilter = $"NationalNo  Like '%" + txtFilterBy.Text + "%' ";
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
                    dv.RowFilter = $"FullName  Like '%" + txtFilterBy.Text + "%' ";
                }
                else
                {
                    _RefreshDataGrideView();
                }


            }
            else if (cbFilterBy.SelectedIndex == 5)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    dv.RowFilter = $"ReleaseApplicationID = {txtFilterBy.Text} ";
                }
                else
                {
                    _RefreshDataGrideView();
                }


            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbIsRelease_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = dataTable.DefaultView;

           
                if (cbIsRelease.SelectedIndex == 0)
                {
                    dv.RowFilter = $"IsReleased = {1} Or IsReleased = {0}";
                    return;
                }
                else if (cbIsRelease.SelectedIndex == 1)
                {
                    dv.RowFilter = $"IsReleased = {0}";
                }

                else
                {
                    dv.RowFilter = $"IsReleased = {1}";
                }
            
        }

        private void btnAddInternationalLicense_Click(object sender, EventArgs e)
        {
            ShowDetainedLicenseForm frm = new ShowDetainedLicenseForm();
            frm.ShowDialog();
            _RefreshDataGrideView();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            ShowRelaeseLicenseForm frm = new ShowRelaeseLicenseForm(-1);
            frm.ShowDialog();
            _RefreshDataGrideView();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dataGridView1.CurrentRow.Cells[1].Value;

            int PersonId = clsApplications.Find(clsLicense.FindByLicenseID(LicenseID).ApplicationID).ApplicationPersonID;

            PersonDetailsFrom frm = new PersonDetailsFrom(PersonId);
            frm.ShowDialog();

            _RefreshDataGrideView();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dataGridView1.CurrentRow.Cells[1].Value;

            DriverLicenseInfoForm frm = new DriverLicenseInfoForm(LicenseID, 2);
            frm.ShowDialog();

            _RefreshDataGrideView();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dataGridView1.CurrentRow.Cells[1].Value;

            int PersonId = clsApplications.Find(clsLicense.FindByLicenseID(LicenseID).ApplicationID).ApplicationPersonID;

            ShowPersonLicenseHistoryForm frm = new ShowPersonLicenseHistoryForm(PersonId);
            frm.ShowDialog();

            _RefreshDataGrideView();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dataGridView1.CurrentRow.Cells[1].Value;

            ShowRelaeseLicenseForm frm = new ShowRelaeseLicenseForm(LicenseID);
            frm.ShowDialog();

            _RefreshDataGrideView();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

            int LicenseID = (int)dataGridView1.CurrentRow.Cells[1].Value;

            if (clsDetainedLicenses.isDetainedLicense(LicenseID))
            {
                releaseLicenseToolStripMenuItem.Enabled = true;
            }
            else
            {
                releaseLicenseToolStripMenuItem.Enabled = false;

            }
        }
    }
}
