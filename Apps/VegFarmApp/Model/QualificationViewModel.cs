using VerFarm.Kernel.Model.DTO;

namespace VegFarm.Model
{
    public class QualificationViewModel : BaseViewModel<CatalogQualificationDTO>
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

        public string Qualification
        {
            get => Dto.Qualification;
            set
            {
                string qualification = Dto.Qualification;
                SetProperty(ref qualification, value);
            }
        }

        public int Rang
        {
            get => Dto.Rang;
            set
            {
                int rang = Dto.Rang;
                SetProperty(ref rang, value);
            }
        }

        public QualificationViewModel(CatalogQualificationDTO dto) : base(dto)
        {
        }

        public QualificationViewModel() : this(new CatalogQualificationDTO())
        {

        }

        //public ICollection<EmployeeViewModel> Employee { get; set; }
    }
}