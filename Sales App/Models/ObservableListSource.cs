namespace SalesApp.Models
{
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Data.Entity;

    internal class ObservableListSource<T> : ObservableCollection<T>, IListSource where T : BaseModel
    {
        private IBindingList bindingList;

        bool IListSource.ContainsListCollection
        {
            get
            {
                return false;
            }
        }

        IList IListSource.GetList()
        {
            return bindingList ?? (bindingList = this.ToBindingList());
        }
    }
}
