using System.Collections.Generic;

namespace VegFarm.Model
{
    internal interface IViewModelBindingList
    {
        IList<IViewModel> GetDeletedItems();

        IList<IViewModel> GetChangedItems();

        IList<IViewModel> GetAddedItems();
    }
}