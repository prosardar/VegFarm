using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace VegFarm.Model
{
    public class ViewModelBindingList<TVM> : BindingList<TVM>, IViewModelBindingList where TVM : IViewModel
    {
        public IList<IViewModel> DeletedItems = new List<IViewModel>();

        public ViewModelBindingList() : base()
        {
            AllowNew = true;
            AllowEdit = true;
            AllowRemove = true;
        }

        public ViewModelBindingList(IList<TVM> list) : base(list)
        {
            AllowNew = true;
            AllowEdit = true;
            AllowRemove = true;
        }

        protected override object AddNewCore()
        {
            IViewModel newModel = (IViewModel)base.AddNewCore();
            //  что-то можно ещё предопределить (задать) новому объекту
            return newModel;
        }

        protected override void RemoveItem(int index)
        {
            TVM item = Items[index];
            item.State = StateViewModel.Deleted;
            DeletedItems.Add(item);
            base.RemoveItem(index);
        }

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            base.OnListChanged(e);
            if(e.ListChangedType == ListChangedType.ItemDeleted)
            {
                return;
            }
            TVM item = Items[e.NewIndex];
            if(item.State == StateViewModel.Added)
            {
                return;
            }            
            switch (e.ListChangedType)
            { 
                case ListChangedType.ItemAdded:
                    Items[e.NewIndex].State = StateViewModel.Added;
                    break;                    
                case ListChangedType.ItemChanged:
                    Items[e.NewIndex].State = StateViewModel.Changed;
                    break;              
            }   
        }

        public object GetDeletedItems()
        {
            return DeletedItems;
        }
    }
}