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
    public partial class AuditForm : BaseTabForm
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

        public override void UpdateData()
        {
            //employeeGridView.LoadingPanelVisible = true;
            //await Task.Factory.StartNew(() =>
            //{
            //    Task<ICachedData> te = _communicationForm.DataManager.GetDataSourceAsync<EmployeeDTO>();
            //    te.Wait();
            //    var collection = te.Result as CacheCollection<EmployeeDTO>;
            //    List<EmployeeViewModel> l = collection.Select(dto => new EmployeeViewModel(dto)).ToList();
            //    var list = new ViewModelBindingList<EmployeeViewModel>(l);
            //    _dataSourceDic.Add("employees", list);

            //}).ContinueWith((task) =>
            //{
            //    employeeGridControl.DataSource = _dataSourceDic["employees"];
            //    employeeGridView.LoadingPanelVisible = false;
            //}, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
