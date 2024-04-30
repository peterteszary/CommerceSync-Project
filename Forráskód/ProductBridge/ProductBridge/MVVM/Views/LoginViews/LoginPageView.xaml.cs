using System;
using System.Windows;
using System.Windows.Controls;

namespace ProductBridge.MVVM.View
{
    /// <summary>
    /// Interaction logic for LoginPageView.xaml
    /// </summary>
    public partial class LoginPageView : UserControl
    {
        // Esemény definíciója a bejelentkezéshez
        public event EventHandler LoggedIn;

        public LoginPageView()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Bejelentkezés után emeld meg az eseményt
            LoggedIn?.Invoke(this, EventArgs.Empty);
        }


    }
}
