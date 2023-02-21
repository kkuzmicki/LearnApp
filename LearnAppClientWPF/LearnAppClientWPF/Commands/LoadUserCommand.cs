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
    class LoadUserCommand : CommandBase
    {
        private readonly EditUserViewModel _viewModel;

        public LoadUserCommand(EditUserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override async void Execute(object parameter)
        {
            try
            {
                UserModel newUser = await HttpHelper.GetUserWithId(App.Current.Properties["UsersID"]?.ToString() ?? "");
                _viewModel.EmailText = newUser.email;
                _viewModel.ConfirmEmailText = newUser.email;
                _viewModel.AboutMeText = newUser.aboutMe;
                _viewModel.PhoneNumberText = newUser.phoneNumber;
                _viewModel.TwitterLinkText = newUser.twitterLink;
                _viewModel.FacebookLinkText = newUser.facebookLink;
                _viewModel.PasswordText = newUser.password;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Ex: " + ex.Message);
                _viewModel.ErrorMessage = $"Could not sign in! Exception: {ex.Message}";
            }
        }

    }
}
