using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAC.Windows;

namespace PAC.DesktopClient.ViewModels
{
    public class HomeViewModel : ViewModel, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Home Page";
            }
        }


    }
}
