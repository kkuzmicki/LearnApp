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
    /// Interaction logic for AddView.xaml
    /// </summary>
    public partial class EditUserView : UserControl
    {
        public EditUserView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            var viewModel = (EditUserViewModel)DataContext;
            if (viewModel.LoadUserCommand.CanExecute(null))
                viewModel.LoadUserCommand.Execute(null);
        }
    }
}
