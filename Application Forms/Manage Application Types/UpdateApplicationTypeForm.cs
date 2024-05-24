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
    public partial class UpdateApplicationTypeForm : Form
    {
        private int _AppID = -1;

        clsApplicationTypes _ApplicationType;

        public UpdateApplicationTypeForm(int ID)
        {
            InitializeComponent();
            _AppID = ID;
        }

        private void UpdateApplicationTypeForm_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationTypes.Find(_AppID);

            if(_ApplicationType == null )
            {
                MessageBox.Show($"Application Type With {_AppID} Was Not Found 😐 \n this form Will Close Now.", "Warning",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            lbID.Text =     _ApplicationType.ApplicationTypeID.ToString();
            txtTitle.Text = _ApplicationType.ApplicationTypeTitle.ToString();
            txtFees.Text =  _ApplicationType.ApplicationFees.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _ApplicationType.ApplicationTypeID = Convert.ToInt32(lbID.Text);
             _ApplicationType.ApplicationTypeTitle = txtTitle.Text;
            _ApplicationType.ApplicationFees = Convert.ToByte(txtFees.Text);

            if(_ApplicationType.Save())
            {
                MessageBox.Show($"Application Type With {_AppID} Was Updated Successfully ✔😎 ", "Success",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Application Type With {_AppID} was Not Updated ❌⚠ ", "Error",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
