using CommunityToolkit.Mvvm.Input;
using LearnAppClientWPF.Commands;
using LearnAppClientWPF.Models;
using LearnAppClientWPF.Services;
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
        public string? EmailText { get; set; } = "";
        public string? ConfirmEmailText { get; set; } = "";
        public string? PasswordText { get; set; } = "";
        public string? ConfirmPasswordText { get; set; } = "";

        private string? _errorMessage = "";
        public string? ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(ErrorMessageHasValue));
            }
        }

        public bool ErrorMessageHasValue => !String.IsNullOrEmpty(_errorMessage);

        public ICommand NavigationLoginCommand { get; }

        public ICommand RegisterCommand { get; }

        public RegisterViewModel(NavigationStore navigationStore)
        {
            NavigationLoginCommand = new NavigateCommand<LoginViewModel>(new NavigationService<LoginViewModel>
                (navigationStore, () => new LoginViewModel(navigationStore)));

            RegisterCommand = new RegisterCommand(this, new NavigationService<LoginViewModel>(
                navigationStore, () => new LoginViewModel(navigationStore)));
        }
    }
}
