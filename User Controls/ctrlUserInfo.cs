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
    public partial class ctrlUserInfo : UserControl
    {
        public ctrlUserInfo()
        {
            InitializeComponent();
        }

        private void ctrlPersonInfo1_Load(object sender, EventArgs e)
        {

        }

        public bool FiilUserDetials(int ID)
        {
            bool IsFound = false;

            clsUser User = clsUser.Find(ID);

            if(User != null)
            {
                IsFound = true;

                ctrlPersonInfo1.LoadPersonInfoByID(User.PersonID);

                lbUserID.Text = User.UserID.ToString();
                lbUserName.Text = User.UserName;
                
                if(User.IsActived == true)
                {
                    lbIsActive.Text = "YES ✔ ";
                }
                else
                {
                    lbIsActive.Text = "NO ❌";
                }
            }


            return IsFound;
        }
    }
}
