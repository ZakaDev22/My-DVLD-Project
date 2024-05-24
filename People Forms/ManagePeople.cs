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
    public partial class ManagePeople : Form
    {
      private  DataTable datatable1 = new DataTable();

        public ManagePeople()
        {
            InitializeComponent();
            cbFilterPeople.SelectedIndex = 0;
            txtFilterBy.Visible = false;

          
        }

        private void cbFilterPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterPeople.SelectedIndex != 0)
            {
                txtFilterBy.Text = string.Empty;
                txtFilterBy.Visible = true;
            }
            else
            {
                txtFilterBy.Visible = false;
            }

          
        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshDataGridView();
        }

        public void _RefreshDataGridView()
        {
            datatable1 = clsPeople.GetAllPeople();
            djvPeopleInfo.DataSource = datatable1;
            lbRecords.Text = djvPeopleInfo.RowCount.ToString();

        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterPeople.SelectedIndex == 1 || cbFilterPeople.SelectedIndex == 7)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {

           // Teacher Solution .

           /* //string FilterColumn = "";
            ////Map Selected Filter to real Column name 
            //switch (cbFilterPeople.Text)
            //{
            //    case "Person ID":
            //        FilterColumn = "PersonID";
            //        break;

            //    case "National No.":
            //        FilterColumn = "NationalNo";
            //        break;

            //    case "First Name":
            //        FilterColumn = "FirstName";
            //        break;

            //    case "Second Name":
            //        FilterColumn = "SecondName";
            //        break;

            //    case "Third Name":
            //        FilterColumn = "ThirdName";
            //        break;

            //    case "Last Name":
            //        FilterColumn = "LastName";
            //        break;

            //    case "Nationality":
            //        FilterColumn = "CountryName";
            //        break;

            //    case "Gendor":
            //        FilterColumn = "GendorCaption";
            //        break;

            //    case "Phone":
            //        FilterColumn = "Phone";
            //        break;

            //    case "Email":
            //        FilterColumn = "Email";
            //        break;

            //    default:
            //        FilterColumn = "None";
            //        break;

            //}

            ////Reset the filters in case nothing selected or filter value conains nothing.
            //if (txtFilterBy.Text.Trim() == "" || FilterColumn == "None")
            //{
            //    datatable1.DefaultView.RowFilter = "";
            //    lbRecordNumber.Text = djvPeopleInfo.Rows.Count.ToString();
            //    return;
            //}


            //if (FilterColumn == "PersonID")
            //    //in this case we deal with integer not string.

            //    datatable1.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterBy.Text.Trim());
            //else
            //    datatable1.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterBy.Text.Trim());

            //lbRecordNumber.Text = djvPeopleInfo.Rows.Count.ToString(); */



            if (cbFilterPeople.SelectedIndex == 3)
            {
                datatable1.DefaultView.RowFilter = "FirstName like '%" + txtFilterBy.Text + "%'";
            }
            else if (cbFilterPeople.SelectedIndex == 1)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    datatable1.DefaultView.RowFilter = $"PersonID = {txtFilterBy.Text}";
                }
                else
                {
                    _RefreshDataGridView();
                }

            }
            else if (cbFilterPeople.SelectedIndex == 2)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    datatable1.DefaultView.RowFilter = "NationalNo like '%" + txtFilterBy.Text + "%'";
                }
                else
                {
                    _RefreshDataGridView();
                }

            }
            else if (cbFilterPeople.SelectedIndex == 4)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    datatable1.DefaultView.RowFilter = "SecondName like '%" + txtFilterBy.Text + "%'";
                }
                else
                {
                    _RefreshDataGridView();
                }

            }
            else if (cbFilterPeople.SelectedIndex == 5)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    datatable1.DefaultView.RowFilter = "ThirdName like '%" + txtFilterBy.Text + "%'";
                }
                else
                {
                    _RefreshDataGridView();
                }

            }
            else if (cbFilterPeople.SelectedIndex == 6)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    datatable1.DefaultView.RowFilter = "LastName like '%" + txtFilterBy.Text + "%'";
                }
                else
                {
                    _RefreshDataGridView();
                }

            }
            else if (cbFilterPeople.SelectedIndex == 7)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    datatable1.DefaultView.RowFilter = $"NationalityCountryID = {txtFilterBy.Text}";
                }
                else
                {
                    _RefreshDataGridView();
                }

            }
            else if (cbFilterPeople.SelectedIndex == 8)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    datatable1.DefaultView.RowFilter = "Email like '%" + txtFilterBy.Text + "%'";
                }
                else
                {
                    _RefreshDataGridView();
                }

            }
            else if (cbFilterPeople.SelectedIndex == 9)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    datatable1.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", "GendorCaption", txtFilterBy.Text.Trim());
                }
                else
                {
                    _RefreshDataGridView();
                }

            }
            else if (cbFilterPeople.SelectedIndex == 10)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    datatable1.DefaultView.RowFilter = "Phone like '%" + txtFilterBy.Text + "%'";
                }
                else
                {
                    _RefreshDataGridView();
                }

            }


        }

        private void cbFilterPeople_TextChanged(object sender, EventArgs e)
        {
            if(cbFilterPeople.Text == "None")
            {
                _RefreshDataGridView();
            }


        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            AddEditePerson frm = new AddEditePerson(-1);

            frm.ShowDialog();

            _RefreshDataGridView();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonDetailsFrom frm = new PersonDetailsFrom((int)djvPeopleInfo.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditePerson frm = new AddEditePerson(-1);

            frm.ShowDialog();

            _RefreshDataGridView();

        }

        private void editePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditePerson frm = new AddEditePerson((int)djvPeopleInfo.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            _RefreshDataGridView();
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)djvPeopleInfo.CurrentRow.Cells[0].Value;

           if(MessageBox.Show($"Are You Sure You Want To Delete This Person {ID} ?","Confirm To Delete",MessageBoxButtons.OKCancel
                                ,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clsPeople.DeletePerson(ID))
                {
                    MessageBox.Show($"Delete Person With ID {ID} Done Successfully. ");
                }
                else
                {
                    MessageBox.Show($"Delete Person With ID {ID} Field . ");
                }
            }
           else
            {
                MessageBox.Show($"Delete Person With ID {ID} Was Canceled . ");
            }

            _RefreshDataGridView();
        }

      

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Future is Not Implemented Yet!", "Send Email",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Future is Not Implemented Yet!", "Send Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
