using CommunityToolkit.Mvvm.Input;
using LearnAppClientWPF.Commands;
using LearnAppClientWPF.Models;
using LearnAppClientWPF.Services;
using LearnAppClientWPF.Stores;
using LearnAppClientWPF.Utilities;
using LearnAppClientWPF.ViewModels.AppMainViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearnAppClientWPF.ViewModels.AppMainViewModels
{
    class MenuViewModel : ViewModelBase
    {        
        public string UsersID { get; set; }

        private readonly NavigationStore _navigationSubStore;
        public ViewModelBase CurrentSubViewModel => _navigationSubStore.CurrentViewModel;

        public ICommand NavigationHomeCommand { get; }
        public ICommand NavigationSearchCommand { get; }
        public ICommand NavigationExploreCommand { get; }
        public ICommand NavigationAddCommand { get; }
        public ICommand NavigationSettingsCommand { get; }

        //public int SelectedOption; in future

        public MenuViewModel(NavigationStore navigationStore)
        {
            UsersID = App.Current?.Properties["UsersID"]?.ToString() ?? "error";

            _navigationSubStore = new();
            _navigationSubStore.CurrentViewModel = new HomeViewModel(navigationStore, _navigationSubStore);

            #region Initialize Commands
            {
                NavigationHomeCommand = new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>
                        (_navigationSubStore, () => new HomeViewModel(navigationStore, _navigationSubStore)));

                NavigationSearchCommand = new NavigateCommand<SearchViewModel>(new NavigationService<SearchViewModel>
                        (_navigationSubStore, () => new SearchViewModel(navigationStore, _navigationSubStore)));

                NavigationExploreCommand = new NavigateCommand<ExploreViewModel>(new NavigationService<ExploreViewModel>
                        (_navigationSubStore, () => new ExploreViewModel(navigationStore, _navigationSubStore)));

                NavigationAddCommand = new NavigateCommand<AddViewModel>(new NavigationService<AddViewModel>
                        (_navigationSubStore, () => new AddViewModel(navigationStore, _navigationSubStore)));

                NavigationSettingsCommand = new NavigateCommand<SettingsViewModel>(new NavigationService<SettingsViewModel>
                        (_navigationSubStore, () => new SettingsViewModel(navigationStore, _navigationSubStore)));
            }
            #endregion Initialize Commands

            _navigationSubStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentSubViewModel));
        }
    }
}
