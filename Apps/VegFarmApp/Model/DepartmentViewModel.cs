using VerFarm.Kernel.Model.DTO;

namespace VegFarm.Model
{
    public class DepartmentViewModel : BaseViewModel<CatalogDepartmentDTO>
    {
        public int Id
        {
            get => Dto.Id;
            set
            {
                int id = Dto.Id;
                SetProperty(ref id, value);
            }
        }

        public string Name
        {
            get => Dto.Name;
            set
            {
                string name = Dto.Name;
                SetProperty(ref name, value);
            }
        }

        public int EmployeeCount
        {
            get => Dto.EmployeeCount;
            set
            {
                int count = Dto.EmployeeCount;
                SetProperty(ref count, value);
            }
        }

        public DepartmentViewModel(CatalogDepartmentDTO dto) : base(dto)
        {
        }

        public DepartmentViewModel() : this(new CatalogDepartmentDTO())
        {

        }
    }
}