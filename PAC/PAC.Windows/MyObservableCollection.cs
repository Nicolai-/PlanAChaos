using System.Collections.ObjectModel;

namespace PAC.Windows
{
    public class MyObservableCollection<T> : ObservableCollection<T>
    {

        public void ReplaceItem(int index, T item)
        {
            base.SetItem(index, item);
        }

    } 
}
