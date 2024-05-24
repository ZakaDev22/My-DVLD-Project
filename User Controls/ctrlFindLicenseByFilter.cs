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


    public partial class ctrlFindLicenseByFilter : UserControl
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
        public int IsLicenseActive = -1;
        public int _Type { get; set; }


        public ctrlFindLicenseByFilter()
        {
            InitializeComponent();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(txtSearch.Text);

          //  clsLicense _License  = new clsLicense();

            clsLicense _License = clsLicense.FindByLicenseID(LicenseID);

            if (_License != null)
            {
                ctrlDriverLicenseInfo1.LoadLicenseInformationByLicenseID(_License.LicenseID);


                if (_Type == 1)
                {
                    if (!clsLicense.IsLicenseActiveAndType_3(LicenseID))
                    {

                        MessageBox.Show($"License With ID {LicenseID} Is Not Found Or Not Active Or \n License Class Type Not 3 ❗",
                                         "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        IsLicenseActive = 1;
                    }
                }
                else if (_Type == 2)

                {
                    if (!clsLicense.IsLicenseActive(LicenseID))
                    {

                        MessageBox.Show($"License With ID {LicenseID} Is Not Found Or Not Active  ❗",
                                         "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        IsLicenseActive = 1;
                    }
                }
                else if (_Type == 3)
                {

                    if (clsDetainedLicenses.isDetainedLicense(LicenseID))
                    {

                        MessageBox.Show($"License With ID {LicenseID} Is Already Detained, Choose Another One ❗",
                                         "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        IsLicenseActive = 1;
                    }
                }
                else if (_Type == 4)
                {

                    if (!clsDetainedLicenses.isDetainedLicense(LicenseID))
                    {

                        MessageBox.Show($"License With ID {LicenseID} Is Already Relaese, Choose Another One ❗",
                                         "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        IsLicenseActive = 1;
                    }
                }
            }

           
            _LicenseID = _License.LicenseID;

            if (OnLicenseSelected != null)
            {
                OnLicenseSelected(IsLicenseActive);
            }
        }

        public void LoadCtrlForUpdate(int LicenseID)
        {
           

            clsLicense _License = new clsLicense();
            _License = clsLicense.FindByLicenseID(LicenseID);

            if (_License != null)
            {
                ctrlDriverLicenseInfo1.LoadLicenseInformationByLicenseID(_License.LicenseID);


                if (_Type == 1)
                {
                    if (!clsLicense.IsLicenseActiveAndType_3(LicenseID))
                    {

                        MessageBox.Show($"License With ID {LicenseID} Is Not Found Or Not Active Or \n License Class Type Not 3 ❗",
                                         "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        IsLicenseActive = 1;
                    }
                }
                else if (_Type == 2)

                {
                    if (!clsLicense.IsLicenseActive(LicenseID))
                    {

                        MessageBox.Show($"License With ID {LicenseID} Is Not Found Or Not Active  ❗",
                                         "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        IsLicenseActive = 1;
                    }
                }
                else if (_Type == 3)
                {

                    if (clsDetainedLicenses.isDetainedLicense(LicenseID))
                    {

                        MessageBox.Show($"License With ID {LicenseID} Is Already Detained, Choose Another One ❗",
                                         "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        IsLicenseActive = 1;
                    }
                }
                else if (_Type == 4)
                {

                    if (!clsDetainedLicenses.isDetainedLicense(LicenseID))
                    {

                        MessageBox.Show($"License With ID {LicenseID} Is Already Relaese, Choose Another One ❗",
                                         "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        txtSearch.Text = LicenseID.ToString();
                        groupBox1.Enabled = false;
                        IsLicenseActive = 1;
                    }
                }
            }


            _LicenseID = _License.LicenseID;

            if (OnLicenseSelected != null)
            {
                OnLicenseSelected(IsLicenseActive);
            }
        }
    }
}
