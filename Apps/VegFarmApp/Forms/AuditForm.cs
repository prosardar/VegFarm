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
using VegFarm.Model;
using VerFarm.Kernel.Model.DTO;

namespace VegFarm.Forms
{
    public partial class AuditForm : BaseTabbedForm
    {
        public AuditForm(CommunicationWithMainForm communicationForm) : base(communicationForm)
        {
            InitializeComponent();
        }

        public override void AddRibbonGroup()
        {
        }

        public override void SaveData()
        {
        }

        public override async void UpdateData()
        {
            DataSourceDic.Clear();
            transferGridView.LoadingPanelVisible = true;
            await Task.Factory.StartNew(() =>
            {
                Task<ICachedData> te = CommunicationForm.DataManager.GetDataSourceAsync<EmployeeTransferDTO>();
                te.Wait();
                var collection = te.Result as CacheCollection<EmployeeTransferDTO>;
                List<EmployeeTransferViewModel> l = collection.Select(dto => new EmployeeTransferViewModel(dto)).ToList();
                var list = new ViewModelBindingList<EmployeeTransferViewModel>(l);
                DataSourceDic.Add("employeeTransfers", list);

            }).ContinueWith((task) =>
            {
                transferGridControl.DataSource = DataSourceDic["employeeTransfers"];
                transferGridView.LoadingPanelVisible = false;
            }, TaskScheduler.FromCurrentSynchronizationContext());

            auditGridView.LoadingPanelVisible = true;
            await Task.Factory.StartNew(() =>
            {
                Task<ICachedData> te = CommunicationForm.DataManager.GetDataSourceAsync<ChangeLogDTO>();
                te.Wait();
                var collection = te.Result as CacheCollection<ChangeLogDTO>;
                List<AuditViewModel> l = collection.Select(dto => new AuditViewModel(dto)).ToList();
                var list = new ViewModelBindingList<AuditViewModel>(l);
                DataSourceDic.Add("audits", list);

            }).ContinueWith((task) =>
            {
                auditGridControl.DataSource = DataSourceDic["audits"];
                auditGridView.LoadingPanelVisible = false;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
