using DVLD_BusinessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace My_DVLD_Project
{
    public partial class LogingForm : Form
    {

        bool btnLogingRightLeft = true;
        public LogingForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {

            if (txtUserName.Text == string.Empty || txtPassword.Text == string.Empty)
            {
                btnLogin.BackColor = Color.Red;

                if (btnLogingRightLeft)
                {
                    btnLogingRightLeft = false;

                    btnLogin.Location = new Point(5, 231);
                }
                else
                {
                    btnLogingRightLeft = true;

                    btnLogin.Location = new Point(195, 231);
                }
            }
            else
            {
                btnLogin.Location = new Point(100, 231);
                btnLogin.BackColor = Color.Green;
            }

            btnLogin.ForeColor = Color.Black;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.White;
            //   btnLogin.BackColor = Color.Transparent;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This Future Is Not Implemented Yet!");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsUser User;

            // Check If The Lenght Is 64 To Know If The Current User Has Remember Me or He Want To Write The Password By Himself
            if (txtPassword.Text.Length != 64)
            {
                User = clsUser.IsUserExiste(txtUserName.Text, clsUtil.ComputeHash(txtPassword.Text));
            }
            else
            {
                User = clsUser.IsUserExiste(txtUserName.Text, txtPassword.Text);
            }

            if (User != null)
            {
                if (User.IsActived == true)
                {
                    clsGlobal._User = User;

                    if (chkRememberMe.Checked)
                    {
                        //store username and password
                        //  clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

                        clsGlobal.RememberUsernameAndPasswordUsingRegistry(txtUserName.Text.Trim(), clsUtil.ComputeHash(txtPassword.Text.Trim()));

                    }
                    else
                    {
                        //store empty username and password
                        //   clsGlobal.RememberUsernameAndPassword("", "");

                        clsGlobal.RememberUsernameAndPasswordUsingRegistry("", "");

                    }

                    MainForm frm = new MainForm();

                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("This Account Is DesActiv Please Connect Your Admin", "Error",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalide UserName Or Password!", "Wrong Credentials",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void LogingForm_Load(object sender, EventArgs e)
        {
            // this code from the first virsion When We Saved The User Name And Password Using File System

            //if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            //{
            //    txtUserName.Text = UserName;
            //    txtPassword.Text = Password;
            //    chkRememberMe.Checked = true;
            //}
            //else
            //    chkRememberMe.Checked = false;

            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredentialFromRegistry(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }
    }
}
