using LearnAppClientWPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnAppClientWPF.ViewModels.AppMainViewModels
{
    public class ExploreViewModel : ViewModelBase
    {
        public ObservableCollection<FlashcardSetViewModel> ListViewModels;
        public string TEST { get; } = "TESTESFDSD";
        //public FlashcardSetViewModel ListViewModels;

        public ExploreViewModel(NavigationStore mainNavigationStore, NavigationStore subNavigationStore) 
        {
            ListViewModels = new ObservableCollection<FlashcardSetViewModel>
            {
                new FlashcardSetViewModel()
            };
            OnPropertyChanged(nameof(ListViewModels));
        }
    }
}
