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
    public partial class ShowInternationaLicenseInfoForm : Form
    {
        private int _InternationalLicenseID = -1;
        public ShowInternationaLicenseInfoForm(int InternationalLicenseID)
        {
            InitializeComponent();

            _InternationalLicenseID = InternationalLicenseID;
        }

        private void ShowInternationaLicenseInfoForm_Load(object sender, EventArgs e)
        {
            ctrlShowInternationalLicenseInfo1.LoadInternationalLicenseInfoByIntLicenseID(_InternationalLicenseID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
