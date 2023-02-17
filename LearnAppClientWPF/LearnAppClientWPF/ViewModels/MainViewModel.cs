using CommunityToolkit.Mvvm.Input;
using LearnAppClientWPF.Models;
using LearnAppClientWPF.Utilities;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace LearnAppClientWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; set; }

        public ICommand GoToRegisterCommand => new RelayCommand(GoToRegister);


        public MainViewModel()
        {
            CurrentViewModel = new LoginViewModel();
        }

        public void GoToRegister()
        {
            CurrentViewModel = new RegisterViewModel();
            //NotifyPropertyChanged("CurrentViewModel");
            Trace.WriteLine("aaaa");
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
