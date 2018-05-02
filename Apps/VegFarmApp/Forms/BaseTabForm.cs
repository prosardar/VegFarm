using DevExpress.XtraBars.Ribbon;
using System.Collections.Generic;
using System.Windows.Forms;
using VegFarm.Data;

namespace VegFarm.Forms
{
    public class BaseTabbedForm : Form, ISaveForm
    {
        protected CommunicationWithMainForm CommunicationForm;
        protected RibbonControl RibbonControl;
        protected Dictionary<string, object> DataSourceDic = new Dictionary<string, object>();

        public bool IsLoaded { get; set; }

        public BaseTabbedForm()
        {
            FormClosed += BaseTabForm_FormClosed;
        }

        public BaseTabbedForm(CommunicationWithMainForm communicationForm) : this()
        {
            CommunicationForm = communicationForm;
            MdiParent = CommunicationForm.MainForm;
            RibbonControl = CommunicationForm.RibbonControl;
            AddRibbonGroup();
        }

        private void BaseTabForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeleteRibbonGroup();
        }

        protected void DeleteRibbonGroup()
        {
            var mainPage = RibbonControl.Pages["Главная"];
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

        public virtual void AddRibbonGroup() { }

        public virtual void SaveData() { }

        public virtual void UpdateData() { }
    }
}