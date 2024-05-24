using DVLD_BusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace My_DVLD_Project
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            lbDateAndTime.Text = DateTime.Now.ToString();
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            lbUser.Text = clsGlobal._User.UserName;
        }

        private void peToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void People_Click(object sender, EventArgs e)
        {
            ManagePeople frm = new ManagePeople();

            frm.ShowDialog();
        }

        private void toolStripMenuItem1_MouseEnter(object sender, EventArgs e)
        {
           // toolStripMenuItem1.BackColor = Color.DarkRed;
        }

        private void toolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
           // toolStripMenuItem1.BackColor = Color.OrangeRed;
        }

        private void singOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal._User = null;
            this.Close();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ManageUsersForm frm = new ManageUsersForm();
            frm.ShowDialog();
        }

        private void currentUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_User_Information frm = new Show_User_Information(clsGlobal._User.UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserPassword frm = new ChangeUserPassword(clsGlobal._User.UserID);
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageApplicationTypesForm frm = new ManageApplicationTypesForm();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageTestTypesForm frm = new ManageTestTypesForm();
            frm.ShowDialog();
        }

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLocalDrivingLicensForm frm = new NewLocalDrivingLicensForm(-1);
            frm.ShowDialog();
        }

        private void localLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageLocalDrivingLicenseApplications frm = new ManageLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void ShowDriversList_Click(object sender, EventArgs e)
        {
            DriversForm frm = new DriversForm();
            frm.ShowDialog();

        }

        private void internationalDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewInternationalDrivingLicense frm = new NewInternationalDrivingLicense();
            frm.ShowDialog();
        }

        private void internationalLicensApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageListInternationalLicenseApplications frm = new ManageListInternationalLicenseApplications();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRenweLocalDrivingLicenseForm frm = new ShowRenweLocalDrivingLicenseForm();
            frm.ShowDialog();
        }

        private void replacementForLostOrDamageLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowReplaceLicenseForDamageOrLostForm frm = new ShowReplaceLicenseForDamageOrLostForm();
            frm.ShowDialog();
        }

        private void detaineLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDetainedLicenseForm frm = new ShowDetainedLicenseForm();
            frm.ShowDialog();
        }

        private void relToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRelaeseLicenseForm frm = new ShowRelaeseLicenseForm(-1);
            frm.ShowDialog();
        }

        private void releaseDetainedDrivingLiceseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRelaeseLicenseForm form = new ShowRelaeseLicenseForm(-1);
            form.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageLocalDrivingLicenseApplications frm = new ManageLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void manageDetaindedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManageDetaineLicensesForm frm = new ShowManageDetaineLicensesForm();
            frm.ShowDialog();
        }
    }
}
