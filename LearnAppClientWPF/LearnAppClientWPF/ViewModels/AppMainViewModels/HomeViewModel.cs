using LearnAppClientWPF.Commands;
using LearnAppClientWPF.Models;
using LearnAppClientWPF.Stores;
using LearnAppClientWPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearnAppClientWPF.ViewModels.AppMainViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand HelloCommand { get; }

        public UserModel? loggedUser;
        public void UserModelChanged()
        {
            OnPropertyChanged(nameof(loggedUser));
            OnPropertyChanged(nameof(UsersEmail));
        }
        public string UsersEmail => "Hello, " + (loggedUser?.email ?? "") + "!";

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

        public HomeViewModel(NavigationStore mainNavigationStore, NavigationStore subNavigationStore) 
        {
            HelloCommand = new HelloCommand(this);
        }
    }
}
