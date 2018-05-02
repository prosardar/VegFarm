using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using VerFarm.Kernel.Model.DTO;

namespace VegFarm.Model
{
    public abstract class BaseViewModel<TDto> : INotifyPropertyChanged, INotifyDataErrorInfo, IViewModel
        where TDto : IBaseDTO
    {
        protected TDto Dto;

        public int DtoId => Dto.Id;

        public bool HasErrors { get; set; }

        public StateViewModel State { get; set; }

        public Type DtoType => typeof(TDto);

        IBaseDTO IViewModel.Dto => Dto;

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public BaseViewModel(TDto dto)
        {
            Dto = dto;
            State = StateViewModel.NoEvent;
        }

        protected bool SetProperty<Tp>(ref Tp storage, Tp value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }
            storage = value;
            SetDtoProperty(propertyName, value);
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void SetDtoProperty<Tp>(string propertyName, Tp value)
        {
            PropertyInfo propertyInfo = typeof(TDto).GetProperty(propertyName);
            propertyInfo.SetValue(Dto, Convert.ChangeType(value, propertyInfo.PropertyType), null);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}