using DevExpress.XtraBars.Ribbon;
using System.Collections.Generic;
using System.Windows.Forms;
using VegFarm.Data;

namespace VegFarm.Forms
{
    public abstract class BaseTabForm : Form, ISaveForm
    {
        protected CommunicationWithMainForm _communicationForm;
        protected RibbonControl _ribbonControl;
        protected Dictionary<string, object> _dataSourceDic = new Dictionary<string, object>();
        private CommunicationWithMainForm communicationForm;

        public bool IsLoaded { get; set; }

        public BaseTabForm()
        {
            FormClosed += BaseTabForm_FormClosed;
        }

        public BaseTabForm(CommunicationWithMainForm communicationForm) : this()
        {
            _communicationForm = communicationForm;
            MdiParent = _communicationForm.MainForm;
            _ribbonControl = _communicationForm.RibbonControl;
            AddRibbonGroup();
        }

        private void BaseTabForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeleteRibbonGroup();
        }

        protected void DeleteRibbonGroup()
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

        public void InitData()
        {
            if (IsLoaded)
            {
                return;
            }
            UpdateData();
            IsLoaded = true;
        }

        public void ShowAndBringToFront()
        {
            Show();
            BringToFront();
        }

        public abstract void AddRibbonGroup();

        public abstract void SaveData();

        public abstract void UpdateData();
    }
}