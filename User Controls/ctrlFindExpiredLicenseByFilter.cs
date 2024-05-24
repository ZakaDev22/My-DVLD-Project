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
    public partial class ctrlFindExpiredLicenseByFilter : UserControl
    {

        public event Action<int> OnLicenseSelected;

        protected virtual void LicenseSelected(int IsExpired)
        {
            Action<int> Handler = OnLicenseSelected;

            if (Handler != null)
            {
                Handler(IsExpired);
            }
        }

        public int _LicenseID = -1;
        public int IsExpired = -1;

        public ctrlFindExpiredLicenseByFilter()
        {
            InitializeComponent();
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(txtSearch.Text);

            clsLicense _License = new clsLicense();
            _License = clsLicense.FindByLicenseID(LicenseID);

            if (_License != null)
            {
                ctrlDriverLicenseInfo1.LoadLicenseInformationByLicenseID(_License.LicenseID);

                if (clsLicense.IsLicenseNotExpired(_License.LicenseID,_License.ExpirationDate))
                {
                    IsExpired = 1;
                    MessageBox.Show($"License With ID {_License.LicenseID} Is Not Expired Yet \n It Will End In {_License.ExpirationDate} \n" +
                                    $"  Please Select Another License ❗",
                                     "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    
                }
            }


            _LicenseID = _License.LicenseID;

            if(OnLicenseSelected != null)
            {
                OnLicenseSelected(IsExpired);
            }
        }
    }
}
