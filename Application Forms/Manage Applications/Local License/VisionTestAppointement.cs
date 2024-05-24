using DVLD_BusinessLayer;
using My_DVLD_Project.Properties;
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
    public partial class VisionTestAppointement : Form
    {
        private int _LocalDrivingLicenseID, _PassedTests;
        int TestType = 0;
        public VisionTestAppointement(int ID , int PassedTests)
        {
            InitializeComponent();
            _LocalDrivingLicenseID = ID;
            _PassedTests = PassedTests;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VisionTestAppointement_Load(object sender, EventArgs e)
        {
            TestType = _PassedTests;
            ctrlLicenseInformation1.LoedLicenseInformation(_LocalDrivingLicenseID, _PassedTests);
            _RefreshDataGrideView();

            if(TestType == 0)
            {
                lbTitle.Text = "Vision Test Appointment";
                pcTestPicture.Image = Resources.eye;
                this.Text = lbTitle.Text;
            }
            else if(TestType == 1)
            {
                lbTitle.Text = "Written Test Appointment";
                pcTestPicture.Image = Resources.Whriten;
                this.Text = lbTitle.Text;
            }
            else if(TestType == 2)
            {
                lbTitle.Text = "Driving Test Appointment";
                pcTestPicture.Image = Resources.driver_info;
                this.Text = lbTitle.Text;
            }
        }

        private void btnAddAppiontment_Click(object sender, EventArgs e)
        {
            // Check If This Person Failed in a Last Test 
            // And Make Automatically A new Retake Test Application + TestAppointment

           

            if (clsTestAppointements.IsAppointmentExiste(_LocalDrivingLicenseID, (TestType + 1)))
            {
                MessageBox.Show("This Application Already Has an Appointment,\n Please Try To Make The Test First."
                            ,"Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.RowCount != 0)
            {
                int TestAppointmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;

                if (clsTests.IsValideTest(TestAppointmentID))
                {
                    MessageBox.Show("This Person Already Pass this Test,\n Please go To  The Other Tests ."
                                , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

               
                if(!clsTests.IsPersonFailInTheLastTest(TestAppointmentID, (TestType + 1)))
                {
                    TestAppointmentForm Form = new TestAppointmentForm(_LocalDrivingLicenseID, -1, (TestType + 1), 1, dataGridView1.RowCount);
                    Form.ShowDialog();
                    _RefreshDataGrideView();
                    return;
                }
                
            }

            TestAppointmentForm frm = new TestAppointmentForm(_LocalDrivingLicenseID,-1,(TestType + 1), -1, dataGridView1.RowCount);
            frm.ShowDialog();
            _RefreshDataGrideView();
        }

        private void editeAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            TestAppointmentForm frm = new TestAppointmentForm(_LocalDrivingLicenseID,ID,(TestType+1), 1, dataGridView1.RowCount);
            frm.ShowDialog();
            _RefreshDataGrideView();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            // if test Appointment is Locked return Null to Take test

            if (!clsTestAppointements.IsAppointmentLocked(TestAppointmentID))
            {
                TakeTestForm frm = new TakeTestForm(_LocalDrivingLicenseID, TestAppointmentID, (TestType + 1), dataGridView1.RowCount);
                frm.ShowDialog();
                _RefreshDataGrideView();
            }
            else
            {
                MessageBox.Show("This Test Appointment Already Locked Try Test Another Appointment ❗","Warning",
                                            MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void _RefreshDataGrideView()
        {
            dataGridView1.DataSource = clsTestAppointements.GetallAppiontments(_LocalDrivingLicenseID, (TestType + 1));
            lbRecords.Text = dataGridView1.RowCount.ToString();
        }
    }
}
