using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using VerFarm.Kernel.Model.DTO;
using VegFarm.Model;
using VegFarm.Data;
using DevExpress.XtraGrid.Views.Grid;

namespace VegFarm.Forms
{
    public partial class EmployeeForm : BaseTabbedForm
    {
        public EmployeeForm(CommunicationWithMainForm communicationForm) : base(communicationForm)
        {
            InitializeComponent();         
        }

        public override void AddRibbonGroup()
        {
            var mainPage = RibbonControl.Pages["Главная"];
            var pageGroup = mainPage.Groups.GetGroupByName("EmployeePageGroup");
            if (pageGroup != null)
            {
                return;
            }

            var d = new BarButtonItem();
            d.Caption = "Действие";
            d.Id = 1;
            d.Name = "SameAction";

            pageGroup = new RibbonPageGroup();
            pageGroup.ItemLinks.Add(d);
            pageGroup.Name = "EmployeePageGroup";
            pageGroup.Text = "Сотрудники";

            mainPage.Groups.Add(pageGroup);
        }
              
        public override void SaveData()
        {
            foreach (var dataSource in DataSourceDic.Values)
            {
                var list = dataSource as IViewModelBindingList;
                IList<IViewModel> deleted = list.GetDeletedItems();
                foreach (var item in deleted)
                {
                    CommunicationForm.DataManager.Delete(item.DtoType, item.DtoId);
                }
                IList<IViewModel> changed = list.GetChangedItems();
                foreach (var item in changed)
                {
                    CommunicationForm.DataManager.Update((BaseDTO)item.Dto);
                }
                IList<IViewModel> added = list.GetAddedItems();
                foreach (var item in added)
                {
                    CommunicationForm.DataManager.Create((BaseDTO)item.Dto);
                }
            }
        }

        public override async void UpdateData()
        {
            DataSourceDic.Clear();
            employeeGridView.LoadingPanelVisible = true;
            await Task.Factory.StartNew(() =>
            {
                Task<ICachedData> te = CommunicationForm.DataManager.GetDataSourceAsync<EmployeeDTO>();
                te.Wait();
                var collection = te.Result as CacheCollection<EmployeeDTO>;
                List<EmployeeViewModel> l = collection.Select(dto => new EmployeeViewModel(dto)).ToList();
                var list = new ViewModelBindingList<EmployeeViewModel>(l);
                DataSourceDic.Add("employees", list);

            }).ContinueWith((task) =>
            {
                employeeGridControl.DataSource = DataSourceDic["employees"];
                employeeGridView.LoadingPanelVisible = false;
            }, TaskScheduler.FromCurrentSynchronizationContext());

            departmentGridView.LoadingPanelVisible = true;
            await Task.Factory.StartNew(() =>
            {
                Task<ICachedData> td = CommunicationForm.DataManager.GetDataSourceAsync<CatalogDepartmentDTO>();
                td.Wait();
                var collection = td.Result as CacheCollection<CatalogDepartmentDTO>;
                List<DepartmentViewModel> l = collection.Select(dto => new DepartmentViewModel(dto)).ToList();
                var list = new ViewModelBindingList<DepartmentViewModel>(l);
                DataSourceDic.Add("departments", list);

            }).ContinueWith((task) =>
            {
                departmentsLookUpEdit.ValueMember = "Id";
                departmentsLookUpEdit.DisplayMember = "Name";
                departmentsLookUpEdit.DataSource = DataSourceDic["departments"];

                departmentGridControl.DataSource = DataSourceDic["departments"];

                colDepartment.Group();
                departmentGridView.LoadingPanelVisible = false;
            }, TaskScheduler.FromCurrentSynchronizationContext());

            qualificationGridView.LoadingPanelVisible = true;
            await Task.Factory.StartNew(() =>
            {
                Task<ICachedData> tq = CommunicationForm.DataManager.GetDataSourceAsync<CatalogQualificationDTO>();
                tq.Wait();
                var collection = tq.Result as CacheCollection<CatalogQualificationDTO>;
                List<QualificationViewModel> l = collection.Select(dto => new QualificationViewModel(dto)).ToList();
                var list = new ViewModelBindingList<QualificationViewModel>(l);
                DataSourceDic.Add("qualifications", list);
            }).ContinueWith((task) =>
            {
                qualificationsLookUpEdit.ValueMember = "Id";
                qualificationsLookUpEdit.DisplayMember = "Qualification";
                qualificationsLookUpEdit.DataSource = DataSourceDic["qualifications"];

                qualificationGridControl.DataSource = DataSourceDic["qualifications"];
                qualificationGridView.LoadingPanelVisible = false;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Поменить на удаление?", "Подтверждение удаления", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
                GridView view = sender as GridView;
                view.DeleteRow(view.FocusedRowHandle);
            }
        }
    }
}