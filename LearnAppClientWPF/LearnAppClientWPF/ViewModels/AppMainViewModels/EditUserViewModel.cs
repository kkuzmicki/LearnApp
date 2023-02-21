using LearnAppClientWPF.Commands;
using LearnAppClientWPF.Services;
using LearnAppClientWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearnAppClientWPF.ViewModels.AppMainViewModels
{
    public class EditUserViewModel : ViewModelBase
    {
        private string _emailText = "";
        public string EmailText
        {
            get { return _emailText; }
            set
            {
                _emailText = value;
                OnPropertyChanged(nameof(EmailText));
            }
        }

        private string _confirmEmailText = "";
        public string ConfirmEmailText
        {
            get { return _confirmEmailText; }
            set
            {
                _confirmEmailText = value;
                OnPropertyChanged(nameof(ConfirmEmailText));
            }
        }

        private string _phoneNumberText = "";
        public string PhoneNumberText
        {
            get { return _phoneNumberText; }
            set
            {
                _phoneNumberText = value;
                OnPropertyChanged(nameof(PhoneNumberText));
            }
        }

        private string _twitterLinkText = "";
        public string TwitterLinkText
        {
            get { return _twitterLinkText; }
            set
            {
                _twitterLinkText = value;
                OnPropertyChanged(nameof(TwitterLinkText));
            }
        }

        private string _facebookLinkText = "";
        public string FacebookLinkText
        {
            get { return _facebookLinkText; }
            set
            {
                _facebookLinkText = value;
                OnPropertyChanged(nameof(FacebookLinkText));
            }
        }

        private string _aboutMeText = "";
        public string AboutMeText
        {
            get { return _aboutMeText; }
            set
            {
                _aboutMeText = value;
                OnPropertyChanged(nameof(AboutMeText));
            }
        }

        private string _errorMessage = "";
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool ErrorMessageHasValue => !String.IsNullOrEmpty(_errorMessage);

        public string PasswordText { get; set; } = "";

        public ICommand NavigationSettingsCommand { get; }
        public ICommand LoadUserCommand { get; }
        public ICommand EditUserCommand { get; }

        public EditUserViewModel(NavigationStore mainNavigationStore, NavigationStore subNavigationStore)
        {
            NavigationSettingsCommand = new NavigateCommand<SettingsViewModel>(new NavigationService<SettingsViewModel>
                    (subNavigationStore, () => new SettingsViewModel(mainNavigationStore, subNavigationStore)));

            LoadUserCommand = new LoadUserCommand(this);

            EditUserCommand = new EditUserCommand(this, new NavigationService<SettingsViewModel>(
                subNavigationStore, () => new SettingsViewModel(mainNavigationStore, subNavigationStore)));
        }
    }
}
