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
    class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _viewModel;

        private readonly NavigationService<MenuViewModel> _navigationService;

        public LoginCommand(LoginViewModel viewModel, NavigationService<MenuViewModel> navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
        }

        public override async void Execute(object parameter)
        {
            if(await SignIn()) _navigationService.Navigate();
        }

        private async Task<bool> SignIn()
        {
            if (String.IsNullOrEmpty(_viewModel.EmailText) || !Validator.IsEmailAddressValid(_viewModel.EmailText))
            {
                Trace.WriteLine("wrong email");
                _viewModel.ErrorMessage = "Wrong e-mail address";
                return false;
            }

            if (String.IsNullOrEmpty(_viewModel.PasswordText) || !Validator.IsPasswordValid(_viewModel.PasswordText))
            {
                Trace.WriteLine("wrong password");
                _viewModel.ErrorMessage = "Wrong password";
                //_viewModel.ErrorMessageChanged();
                return false;
            }

            try
            {
                UserModel userModel = await HttpHelper.GetUserWithEmailAddressAndPassword(_viewModel.EmailText, Cryptography.HashPassword_SHA256(_viewModel.PasswordText));
                App.Current.Properties["UsersID"] = userModel.id;
                Trace.WriteLine(App.Current.Properties["UsersID"] ?? "No 'UsersID'");
                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Ex: " + ex.Message);
                _viewModel.ErrorMessage = $"Could not sign in! Exception: {ex.Message}";
                return false;
            }
        }
    }
}
