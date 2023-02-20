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
    public class SettingsViewModel : ViewModelBase
    {
        public ICommand NavigationEditUserCommand { get; }
        public ICommand SignOutCommand { get; }

        public SettingsViewModel(NavigationStore mainNavigationStore, NavigationStore subNavigationStore) 
        {
            NavigationEditUserCommand = new NavigateCommand<EditUserViewModel>(new NavigationService<EditUserViewModel>
                    (subNavigationStore, () => new EditUserViewModel(mainNavigationStore, subNavigationStore)));


            SignOutCommand = new SignOutCommand(new NavigationService<LoginViewModel>(
                mainNavigationStore, () => new LoginViewModel(mainNavigationStore)));
        }
    }
}
