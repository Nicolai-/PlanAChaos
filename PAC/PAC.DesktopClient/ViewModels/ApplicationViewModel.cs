// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationViewModel.cs" company="">
//   .
// </copyright>
// <summary>
//   The application view model class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PAC.DesktopClient.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;

    using PAC.Windows;

namespace PAC.DesktopClient.ViewModels
{
    /// <summary>
    /// The application view model class.
    /// </summary>
    public class ApplicationViewModel : ViewModel 
    {
        #region Fields

        /// <summary>
        /// The change page command.
        /// </summary>
        private ICommand changePageCommand;

        /// <summary>
        /// The current page view model.
        /// </summary>
        private IPageViewModel currentPageViewModel;

        /// <summary>
        /// The page view models.
        /// </summary>
        private List<IPageViewModel> pageViewModels;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationViewModel"/> class.
        /// </summary>
        public ApplicationViewModel()
        {
            // available pages
            this.PageViewModels.Add(new HomeViewModel());
            this.PageViewModels.Add(new StudentViewModel());
            this.PageViewModels.Add(new TeacherViewModel());

            // Set starting page
            this.CurrentPageViewModel = this.PageViewModels[0];
        }

        #region Properties / Commands

        /// <summary>
        /// Gets the change page command.
        /// </summary>
        public ICommand ChangePageCommand
        {
            get
            {
                if (this.changePageCommand == null)
                {
                    this.changePageCommand = new ActionCommand(
                        p => this.ChangeViewModel((IPageViewModel)p),
                        p => p is IPageViewModel);
                }

                return this.changePageCommand;
            }
        }

        /// <summary>
        /// Gets the page view models.
        /// </summary>
        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (this.pageViewModels == null)
                {
                    this.pageViewModels = new List<IPageViewModel>();
                }

                return this.pageViewModels;
            }
        }

        /// <summary>
        /// Gets or sets the current page view model.
        /// </summary>
        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return this.currentPageViewModel;
            }
            set
            {
                if (this.currentPageViewModel != value)
                {
                    this.currentPageViewModel = value;
                    this.NotifyPropertyChanged("CurrentPageViewModel");
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The change view model.
        /// </summary>
        /// <param name="viewModel">
        /// The view model.
        /// </param>
        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!this.PageViewModels.Contains(viewModel))
            {
                this.PageViewModels.Add(viewModel);
            }

            this.CurrentPageViewModel = this.PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        #endregion
    }
}
