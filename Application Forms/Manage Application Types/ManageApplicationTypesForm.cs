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
    public partial class ManageApplicationTypesForm : Form
    {
        public ManageApplicationTypesForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageApplicationTypesForm_Load(object sender, EventArgs e)
        {
            _RefreshDataGrideView();
        }

        private void _RefreshDataGrideView()
        {
            djvManageApplicationTypes.DataSource = clsApplicationTypes.GetAllApplication();
            lbRecords.Text = djvManageApplicationTypes.RowCount.ToString();
        }

        private void editeApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)djvManageApplicationTypes.CurrentRow.Cells[0].Value;

            UpdateApplicationTypeForm frm = new UpdateApplicationTypeForm(ID);
            frm.ShowDialog();

            _RefreshDataGrideView();
        }
    }
}
