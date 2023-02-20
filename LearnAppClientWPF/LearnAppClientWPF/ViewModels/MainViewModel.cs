using CommunityToolkit.Mvvm.Input;
using LearnAppClientWPF.Models;
using LearnAppClientWPF.Stores;
using LearnAppClientWPF.Utilities;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace LearnAppClientWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        //public string ErrorMessage { get; }

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
