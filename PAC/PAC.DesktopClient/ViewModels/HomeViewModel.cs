// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeViewModel.cs" company="J.N Systems">
//   .
// </copyright>
// <summary>
//   The home view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PAC.DesktopClient.ViewModels
{
    using PAC.Windows;

    /// <summary>
    /// The home view model.
    /// </summary>
    public class HomeViewModel : ViewModel, IPageViewModel
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return "Home Page";
            }
        }
    }
}
