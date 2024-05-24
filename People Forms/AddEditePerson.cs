using DVLD_BusinessLayer;
using My_DVLD_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace My_DVLD_Project
{
    public partial class AddEditePerson : Form
    {
        public enum EnMode { AddNew = 0, Update = 1, };

        private EnMode _Mode;

       private int _PersonID = -1;

        clsPeople _Person;

        public delegate void DataBackEventHandler( int PersonID);
        public event DataBackEventHandler DataBack;


        public AddEditePerson(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;

            if(_PersonID == -1)
            {
                _Mode = EnMode.AddNew;
            }
            else
            {
                _Mode = EnMode.Update;
            }
        }

        private void _FillCountriesInComboBox()
        {
            DataTable CountryTable = clsCountry.GetAllCountries();

            foreach (DataRow Row in CountryTable.Rows)
            {
                cbCountries.Items.Add(Row["CountryName"]);
            }
        }

        private void AddEditePerson_Load(object sender, EventArgs e)
        {
            _FillCountriesInComboBox();

            rbMale.Checked = true;

            // Make The System Accepte Only Dates >= 18 Years
            //DateTime dt = DateTime.Now;
            //TimeSpan ts = new TimeSpan(6570, 0, 0, 0, 0);
            //dateTimePicker1.MaxDate = dt.Subtract(ts);

            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
            dateTimePicker1.MinDate = DateTime.Now.AddYears(-100);

            // Make Morroco The Selected Country
            // cbCountries.SelectedIndex = 118;

            cbCountries.SelectedIndex = cbCountries.FindString("Morocco");

            lnkRemoveImage.Visible = (pictureBox1.ImageLocation != null);

            if (_Mode == EnMode.AddNew)
            {
                lbAddEditePerson.Text = "Add New Person :-)";
                _Person = new clsPeople();
                return;
            }

            _Person = clsPeople.Find(_PersonID);

            if(_Person == null)
            {
                MessageBox.Show($"this Form Will Be Closed Because  Contact With {_Person.ID} Is Not Found :-( ");
                this.Close();
                return;
            }

            lbAddEditePerson.Text = $"Edite Person With ID {_Person.ID} :-)";
            lbPersonID.Text = _PersonID.ToString();

            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            dateTimePicker1.Value = _Person.DateOfBirth;
            txtNationalNo.Text = _Person.NationalNo;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            txtAddress.Text = _Person.Address;
            cbCountries.SelectedIndex = (_Person.NationalityCountryID - 1);

            if (_Person.Gendor == "Male")
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }

            if (_Person.ImagePath != "")
            {
                pictureBox1.Load(_Person.ImagePath);
            }

            lnkRemoveImage.Visible = (_Person.ImagePath != "");
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if(rbMale.Checked)
            {
                pictureBox1.Image = Resources.MaleImage;
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
            {
                pictureBox1.Image = Resources.FemaleImage;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int ID = _Person.ID;

            DataBack?.Invoke(ID);

            this.Close();
        }


        public static bool IsValidEmail(string Email)
        {
            Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);

            return EmailRegex.IsMatch(Email);
        }

        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != pictureBox1.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (pictureBox1.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pictureBox1.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pictureBox1.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandlePersonImage())
                return;

            int CountryID = clsCountry.FindCountryByName(cbCountries.Text).ID;

            _Person.FirstName = txtFirstName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.NationalNo = txtNationalNo.Text;
            _Person.Email = txtEmail.Text;
            _Person.Address = txtAddress.Text;
            _Person.DateOfBirth = dateTimePicker1.Value;
            _Person.Phone = txtPhone.Text;
            _Person.NationalityCountryID = CountryID;

            if(rbMale.Checked)
            {
                _Person.Gendor = "Male";
            }
            else
            {
                _Person.Gendor = "Female";
            }

            if (pictureBox1.ImageLocation != null)
            {
                _Person.ImagePath = pictureBox1.ImageLocation;
            }
            else
                _Person.ImagePath = "";

            if (_Person.Save())
            {
                MessageBox.Show("Data Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Error! : Data Is Not Saved Successfully.");
            }

            _Mode = EnMode.Update;

            lbAddEditePerson.Text = $"Edite Person With ID {_Person.ID}";
            lbPersonID.Text = _Person.ID.ToString();

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {

           if(txtEmail.Text != string.Empty)
            {
                if (IsValidEmail(txtEmail.Text))
                {
                    return;
                }
                else
                {

                    e.Cancel = true;
                    txtEmail.Focus();
                    ErrorProvider1.SetError(txtEmail, "You Have to Set a Valide Email");

                }
            }
           else
            {
                return;
            }
            
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                e.Cancel= true;
                txtFirstName.Focus();
                ErrorProvider1.SetError(txtFirstName, "You Have To Set You First Name");
            }
            else
            {
                e.Cancel = false;
                ErrorProvider1.SetError(txtFirstName, "");
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                e.Cancel = true;
                txtLastName.Focus();
                ErrorProvider1.SetError(txtLastName, "You Have To Set You Last Name");
            }
            else
            {
                e.Cancel = false;
                ErrorProvider1.SetError(txtLastName, "");
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNationalNo.Text))
            {
                e.Cancel = true;
                txtNationalNo.Focus();
                ErrorProvider1.SetError(txtNationalNo, "You Have To Set You National No");
            }
            else
            {
                e.Cancel = false;
                ErrorProvider1.SetError(txtNationalNo, "");
            }

            if (clsPeople.IsPersonExistByNationalNo(txtNationalNo.Text))
            {
                e.Cancel = true;
                txtNationalNo.Focus();
                ErrorProvider1.SetError(txtNationalNo, "This National No Is Used Form Another Person");
            }
            else
            {
                e.Cancel = false;
                ErrorProvider1.SetError(txtNationalNo, "");
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                e.Cancel = true;
                txtPhone.Focus();
                ErrorProvider1.SetError(txtPhone, "You Have To Set You  Phone");
            }
            else
            {
                e.Cancel = false;
                ErrorProvider1.SetError(txtPhone, "");
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                e.Cancel = true;
                txtAddress.Focus();
                ErrorProvider1.SetError(txtAddress, "You Have To Set You Address ");
            }
            else
            {
                e.Cancel = false;
                ErrorProvider1.SetError(txtAddress, "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                pictureBox1.Load(selectedFilePath);

                lnkRemoveImage.Visible = true;
            }
        }

        private void lnkRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           if(rbMale.Checked)
            {
                pictureBox1.Image = Resources.MaleImage;
            }
           else
            {
                pictureBox1.Image = Resources.FemaleImage;
            }

            lnkRemoveImage.Visible = false;
        }

        private void lbAddEditePerson_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
