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
    public partial class ManageListInternationalLicenseApplications : Form
    {
        private DataTable dataTable;
        public ManageListInternationalLicenseApplications()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageListInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterBy.Visible = false;
            _RefreshDataGrideView();
        }

        private void _RefreshDataGrideView()
        {
            dataTable = clsInternationalLicense.GetAllInternationalLicenses();
            dataGridView1.DataSource = dataTable;
            lbRecords.Text = dataGridView1.RowCount.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
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

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 2 
                                              || cbFilterBy.SelectedIndex == 3 || cbFilterBy.SelectedIndex == 4)
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
                    dv.RowFilter = $"InternationalLicenseID = {txtFilterBy.Text} ";
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
                    dv.RowFilter = $"ApplicationID = {txtFilterBy.Text} ";
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
                    dv.RowFilter = $"DriverID = {txtFilterBy.Text} ";
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
                    dv.RowFilter = $"IssuedUsingLocalLicenseID = {txtFilterBy.Text} ";
                }
                else
                {
                    _RefreshDataGrideView();
                }

                
            }
        }

        private void btnAddInternationalLicense_Click(object sender, EventArgs e)
        {
            NewInternationalDrivingLicense frm = new NewInternationalDrivingLicense();
            frm.ShowDialog();

            _RefreshDataGrideView();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = (int)dataGridView1.CurrentRow.Cells[1].Value;
            int PersonID = clsApplications.Find(ApplicationID).ApplicationPersonID;

            PersonDetailsFrom frm = new PersonDetailsFrom(PersonID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            ShowInternationaLicenseInfoForm frm = new ShowInternationaLicenseInfoForm(InternationalLicenseID);
            frm.ShowDialog();
        }

        private void personLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = (int)dataGridView1.CurrentRow.Cells[1].Value;
            int PersonID = clsApplications.Find(ApplicationID).ApplicationPersonID;

            ShowPersonLicenseHistoryForm frm = new ShowPersonLicenseHistoryForm(PersonID);
            frm.ShowDialog();
        }
    }
}
