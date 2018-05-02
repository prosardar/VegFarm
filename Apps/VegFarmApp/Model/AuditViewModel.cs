using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerFarm.Kernel.Model.DTO;

namespace VegFarm.Model
{
    public class AuditViewModel : BaseViewModel<ChangeLogDTO>
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

        public string Action
        {
            get
            {
                string action = "";
                switch (Dto.ActionId)
                {
                    case 1:
                        action = "Создание";
                        break;
                    case 2:
                        action = "Изменение";
                        break;
                    case 3:
                        action = "Удаление";
                        break;
                }
                return action;
            }
        }

        public DateTime? DateChanged
        {
            get => Dto.DateChanged;
            set
            {
                DateTime? date = Dto.DateChanged;
                SetProperty(ref date, value);
            }
        }

        public string EntityName
        {
            get => Dto.EntityName;
            set
            {
                string name = Dto.EntityName;
                SetProperty(ref name, value);
            }
        }

        public string NewValue
        {
            get => Dto.NewValue;
            set
            {
                string newValue = Dto.NewValue;
                SetProperty(ref newValue, value);
            }
        }

        public string OldValue
        {
            get => Dto.OldValue;
            set
            {
                string oldValue = Dto.OldValue;
                SetProperty(ref oldValue, value);
            }
        }

        public string PrimaryKeyValue
        {
            get => Dto.PrimaryKeyValue;
            set
            {
                string primaryKeyValue = Dto.PrimaryKeyValue;
                SetProperty(ref primaryKeyValue, value);
            }
        }

        public string PropertyName
        {
            get => Dto.PropertyName;
            set
            {
                string propertyName = Dto.PropertyName;
                SetProperty(ref propertyName, value);
            }
        }

        public string UserName
        {
            get => Dto.UserName;
            set
            {
                string userName = Dto.UserName;
                SetProperty(ref userName, value);
            }
        }

        public AuditViewModel(ChangeLogDTO dto) : base(dto)
        {
        }

        public AuditViewModel() : this(new ChangeLogDTO())
        {

        }
    }
}
