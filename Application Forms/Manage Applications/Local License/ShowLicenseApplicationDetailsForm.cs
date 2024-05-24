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
    public partial class ShowLicenseApplicationDetailsForm : Form
    {
        private int _LocalLicenseID = -1;
        private int _PassedTests = 0;
        public ShowLicenseApplicationDetailsForm(int LocalLicenseID,int PassedTests)
        {
            InitializeComponent();

            _LocalLicenseID = LocalLicenseID;
            _PassedTests = PassedTests;
        }

        private void ShowLicenseDetailsForm_Load(object sender, EventArgs e)
        {
            ctrlLicenseInformation1.LoedLicenseInformation(_LocalLicenseID, _PassedTests);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
