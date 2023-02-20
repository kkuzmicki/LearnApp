using LearnAppClientWPF.Models;
using LearnAppClientWPF.Services;
using LearnAppClientWPF.Stores;
using LearnAppClientWPF.Utilities;
using LearnAppClientWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LearnAppClientWPF.Commands
{
    class RegisterCommand : CommandBase
    {
        private readonly RegisterViewModel _viewModel;

        private readonly NavigationService<LoginViewModel> _navigationService;

        public RegisterCommand(RegisterViewModel viewModel, NavigationService<LoginViewModel> navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
        }

        public override async void Execute(object parameter)
        {
            //MessageBox.Show($"Signing up {_viewModel.EmailText}...");
            if(await SignUp()) _navigationService.Navigate();
        }

        private async Task<bool> SignUp()
        {
            if (String.IsNullOrEmpty(_viewModel.EmailText) || !Validator.IsEmailAddressValid(_viewModel.EmailText))
            {
                _viewModel.ErrorMessage = "Wrong e-mail address format";
                return false;
            }

            if (String.IsNullOrEmpty(_viewModel.ConfirmEmailText) || _viewModel.ConfirmEmailText != _viewModel.EmailText)
            {
                _viewModel.ErrorMessage = "Wrong confirmation of e-mail address";
                return false;
            }

            if (String.IsNullOrEmpty(_viewModel.PasswordText) || !Validator.IsPasswordValid(_viewModel.PasswordText))
            {
                _viewModel.ErrorMessage = "Wrong password format";
                return false;
            }

            if (String.IsNullOrEmpty(_viewModel.ConfirmPasswordText) || _viewModel.ConfirmPasswordText != _viewModel.PasswordText)
            {
                _viewModel.ErrorMessage = "Wrong confirmation of password";
                return false;
            }

            UserModel newUser = new UserModel()
            {
                email = _viewModel.EmailText,
                password = Cryptography.HashPassword_SHA256(_viewModel.PasswordText),
                aboutMe = "I'm a new user!"
            };

            try
            {
                await HttpHelper.CreateUserWithEmailAddressAndPassword(newUser);
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
