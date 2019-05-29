﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UabDashboard.Classes;

namespace UabDashboard.View
{
    public partial class Form1 : Form
    {
        //novo evento
        public event EventHandler OnLoginAttempted;


        public Form1()
        {
            InitializeComponent();
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            OnLoginAttempted?.Invoke(this, EventArgs.Empty);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}