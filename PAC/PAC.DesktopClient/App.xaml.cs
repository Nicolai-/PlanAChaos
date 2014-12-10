using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PAC.DesktopClient.ViewModels;
using PAC.DesktopClient.Views;

namespace PAC.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ApplicationView app = new ApplicationView();
            ApplicationViewModel context = new ApplicationViewModel();
            app.DataContext = context;
            app.Show();
        }
    }
}
