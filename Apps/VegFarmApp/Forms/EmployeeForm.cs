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
using VerFarm.Kernel.Model.DTO;

namespace VegFarm.Forms
{
    public partial class EmployeeForm : Form, ISaveData
    {
        private CommunicationByForm _communicationForm;
        private RibbonControl _ribbonControl;

        public EmployeeForm(CommunicationByForm communicationForm)
        {
            InitializeComponent();
            _communicationForm = communicationForm;
            MdiParent = _communicationForm.MainForm;
            _ribbonControl = _communicationForm.RibbonControl;
            AddRibbonGroup();            
        }
        
        private void AddRibbonGroup()
        {
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

        private void DeleteRibbonGroup()
        {
            var mainPage = _ribbonControl.Pages["Главная"];
            var pageGroup = mainPage.Groups.GetGroupByName("EmployeePageGroup");
            if (pageGroup == null)
            {
                return;
            }
            mainPage.Groups.Remove(pageGroup);
            pageGroup = null;
        }

        public void InitDataAndShow()
        {
            Task<object> li = _communicationForm.DataManager.GetDataSourceAsync<EmployeeDTO>();
            li.Wait();
            Show();
        }

        private void d_Click(object sender, ItemClickEventArgs e)
        {
          
        }

        public void Save()
        {
            
        }

        private void EmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeleteRibbonGroup();
        }
    }
}
