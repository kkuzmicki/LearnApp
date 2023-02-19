using CommunityToolkit.Mvvm.Input;
using LearnAppClientWPF.Models;
using LearnAppClientWPF.Stores;
using LearnAppClientWPF.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearnAppClientWPF.ViewModels
{
    class MenuViewModel : ViewModelBase
    {        
        public string UsersID { get; set; }

        public MenuViewModel(NavigationStore navigationStore)
        {
            UsersID = App.Current?.Properties["UsersID"]?.ToString() ?? "error";
        }
    }
}
