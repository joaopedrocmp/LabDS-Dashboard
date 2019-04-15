using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UabDashboard
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form1 view = new Form1();
            IModel mdl = new LoginModel();
            IController cnt = new LoginController(view, mdl);
            Application.Run(view);
        }
    }
}
