using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_DVLD_Project
{
    public partial class ctrlPersonInfo : UserControl
    {
      

        public ctrlPersonInfo()
        {
            InitializeComponent();
        }

        public bool IsFind { get;set; }

        private void ctrlPersonInfo_Load(object sender, EventArgs e)
        {
            
        }

        private int _PersonID = -1;
        public int PersonID { get; set; }

     
        public  bool LoadPersonInfoByID(int ID)
        {
            bool IsFound = false;

            clsPeople Person = clsPeople.Find(ID);

            if (Person != null)
            {
                IsFound = true;

                _PersonID = ID;
                PersonID = ID;

                lbPersonID.Text = Person.ID.ToString();
                lbNationalNo.Text = Person.NationalNo.ToString();
                lbName.Text = (Person.FirstName.ToString() + " " + Person.SecondName.ToString() + " " + Person.ThirdName.ToString() + " " + Person.LastName.ToString());
                lbGendor.Text = Person.Gendor.ToString();
                lbDateOfBirth.Text = Person.DateOfBirth.ToString();
                lbEmail.Text = Person.Email.ToString();
                lbAddress.Text = Person.Address.ToString();
                lbPhone.Text = Person.Phone.ToString();
                lbCountry.Text = Person.NationalityCountryID.ToString();
               
                if(Person.ImagePath != "")
                {
                    pcPesonImage.ImageLocation = Person.ImagePath;
                }
               
            }
            else
            {
                IsFound = false;

                MessageBox.Show($"Person With ID {ID} Was Not Found!");
            }

            return IsFound;
        }

        public bool LoadPersonInfoByNationaNo(string NationalNo)
        {
            bool IsFound = false;

            clsPeople Person = clsPeople.Find(NationalNo);

            if (Person != null)
            {
                IsFound = true;

                _PersonID = Person.ID;
                PersonID = Person.ID;

                lbPersonID.Text = Person.ID.ToString();
                lbNationalNo.Text = Person.NationalNo.ToString();
                lbName.Text = (Person.FirstName.ToString() + " " + Person.SecondName.ToString() + " " + Person.ThirdName.ToString() + " " + Person.LastName.ToString());
                lbGendor.Text = Person.Gendor.ToString();
                lbDateOfBirth.Text = Person.DateOfBirth.ToString();
                lbEmail.Text = Person.Email.ToString();
                lbAddress.Text = Person.Address.ToString();
                lbPhone.Text = Person.Phone.ToString();
                lbCountry.Text = Person.NationalityCountryID.ToString();

                if (Person.ImagePath != "")
                {
                    pcPesonImage.ImageLocation = Person.ImagePath;
                }

            }
            else
            {
                IsFound = false;
                MessageBox.Show($"Person With National No {NationalNo} Was Not Found!");
            }

            return IsFound;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_PersonID != -1)
            {
                AddEditePerson frm = new AddEditePerson(_PersonID);

                frm.ShowDialog();

                LoadPersonInfoByID(_PersonID);
            }
            else
                return;
        }
    }
}
