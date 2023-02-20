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
        private readonly HomeViewModel _viewModel;

        public EditUserCommand(HomeViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override async void Execute(object parameter)
        {
            try
            {
                _viewModel.loggedUser = await HttpHelper.GetUserWithId(App.Current.Properties["UsersID"]?.ToString() ?? "");
                _viewModel.UserModelChanged();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Ex: " + ex.Message);
                _viewModel.ErrorMessage = $"Could not sign in! Exception: {ex.Message}";
                throw;
            }
        }
    }
}
