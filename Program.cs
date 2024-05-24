using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_DVLD_Project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
              Application.Run(new LogingForm());


          //  Application.Run(new Form1());

            // Application.Run(new TestForm());

            // Application.Run(new ManageTestTypesForm());

            // Application.Run(new ManageApplicationTypesForm());

            //Application.Run(new ManageUsersForm());

            //  Application.Run(new MainForm());

            //  Application.Run(new AddEditePerson(-1));

            // Application.Run(new TestForm());


        }
    }
}
