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
    public partial class UpdateTestTypesForm : Form
    {
        private int TestID = -1;

        private clsTestTypes _TestType;

        public UpdateTestTypesForm(int ID)
        {
            InitializeComponent();
            TestID = ID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _TestType.TestTypeID = Convert.ToInt32(lbID.Text);
            _TestType.TestTypeTitle = txtTitle.Text;
            _TestType.TestTypeDescription = txtDescription.Text;
            _TestType.TestTypeFees = Convert.ToByte(txtFees.Text);

            if (_TestType.Save())
            {
                MessageBox.Show($"Test Type With {TestID} Was Updated Successfully ✔😎 ", "Success",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Test Type With {TestID} was Not Updated ❌⚠ ", "Error",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void UpdateTestTypesForm_Load(object sender, EventArgs e)
        {
            _TestType = clsTestTypes.Find(TestID);

            if (_TestType == null)
            {
                MessageBox.Show($"Test Type With ID : {TestID} Was Not Found 😐 \n this form Will Close Now.", "Warning",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            lbID.Text = _TestType.TestTypeID.ToString();
            txtTitle.Text = _TestType.TestTypeTitle.ToString();
            txtDescription.Text = _TestType.TestTypeDescription.ToString();
            txtFees.Text = _TestType.TestTypeFees.ToString();

        }
    }
}
