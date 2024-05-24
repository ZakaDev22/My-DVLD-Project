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
    public partial class DriverLicenseInfoForm : Form
    {
        private int _LocalDvlIDOrLicenseID = -1;
        private int _AppIdOrLicenseID = -1;
        public DriverLicenseInfoForm(int localDvlID,int AppIdOrLicenseID)
        {
            InitializeComponent();
            _LocalDvlIDOrLicenseID = localDvlID;
            _AppIdOrLicenseID = AppIdOrLicenseID;
        }

        private void DriverLicenseInfoForm_Load(object sender, EventArgs e)
        {
            if(_AppIdOrLicenseID == 1)
            {
                ctrlDriverLicenseInfo1.LoadLicenseInformationByLocalAppID(_LocalDvlIDOrLicenseID);
            }
            else
            {
                ctrlDriverLicenseInfo1.LoadLicenseInformationByLicenseID(_LocalDvlIDOrLicenseID);
            }
           
        }
    }
}
