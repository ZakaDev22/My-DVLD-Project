using DVLD_BusinessLayer;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace My_DVLD_Project
{
    public partial class AddEditeUserForm : Form
    {
        public enum EnMode { AddNew = 0, Update = 1, };

        private EnMode _Mode;

        private int _UserID = -1;
        clsUser _User;

        public AddEditeUserForm(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;

            if (_UserID == -1)
            {
                _Mode = EnMode.AddNew;
            }
            else
            {

                _Mode = EnMode.Update;
            }
        }

        private void AddEditeUserForm_Load(object sender, EventArgs e)
        {
            if (_Mode == EnMode.AddNew)
            {
                lbAddEditeUser.Text = "Add New User 😁👫";
                _User = new clsUser();
                return;
            }

            _User = clsUser.Find(_UserID);

            lbAddEditeUser.Text = $"Edite User With ID {_User.UserID} 🙄";
            lbUserID.Text = _UserID.ToString();

            ctrlPersonInfoByFilter1.LoadToUpdatePersonByID(_User.PersonID);
            ctrlPersonInfoByFilter1.SelectedIndex = 1;


            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;

            chkIsActive.Checked = _User.IsActived;


        }

        private void tabLoginInfo_Click(object sender, EventArgs e)
        {
            /////////////////
        }

        private void tabPersonInfo_Click(object sender, EventArgs e)
        {
            ////////////////
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonInfoByFilter1.PersonID == 0)
            {
                MessageBox.Show("You Have To Find A Person To set New User",
                          "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clsUser.IsUserExisteByID(ctrlPersonInfoByFilter1.PersonID))
            {
                MessageBox.Show("This Person Is Already a User In The System \n PleaseSelect Another Person",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // .Click
                tabControl1.SelectedTab = tabLoginInfo;
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider1.SetError(txtUserName, "You Have To Set The User Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "You Have To Set The Password ");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                e.Cancel = true;
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "You Have To Set The Confirm Password ");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }

            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "The Confirm Password Should Match The Password ");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        private void ctrlPersonInfoByFilter1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _User.PersonID = ctrlPersonInfoByFilter1.PersonID;
            _User.UserName = txtUserName.Text;
            _User.IsActived = chkIsActive.Checked;

            //========================
            // Save The Hash Password For Safety From Hackers 
            _User.Password = clsUtil.ComputeHash(txtPassword.Text);

            if (_User.Save())
            {
                MessageBox.Show("User Was Added Successfully. 😁😁", "Success.",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Error ❗❗ User Was Not Added. ⛔❓", "Field.",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
