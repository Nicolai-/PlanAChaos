using PAC.Windows;

namespace PAC.DesktopClient.ViewModels
{
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
