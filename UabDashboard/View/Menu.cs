﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UabDashboard.View
{
    public partial class Menu : Form
    {
        public event EventHandler OnFormClosed;

        public event EventHandler OnLoadTree;

        public event EventHandler OnLoadGraph;

        public event EventHandler OnNodeClick;

        public event EventHandler OnSaveButtonClick;

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed?.Invoke(this, EventArgs.Empty);
        }

        private void Menu_Shown(object sender, EventArgs e)
        {
            OnLoadTree?.Invoke(this, EventArgs.Empty);

            OnLoadGraph?.Invoke(this, EventArgs.Empty);
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OnNodeClick?.Invoke(this, EventArgs.Empty);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OnSaveButtonClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
