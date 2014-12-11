// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyObservableCollection.cs" company="J.N Systems">
//   .
// </copyright>
// <summary>
//   Defines the MyObservableCollection type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PAC.Windows
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// The my observable collection.
    /// </summary>
    /// <typeparam name="T">
    /// Can take any Type of object
    /// </typeparam>
    public class MyObservableCollection<T> : ObservableCollection<T>
    {
        /// <summary>
        /// The replace item.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="item">
        /// The item.
        /// </param>
        public void ReplaceItem(int index, T item)
        {
            this.SetItem(index, item);
        }

    } 
}
