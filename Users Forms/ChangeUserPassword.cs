using DVLD_BusinessLayer;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace My_DVLD_Project
{
    public partial class ChangeUserPassword : Form
    {
        private int _UserID = -1;

        clsUser _User;

        public ChangeUserPassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (clsUtil.ComputeHash(txtCurrentPassword.Text) != _User.Password)
            {
                e.Cancel = true;
                txtCurrentPassword.Focus();
                errorProvider1.SetError(txtCurrentPassword, "You Have To Set The Current Password ❓");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCurrentPassword, "");
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                e.Cancel = true;
                txtNewPassword.Focus();
                errorProvider1.SetError(txtNewPassword, "You Have To Set The New Password ❓");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNewPassword, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                e.Cancel = true;
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "The New Password Should Match The New Password ❗");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        private void ChangeUserPassword_Load(object sender, EventArgs e)
        {
            _User = clsUser.Find(_UserID);

            if (_User != null)
            {
                txtCurrentPassword.Select();

                ctrlUserInfo1.FiilUserDetials(_UserID);
            }
            else
            {
                MessageBox.Show($"This Form Will Be Closed because User with ID {_UserID} is Not Found",
                                  "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _User.Password = clsUtil.ComputeHash(txtNewPassword.Text);

            if (_User.Save())
            {
                MessageBox.Show($" User Password Changed Successfully 💯",
                                 "Success ✔", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($" Error ❌ New Password Is Field to Change ❓",
                                "Warning ❗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
