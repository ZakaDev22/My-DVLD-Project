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
    public partial class ctrlPersonInfoByFilter : UserControl
    {
        public int SelectedIndex { get; set; }
        public  int PersonID { get; set; }

        public bool FilterByIDEdite { get; set; }

        public ctrlPersonInfoByFilter()
        {
            InitializeComponent();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            AddEditePerson frm = new AddEditePerson(-1);

            frm.DataBack += frm_DataBack;

            frm.ShowDialog();
        }

        private void frm_DataBack(int ID)
        {
            PersonID = ID;
            txtFilterBy.Text = ID.ToString();
            ctrlPersonInfo1.LoadPersonInfoByID(PersonID);
            cbFilterBy.SelectedIndex = 1;
        }

      

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnSearch.PerformClick();
            }

            if (cbFilterBy.SelectedIndex == 1)
            {
                if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtFilterBy.Text))
            {
                return;
            }

            if(cbFilterBy.SelectedIndex == 0)
            {
                if (ctrlPersonInfo1.LoadPersonInfoByNationaNo(txtFilterBy.Text))
                {
                    PersonID = ctrlPersonInfo1.PersonID;
                }
                else
                {
                    PersonID = -1;
                }
            }
            else if(cbFilterBy.SelectedIndex == 1)
            {
                if(ctrlPersonInfo1.LoadPersonInfoByID(Convert.ToInt32( txtFilterBy.Text)))
                {
                    PersonID = ctrlPersonInfo1.PersonID;
                }
                else
                {
                    PersonID= -1;
                }
              
            }
        }

        private void ctrlPersonInfoByFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = SelectedIndex;

           // ctrlPersonInfo1.IsFind = false;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public bool LoadToUpdatePersonByID(int ID)
        {
            PersonID = ID;
            cbFilterBy.SelectedIndex = 1;
            txtFilterBy.Text = ID.ToString();
            gbFilter.Enabled = false;
            return ctrlPersonInfo1.LoadPersonInfoByID(ID);
        }

      

        private void ctrlPersonInfo1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
