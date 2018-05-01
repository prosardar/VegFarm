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
    public partial class EmployeeForm : Form, ISaveForm
    {
        private CommunicationWithMainForm _communicationForm;
        private RibbonControl _ribbonControl;
        private Dictionary<string, object> _dataSourceDic = new Dictionary<string, object>();

        public EmployeeForm(CommunicationWithMainForm communicationForm)
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

        public async void ShowAndInitData()
        {
            Show();
            UpdateData();            
        }
        
        private void d_Click(object sender, ItemClickEventArgs e)
        {

        }

        public void SaveData()
        {
            foreach(var dataSource in _dataSourceDic.Values)
            {
                var list = dataSource as IViewModelBindingList;
                IList<IViewModel> deleted = list.GetDeletedItems();
                foreach(var item in deleted)
                {
                    _communicationForm.DataManager.Delete(item.DtoType, item.DtoId);
                }
                IList<IViewModel> changed = list.GetChangedItems();
                foreach (var item in changed)
                {
                    _communicationForm.DataManager.Update((BaseDTO)item.Dto);
                }
                IList<IViewModel> added = list.GetAddedItems();
                foreach (var item in added)
                {
                    _communicationForm.DataManager.Create((BaseDTO)item.Dto);
                }
            }
        }

        public async void UpdateData()
        {
            _dataSourceDic.Clear();
            employeeGridView.LoadingPanelVisible = true;
            await Task.Factory.StartNew(() =>
            {
                Task<ICachedData> te = _communicationForm.DataManager.GetDataSourceAsync<EmployeeDTO>();
                te.Wait();
                var collection = te.Result as CacheCollection<EmployeeDTO>;
                List<EmployeeViewModel> l = collection.Select(dto => new EmployeeViewModel(dto)).ToList();
                var list = new ViewModelBindingList<EmployeeViewModel>(l);
                _dataSourceDic.Add("employees", list);

            }).ContinueWith((task) =>
            {
                employeeGridControl.DataSource = _dataSourceDic["employees"];
                employeeGridView.LoadingPanelVisible = false;
            }, TaskScheduler.FromCurrentSynchronizationContext());

            departmentGridView.LoadingPanelVisible = true;
            await Task.Factory.StartNew(() =>
            {
                Task<ICachedData> td = _communicationForm.DataManager.GetDataSourceAsync<CatalogDepartmentDTO>();
                td.Wait();
                var collection = td.Result as CacheCollection<CatalogDepartmentDTO>;
                List<DepartmentViewModel> l = collection.Select(dto => new DepartmentViewModel(dto)).ToList();
                var list = new ViewModelBindingList<DepartmentViewModel>(l);
                _dataSourceDic.Add("departments", list);

            }).ContinueWith((task) =>
            {
                departmentsLookUpEdit.ValueMember = "Id";
                departmentsLookUpEdit.DisplayMember = "Name";
                departmentsLookUpEdit.DataSource = _dataSourceDic["departments"];

                departmentGridControl.DataSource = _dataSourceDic["departments"];

                colDepartment.Group();
                departmentGridView.LoadingPanelVisible = false;
            }, TaskScheduler.FromCurrentSynchronizationContext());

            qualificationGridView.LoadingPanelVisible = true;
            await Task.Factory.StartNew(() =>
            {
                Task<ICachedData> tq = _communicationForm.DataManager.GetDataSourceAsync<CatalogQualificationDTO>();
                tq.Wait();
                var collection = tq.Result as CacheCollection<CatalogQualificationDTO>;
                List<QualificationViewModel> l = collection.Select(dto => new QualificationViewModel(dto)).ToList();
                var list = new ViewModelBindingList<QualificationViewModel>(l);
                _dataSourceDic.Add("qualifications", list);
            }).ContinueWith((task) =>
            {
                qualificationsLookUpEdit.ValueMember = "Id";
                qualificationsLookUpEdit.DisplayMember = "Qualification";
                qualificationsLookUpEdit.DataSource = _dataSourceDic["qualifications"];

                qualificationGridControl.DataSource = _dataSourceDic["qualifications"];
                qualificationGridView.LoadingPanelVisible = false;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void EmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeleteRibbonGroup();
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