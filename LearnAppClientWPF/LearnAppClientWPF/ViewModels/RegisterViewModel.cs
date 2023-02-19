using CommunityToolkit.Mvvm.Input;
using LearnAppClientWPF.Commands;
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
    class RegisterViewModel : ViewModelBase
    {
        public string? EmailText { get; set; } = "admin1@email.com";
        public string? PasswordText { get; set; } = "strongPassword1";

        public ICommand NavigationLoginCommand { get; }

        public RegisterViewModel(NavigationStore navigationStore)
        {
            NavigationLoginCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
        }
    }
}
