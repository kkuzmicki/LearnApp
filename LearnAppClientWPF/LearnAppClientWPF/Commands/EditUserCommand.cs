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
    class EditUserCommand : CommandBase
    {
        private readonly EditUserViewModel _viewModel;

        private readonly NavigationService<SettingsViewModel> _navigationService;

        public EditUserCommand(EditUserViewModel viewModel, NavigationService<SettingsViewModel> navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
        }

        public override async void Execute(object parameter)
        {
            //MessageBox.Show($"Signing up {_viewModel.EmailText}...");
            if (await UpdateUser()) _navigationService.Navigate();
        }

        private async Task<bool> UpdateUser()
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

            if (!String.IsNullOrEmpty(_viewModel.FacebookLinkText) && Uri.IsWellFormedUriString(_viewModel.FacebookLinkText, UriKind.Absolute))
            {
                _viewModel.ErrorMessage = "Wrong Facebook link format";
                return false;
            }

            if (String.IsNullOrEmpty(_viewModel.TwitterLinkText) && Uri.IsWellFormedUriString(_viewModel.TwitterLinkText, UriKind.Absolute))
            {
                _viewModel.ErrorMessage = "Wrong Twitter link format";
                return false;
            }

            if (!String.IsNullOrEmpty(_viewModel.PhoneNumberText) && int.TryParse(_viewModel.PhoneNumberText, out _))
            {
                _viewModel.ErrorMessage = "Wrong phone number format";
                return false;
            }

            UserModel newUser = new UserModel()
            {
                email = _viewModel.EmailText,
                aboutMe = _viewModel.AboutMeText,
                phoneNumber = _viewModel.PhoneNumberText,
                facebookLink = _viewModel.FacebookLinkText,
                twitterLink = _viewModel.TwitterLinkText,
                password = _viewModel.PasswordText
            };

            try
            {
                await HttpHelper.UpdateUser(newUser);
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
