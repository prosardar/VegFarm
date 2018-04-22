using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VegFarm.Data;

namespace VegFarm.Forms
{
    public partial class MainForm : RibbonForm, IMainRibbonForm
    {
        private CommunicationByForm _communicationForm;

        public MainForm()
        {
            InitializeComponent();
            _communicationForm = new CommunicationByForm(this);            
        }

        private void OrgStructureBarItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new EmployeeForm(_communicationForm);           
            form.InitDataAndShow();
        }

        private void SaveBarItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = xtraTabbedMdiManager.ActiveFloatForm as ISaveData;
        }

        private void RefreshBarItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
        }

        private void ExitBarItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        public RibbonControl GetRibbonControl()
        {
            return ribbonControl;
        }
    }
}
