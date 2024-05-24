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
    public partial class ManageTestTypesForm : Form
    {
        public ManageTestTypesForm()
        {
            InitializeComponent();
        }

        private void ManageTestTypesForm_Load(object sender, EventArgs e)
        {
            _RefreshDataGridView();
        }

        private void _RefreshDataGridView()
        {
            djvTestTypes.DataSource = clsTestTypes.GetAllTestTypes();
            lbRecords.Text = djvTestTypes.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editeTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)djvTestTypes.CurrentRow.Cells[0].Value;

            UpdateTestTypesForm frm = new UpdateTestTypesForm(ID);
            frm.ShowDialog();

            _RefreshDataGridView();
        }
    }
}
