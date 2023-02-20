using LearnAppClientWPF.Models;
using LearnAppClientWPF.Services;
using LearnAppClientWPF.Stores;
using LearnAppClientWPF.Utilities;
using LearnAppClientWPF.ViewModels;
using LearnAppClientWPF.ViewModels.AppMainViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LearnAppClientWPF.Commands
{
    class SignOutCommand : CommandBase
    {

        private readonly NavigationService<LoginViewModel> _navigationService;

        public SignOutCommand(NavigationService<LoginViewModel> navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            App.Current.Properties["UsersID"] = "";

            _navigationService.Navigate();
        }
    }
}
