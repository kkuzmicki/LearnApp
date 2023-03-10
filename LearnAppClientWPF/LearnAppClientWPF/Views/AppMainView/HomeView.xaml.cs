using LearnAppClientWPF.Utilities;
using LearnAppClientWPF.ViewModels;
using LearnAppClientWPF.ViewModels.AppMainViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LearnAppClientWPF.Views.AppMainViews
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var viewModel = (HomeViewModel)DataContext;
            if (viewModel.HelloCommand.CanExecute(null))
                viewModel.HelloCommand.Execute(null);
        }
    }
}
