﻿using DVLD_BusinessLayer;
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
    public partial class PersonDetailsFrom : Form
    {
        private int _PersonID = -1;
        public PersonDetailsFrom(int ID)
        {
            InitializeComponent();
            _PersonID = ID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlPersonInfo1_Load(object sender, EventArgs e)
        {
           
        }

        private void PersonDetailsFrom_Load(object sender, EventArgs e)
        {
            ctrlPersonInfo1.LoadPersonInfoByID(_PersonID);
        }

       
    }
}
