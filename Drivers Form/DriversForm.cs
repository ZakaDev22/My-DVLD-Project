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
    public partial class DriversForm : Form
    {
        private DataTable dataTable1;
        private DataView dataView;
        public DriversForm()
        {
            InitializeComponent();
        }

        private void DriversForm_Load(object sender, EventArgs e)
        {
          _RefreshDataGridView();
           cbFilterBy.SelectedIndex = 0;
        }

        private void _RefreshDataGridView()
        {
            dataTable1 = clsDrivers.GetAllDrivers();
            djvDriversList.DataSource = dataTable1;
            lbRecords.Text = djvDriversList.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilterBy.SelectedIndex == 0)
            {
                txtFilterBy.Visible = false;
            }
            else
            {
                txtFilterBy.Visible = true;
            }
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            dataView = dataTable1.DefaultView;

            if (cbFilterBy.SelectedIndex == 1)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    dataView.RowFilter = $" DriverID = {txtFilterBy.Text} ";
                }
                else
                {
                    _RefreshDataGridView();
                }
            }
            if (cbFilterBy.SelectedIndex == 2)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    dataView.RowFilter = $" PersonID = {txtFilterBy.Text} ";
                }
                else
                {
                    _RefreshDataGridView();
                }
            }
            if (cbFilterBy.SelectedIndex == 3)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    dataView.RowFilter = $" NationalNo Like '%" + txtFilterBy.Text + "%'";
                }
                else
                {
                    _RefreshDataGridView();
                }
            }
            if (cbFilterBy.SelectedIndex == 4)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    dataView.RowFilter = $" FullName Like '%" + txtFilterBy.Text + "%'";
                }
                else
                {
                    _RefreshDataGridView();
                }
            }
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 2)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
