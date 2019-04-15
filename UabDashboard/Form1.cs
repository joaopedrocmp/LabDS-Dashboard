using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UabDashboard
{
    public partial class Form1 : Form, IView, IModelObserver
    {
        IController controller;
        public event ViewHandler<IView> Changed;

        public void SetController(IController cont)
        {
            controller = cont;
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void ReturnValidation(IModel m, ModelEventArgs e)
        {           
            MessageBox.Show(e.userValidation.ToString());
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if((txbPassword.Text != "") && (txbUsername.Text != ""))
            {
                controller.CheckUser(txbUsername.Text,txbPassword.Text);
            }
        }

    }
}
