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
    class LoginViewModel : ViewModelBase
    {
        public string? EmailText { get; set; } = "admin1@email.com";
        public string? PasswordText { get; set; } = "strongPassword1";
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

        //public ICommand LoginCommand => new RelayCommand(SignIn);
        public ICommand NavigationRegisterCommand { get; }
        public ICommand LoginCommand { get; }

        public LoginViewModel(NavigationStore navigationStore)
        {
            NavigationRegisterCommand = new NavigateCommand<RegisterViewModel>(new NavigationService<RegisterViewModel>(
                navigationStore, () => new RegisterViewModel(navigationStore)));

            LoginCommand = new LoginCommand(this, new NavigationService<MenuViewModel>(
                navigationStore, () => new MenuViewModel(navigationStore)));
        }

        public void ErrorMessageChanged()
        {
            OnPropertyChanged(nameof(ErrorMessage));
        }
    }
}