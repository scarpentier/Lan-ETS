using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LanSoft
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Passwordbox pb = new Passwordbox();

            pb.ShowDialog();
            if (pb.IsPasswordValid)
            {
                Main main = new Main();

                main.LoadUser(pb.User);

                Application.Run(main);
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
