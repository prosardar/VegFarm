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
        private CommunicationWithMainForm _communicationForm;
        private Dictionary<Type, Form> _openedForms = new Dictionary<Type, Form>();

        public MainForm()
        {
            InitializeComponent();
            _communicationForm = new CommunicationWithMainForm(this);
        }

        #region TabbedForm button's handlers

        private void OrgStructureBarItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitAndShowForm<EmployeeForm>();
        }

        private void ShowAuditBarItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitAndShowForm<AuditForm>();
        }

        private void InitAndShowForm<T>() where T : BaseTabbedForm
        {
            var form = EnsureGetOpenedForm<T>();
            form.InitData();
            form.ShowAndBringToFront();
        }

        private T EnsureGetOpenedForm<T>() where T : BaseTabbedForm
        {
            if (_openedForms.ContainsKey(typeof(T)))
            {
                return (T)_openedForms[typeof(T)];
            }
            T newForm = (T)Activator.CreateInstance(typeof(T), _communicationForm);
            _openedForms.Add(typeof(T), newForm);
            return newForm;
        }

        #endregion

        #region Main form button's handlers

        private void SaveBarItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = xtraTabbedMdiManager.SelectedPage?.MdiChild as ISaveForm;
            form?.SaveData();
        }

        private void RefreshBarItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = xtraTabbedMdiManager.SelectedPage?.MdiChild as ISaveForm;
            form?.UpdateData();
        }

        private void ExitBarItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        #endregion
        
        public RibbonControl GetRibbonControl()
        {
            return ribbonControl;
        }

        private void xtraTabbedMdiManager_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            _openedForms.Remove(e.Page.MdiChild.GetType());
        }
    }
}
