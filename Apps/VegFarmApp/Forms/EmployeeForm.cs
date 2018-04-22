using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;

namespace VegFarm.Forms
{
    public partial class EmployeeForm : Form, ISaveData
    {
        private RibbonControl _ribbonControl;

        public EmployeeForm(RibbonControl ribbonControl)
        {
            InitializeComponent();
            InitRibbonGroup(ribbonControl);
        }

        private void InitRibbonGroup(RibbonControl ribbonControl)
        {
            _ribbonControl = ribbonControl;
            var mainPage = _ribbonControl.Pages["Главная"];
            var pageGroup = mainPage.Groups.GetGroupByName("EmployeePageGroup");
            if (pageGroup != null)
            {
                return;
            }

            var d = new BarButtonItem();
            d.Caption = "Действие";            
            d.Id = 1;            
            d.Name = "SameAction";
            d.ItemClick += new ItemClickEventHandler(d_Click);

            pageGroup = new RibbonPageGroup();
            pageGroup.ItemLinks.Add(d);
            pageGroup.Name = "EmployeePageGroup";
            pageGroup.Text = "Сотрудники";            

            mainPage.Groups.Add(pageGroup);
        }

        private void d_Click(object sender, ItemClickEventArgs e)
        {
          
        }

        public void Save()
        {
            
        }
    }
}
