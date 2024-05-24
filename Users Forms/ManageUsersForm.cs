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
    public partial class ManageUsersForm : Form
    {
        private DataTable datatable;
        public ManageUsersForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _RefreshDataGridView()
        {
            datatable = clsUser.GetAllUsers();
           
            djvManageUsers.DataSource = datatable;
            lbRecords.Text = djvManageUsers.RowCount.ToString();
        }

        private void ManageUsersForm_Load(object sender, EventArgs e)
        {
            
            cbFilterBy.SelectedIndex = 0;
            _RefreshDataGridView();
            cbIsActive.Visible = false;
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            //DataView dataView = datatable.DefaultView;

            if (cbFilterBy.SelectedIndex == 1)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    datatable.DefaultView.RowFilter = $"UserID = {txtFilterBy.Text} ";
                }
                else
                {
                    _RefreshDataGridView();
                }
              
            }
            else if (cbFilterBy.SelectedIndex == 2)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    datatable.DefaultView.RowFilter = "UserName Like '%" + txtFilterBy.Text + "%' ";
                }
                else
                {
                    _RefreshDataGridView();
                }
               
            }
            else if (cbFilterBy.SelectedIndex == 3)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    datatable.DefaultView.RowFilter = $"PersonID = {txtFilterBy.Text} ";
                }
                else
                {
                    _RefreshDataGridView();
                }
                
            }
            else if (cbFilterBy.SelectedIndex == 4)
            {
                if (txtFilterBy.Text != string.Empty)
                {
                    datatable.DefaultView.RowFilter = "FullName Like '%" + txtFilterBy.Text + "%' ";
                }
                else
                {
                    _RefreshDataGridView();
                }
              
            }
           

        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0 || cbFilterBy.SelectedIndex == 3)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.SelectedIndex == 0)
            {
                txtFilterBy.Visible = false;
                cbIsActive.Visible = false;
                _RefreshDataGridView();
                return;
            }

            if(cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 2 
                || cbFilterBy.SelectedIndex == 3 || cbFilterBy.SelectedIndex == 4)
            {
                txtFilterBy.Visible = true;
                cbIsActive.Visible = false;
                return;
            }

            if(cbFilterBy.SelectedIndex == 5)
            {
                cbIsActive.SelectedIndex = 0;
                txtFilterBy.Visible = false;
                cbIsActive.Visible = true;
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            if (cbFilterBy.SelectedIndex == 5)
            {
                if (cbIsActive.SelectedIndex == 0)
                {
                    datatable.DefaultView.RowFilter = $"IsActive = {1} Or IsActive = {0}";
                    //  _RefreshDataGridView();
                }
                else if (cbIsActive.SelectedIndex == 1)
                {
                    datatable.DefaultView.RowFilter = $"IsActive = {1}";
                }
                else
                {
                    datatable.DefaultView.RowFilter = $"IsActive = {0}";
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddEditeUserForm frm = new AddEditeUserForm(-1);
            frm.ShowDialog();
            _RefreshDataGridView();
            
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            AddEditeUserForm frm = new AddEditeUserForm((int)djvManageUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshDataGridView();

            // refresh data grid view in Another Way.
          //  ManageUsersForm_Load(null, null);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            AddEditeUserForm frm = new AddEditeUserForm(-1);
            frm.ShowDialog();
            _RefreshDataGridView();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Show_User_Information frm = new Show_User_Information((int)djvManageUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshDataGridView();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // clsUser.Delete();

            int ID = (int)djvManageUsers.CurrentRow.Cells[0].Value;

            if (clsUser.DeleteUserByID(ID))
            {
                MessageBox.Show($" User Withe ID {ID} Was Deleted Successfully ✔","Success 💯",
                                    MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($" User Withe ID {ID} is Not Deleted ❌", "Field ❗❗",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _RefreshDataGridView();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ChangeUserPassword frm = new ChangeUserPassword((int)djvManageUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshDataGridView();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"This Future IS Not Implemented Yet ⚠", "Warning ❗",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"This Future IS Not Implemented Yet ⚠", "Warning ❗",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
