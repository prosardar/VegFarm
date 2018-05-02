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

        private void OrgStructureBarItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = GetOpenedForm<EmployeeForm>();
            form.InitData();
            form.ShowAndBringToFront();
        }

        private void ShowAuditBarItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = GetOpenedForm<AuditForm>();
            form.InitData();
            form.ShowAndBringToFront();
        }

        private T GetOpenedForm<T>() where T : Form
        {
            if (_openedForms.ContainsKey(typeof(T)))
            {
                return (T)_openedForms[typeof(T)];
            }
            T newForm = (T)Activator.CreateInstance(typeof(T), _communicationForm);
            _openedForms.Add(typeof(T), newForm);
            return newForm;
        }

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

        public RibbonControl GetRibbonControl()
        {
            return ribbonControl;
        }

        private void xtraTabbedMdiManager_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            var form = e.Page.MdiChild as Form;
            _openedForms.Remove(form.GetType());
        }
    }
}
