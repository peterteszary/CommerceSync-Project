using System.Windows.Controls;
using ProductBridge.MVVM.ViewModels;

namespace ProductBridge.MVVM.Views.UserViews
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        private UserViewModel _viewModel;

        public UserView(UserViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }
    }
}
