﻿using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VegFarm.Forms
{
    public partial class MainForm : RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OrgStructureBarItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new EmployeeForm();
            form.MdiParent = this;
            form.Show();
        }

        private void SaveBarItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void RefreshBarItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
        }

        private void ExitBarItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }
    }
}